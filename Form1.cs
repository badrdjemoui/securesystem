using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace securesystem
{
    // الكلاس الرئيسي للنموذج Form1
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); // تهيئة واجهة المستخدم (Designer)
        }

        #region WinAPI Definitions
        // تعريفات الـ WinAPI للحصول على TCP/UDP مع PID

        // نوع الجدول المطلوب من TCP
        enum TCP_TABLE_CLASS { TCP_TABLE_OWNER_PID_ALL = 5 }

        // نوع الجدول المطلوب من UDP
        enum UDP_TABLE_CLASS { UDP_TABLE_OWNER_PID = 1 }

        // بنية صف TCP مع PID
        [StructLayout(LayoutKind.Sequential)]
        struct MIB_TCPROW_OWNER_PID
        {
            public uint state;       // حالة الاتصال (LISTEN, ESTABLISHED, etc)
            public uint localAddr;   // عنوان IP المحلي
            public uint localPort;   // البورت المحلي
            public uint remoteAddr;  // عنوان IP البعيد
            public uint remotePort;  // البورت البعيد
            public uint owningPid;   // PID الخاص بالعملية
        }

        // بنية صف UDP مع PID
        [StructLayout(LayoutKind.Sequential)]
        struct MIB_UDPROW_OWNER_PID
        {
            public uint localAddr;   // عنوان IP المحلي
            public uint localPort;   // البورت المحلي
            public uint owningPid;   // PID الخاص بالعملية
        }

        // استدعاء دوال WinAPI لجلب جدول TCP
        [DllImport("iphlpapi.dll", SetLastError = true)]
        static extern uint GetExtendedTcpTable(
            IntPtr pTcpTable,
            ref int pdwSize,
            bool bOrder,
            int ulAf,
            TCP_TABLE_CLASS tableClass,
            uint reserved = 0
        );

        // استدعاء دوال WinAPI لجلب جدول UDP
        [DllImport("iphlpapi.dll", SetLastError = true)]
        static extern uint GetExtendedUdpTable(
            IntPtr pUdpTable,
            ref int pdwSize,
            bool bOrder,
            int ulAf,
            UDP_TABLE_CLASS tableClass,
            uint reserved = 0
        );

        const int AF_INET = 2; // IPv4
        #endregion

        // كلاس مساعد لتخزين معلومات الاتصال
        class ConnectionInfo
        {
            public int PID { get; set; }          // رقم العملية
            public string ProcessName { get; set; } // اسم العملية
            public string Protocol { get; set; }  // TCP أو UDP
            public string Local { get; set; }     // العنوان المحلي + البورت
            public string Remote { get; set; }    // العنوان البعيد + البورت (UDP غالبًا "-")
            public string State { get; set; }     // حالة الاتصال
        }

        // عند تحميل النموذج
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProcesses(); // تحميل العمليات
            LoadPorts();     // تحميل البورتات المفتوحة
        }

        // زر تحديث القوائم
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProcesses();
            LoadPorts();
        }

        // زر إنهاء العملية المحددة
        private void btnKill_Click(object sender, EventArgs e)
        {
            // يتم السماح بالقتل فقط من تبويب العمليات
            if (tabControl1.SelectedIndex == 0)
            {
                if (dgvProcesses.SelectedRows.Count > 0)
                {
                    int pid = Convert.ToInt32(dgvProcesses.SelectedRows[0].Cells["colPID"].Value);
                    try
                    {
                        Process.GetProcessById(pid).Kill(); // إنهاء العملية
                        MessageBox.Show("✅ Process terminated successfully!");
                        LoadProcesses(); // تحديث قائمة العمليات بعد القتل
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("⚠️ Error: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("يمكنك إنهاء العمليات فقط من التبويب الأول.");
            }
        }

        // دالة تحميل العمليات إلى الجدول
        void LoadProcesses()
        {
            dgvProcesses.Rows.Clear(); // تفريغ الجدول
            foreach (Process p in Process.GetProcesses()) // لكل عملية في النظام
            {
                string path = "N/A";
                try { path = p.MainModule.FileName; } catch { } // محاولة الحصول على مسار الملف التنفيذي
                dgvProcesses.Rows.Add(p.ProcessName, p.Id, path); // إضافة الصف
            }
        }

        // دالة تحميل البورتات (TCP + UDP)
        void LoadPorts()
        {
            dgvPorts.Rows.Clear();
            var allConnections = new List<ConnectionInfo>();
            allConnections.AddRange(GetTcpConnections()); // إضافة TCP
            allConnections.AddRange(GetUdpConnections()); // إضافة UDP

            foreach (var c in allConnections)
            {
                dgvPorts.Rows.Add(c.Protocol, c.Local, c.Remote, c.PID, c.ProcessName);
            }
        }

        // دالة الحصول على اتصالات TCP مع PID
        List<ConnectionInfo> GetTcpConnections()
        {
            var result = new List<ConnectionInfo>();
            int size = 0;

            // استدعاء أولي للحصول على حجم الذاكرة المطلوب
            GetExtendedTcpTable(IntPtr.Zero, ref size, true, AF_INET, TCP_TABLE_CLASS.TCP_TABLE_OWNER_PID_ALL);

            IntPtr buffer = Marshal.AllocHGlobal(size); // حجز الذاكرة
            try
            {
                uint res = GetExtendedTcpTable(buffer, ref size, true, AF_INET, TCP_TABLE_CLASS.TCP_TABLE_OWNER_PID_ALL);
                if (res != 0) return result;

                int rowSize = Marshal.SizeOf(typeof(MIB_TCPROW_OWNER_PID));
                int entries = Marshal.ReadInt32(buffer); // عدد الصفوف
                IntPtr rowPtr = IntPtr.Add(buffer, 4);    // مؤشر الصف الأول

                for (int i = 0; i < entries; i++)
                {
                    var row = Marshal.PtrToStructure<MIB_TCPROW_OWNER_PID>(rowPtr);
                    var ci = new ConnectionInfo
                    {
                        PID = (int)row.owningPid,
                        Protocol = "TCP",
                        Local = $"{new IPAddress(row.localAddr)}:{((row.localPort >> 8) | ((row.localPort & 0xFF) << 8))}",
                        Remote = $"{new IPAddress(row.remoteAddr)}:{((row.remotePort >> 8) | ((row.remotePort & 0xFF) << 8))}",
                        State = row.state.ToString()
                    };
                    try { ci.ProcessName = Process.GetProcessById(ci.PID).ProcessName; } catch { ci.ProcessName = "<unknown>"; }
                    result.Add(ci);
                    rowPtr = IntPtr.Add(rowPtr, rowSize); // الذهاب للصف التالي
                }
            }
            finally
            {
                Marshal.FreeHGlobal(buffer); // تحرير الذاكرة
            }

            return result;
        }

        // دالة الحصول على اتصالات UDP مع PID
        List<ConnectionInfo> GetUdpConnections()
        {
            var result = new List<ConnectionInfo>();
            int size = 0;

            // استدعاء أولي للحصول على حجم الذاكرة المطلوب
            GetExtendedUdpTable(IntPtr.Zero, ref size, true, AF_INET, UDP_TABLE_CLASS.UDP_TABLE_OWNER_PID);

            IntPtr buffer = Marshal.AllocHGlobal(size); // حجز الذاكرة
            try
            {
                uint res = GetExtendedUdpTable(buffer, ref size, true, AF_INET, UDP_TABLE_CLASS.UDP_TABLE_OWNER_PID);
                if (res != 0) return result;

                int rowSize = Marshal.SizeOf(typeof(MIB_UDPROW_OWNER_PID));
                int entries = Marshal.ReadInt32(buffer);
                IntPtr rowPtr = IntPtr.Add(buffer, 4);

                for (int i = 0; i < entries; i++)
                {
                    var row = Marshal.PtrToStructure<MIB_UDPROW_OWNER_PID>(rowPtr);
                    var ci = new ConnectionInfo
                    {
                        PID = (int)row.owningPid,
                        Protocol = "UDP",
                        Local = $"{new IPAddress(row.localAddr)}:{((row.localPort >> 8) | ((row.localPort & 0xFF) << 8))}",
                        Remote = "-",
                        State = "LISTEN"
                    };
                    try { ci.ProcessName = Process.GetProcessById(ci.PID).ProcessName; } catch { ci.ProcessName = "<unknown>"; }
                    result.Add(ci);
                    rowPtr = IntPtr.Add(rowPtr, rowSize); // الذهاب للصف التالي
                }
            }
            finally
            {
                Marshal.FreeHGlobal(buffer); // تحرير الذاكرة
            }

            return result;
        }
    }
}
