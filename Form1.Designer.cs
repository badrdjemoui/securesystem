namespace securesystem
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// متغيرات الـ Designer
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// تنظيف الموارد عند الإغلاق
        /// </summary>
        /// <param name="disposing">true إذا كانت الموارد المدارة يجب التخلص منها</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose(); // تحرير الموارد
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Method to initialize all UI components
        /// تهيئة جميع عناصر واجهة المستخدم
        /// </summary>
        private void InitializeComponent()
        {
            // إنشاء التبويبات الرئيسية
            this.tabControl1 = new System.Windows.Forms.TabControl();

            // تبويب عرض العمليات
            this.tabPageProcesses = new System.Windows.Forms.TabPage();

            // DataGridView لعرض العمليات
            this.dgvProcesses = new System.Windows.Forms.DataGridView();
            this.colProcName = new System.Windows.Forms.DataGridViewTextBoxColumn(); // اسم العملية
            this.colPID = new System.Windows.Forms.DataGridViewTextBoxColumn();      // PID العملية
            this.colPath = new System.Windows.Forms.DataGridViewTextBoxColumn();     // مسار الملف التنفيذي

            // تبويب عرض البورتات
            this.tabPagePorts = new System.Windows.Forms.TabPage();

            // DataGridView لعرض البورتات
            this.dgvPorts = new System.Windows.Forms.DataGridView();
            this.colProtocol = new System.Windows.Forms.DataGridViewTextBoxColumn(); // البروتوكول TCP/UDP
            this.colLocalAddr = new System.Windows.Forms.DataGridViewTextBoxColumn(); // العنوان المحلي
            this.colPort = new System.Windows.Forms.DataGridViewTextBoxColumn();      // البورت المحلي
            this.colPidPort = new System.Windows.Forms.DataGridViewTextBoxColumn();   // PID للعملية
            this.colProcPort = new System.Windows.Forms.DataGridViewTextBoxColumn();  // اسم العملية

            // زر تحديث القوائم
            this.btnRefresh = new System.Windows.Forms.Button();

            // زر إنهاء العملية المحددة
            this.btnKill = new System.Windows.Forms.Button();

            // =========================
            // إعداد TabControl الرئيسي
            // =========================
            this.tabControl1.Controls.Add(this.tabPageProcesses); // إضافة تبويب العمليات
            this.tabControl1.Controls.Add(this.tabPagePorts);     // إضافة تبويب البورتات
            this.tabControl1.Location = new System.Drawing.Point(12, 12); // موقعه داخل الفورم
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0; // التبويب الافتراضي
            this.tabControl1.Size = new System.Drawing.Size(760, 380);
            this.tabControl1.TabIndex = 0;

            // =========================
            // تبويب العمليات (Processes)
            // =========================
            this.tabPageProcesses.Controls.Add(this.dgvProcesses); // إضافة الجدول للتبويب
            this.tabPageProcesses.Location = new System.Drawing.Point(4, 24);
            this.tabPageProcesses.Name = "tabPageProcesses";
            this.tabPageProcesses.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProcesses.Size = new System.Drawing.Size(752, 352);
            this.tabPageProcesses.TabIndex = 0;
            this.tabPageProcesses.Text = "Processes";
            this.tabPageProcesses.UseVisualStyleBackColor = true;

            // =========================
            // DataGridView للعمليات
            // =========================
            this.dgvProcesses.AllowUserToAddRows = false;  // منع إضافة صفوف يدوياً
            this.dgvProcesses.AllowUserToDeleteRows = false; // منع الحذف يدوياً
            this.dgvProcesses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProcesses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colProcName,
                this.colPID,
                this.colPath
            });
            this.dgvProcesses.Dock = System.Windows.Forms.DockStyle.Fill; // ملئ التبويب بالكامل
            this.dgvProcesses.Location = new System.Drawing.Point(3, 3);
            this.dgvProcesses.Name = "dgvProcesses";
            this.dgvProcesses.ReadOnly = true; // لا يمكن تعديل البيانات
            this.dgvProcesses.RowHeadersVisible = false; // إخفاء الهيدر الجانبي
            this.dgvProcesses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect; // تحديد صف كامل
            this.dgvProcesses.Size = new System.Drawing.Size(746, 346);
            this.dgvProcesses.TabIndex = 0;

            // =========================
            // أعمدة DataGridView العمليات
            // =========================
            this.colProcName.HeaderText = "Process Name"; // عنوان العمود
            this.colProcName.Name = "colProcName";
            this.colProcName.ReadOnly = true;
            this.colProcName.Width = 180;

            this.colPID.HeaderText = "PID";
            this.colPID.Name = "colPID";
            this.colPID.ReadOnly = true;
            this.colPID.Width = 80;

            this.colPath.HeaderText = "Path";
            this.colPath.Name = "colPath";
            this.colPath.ReadOnly = true;
            this.colPath.Width = 450;

            // =========================
            // تبويب البورتات (Ports)
            // =========================
            this.tabPagePorts.Controls.Add(this.dgvPorts);
            this.tabPagePorts.Location = new System.Drawing.Point(4, 24);
            this.tabPagePorts.Name = "tabPagePorts";
            this.tabPagePorts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePorts.Size = new System.Drawing.Size(752, 352);
            this.tabPagePorts.TabIndex = 1;
            this.tabPagePorts.Text = "Ports";
            this.tabPagePorts.UseVisualStyleBackColor = true;

            // =========================
            // DataGridView للبورتات
            // =========================
            this.dgvPorts.AllowUserToAddRows = false;
            this.dgvPorts.AllowUserToDeleteRows = false;
            this.dgvPorts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPorts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colProtocol,
                this.colLocalAddr,
                this.colPort,
                this.colPidPort,
                this.colProcPort
            });
            this.dgvPorts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPorts.Location = new System.Drawing.Point(3, 3);
            this.dgvPorts.Name = "dgvPorts";
            this.dgvPorts.ReadOnly = true;
            this.dgvPorts.RowHeadersVisible = false;
            this.dgvPorts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPorts.Size = new System.Drawing.Size(746, 346);
            this.dgvPorts.TabIndex = 0;

            // =========================
            // أعمدة DataGridView البورتات
            // =========================
            this.colProtocol.HeaderText = "Protocol";
            this.colProtocol.Name = "colProtocol";
            this.colProtocol.ReadOnly = true;
            this.colProtocol.Width = 80;

            this.colLocalAddr.HeaderText = "Local Address";
            this.colLocalAddr.Name = "colLocalAddr";
            this.colLocalAddr.ReadOnly = true;
            this.colLocalAddr.Width = 200;

            this.colPort.HeaderText = "Port";
            this.colPort.Name = "colPort";
            this.colPort.ReadOnly = true;
            this.colPort.Width = 80;

            this.colPidPort.HeaderText = "PID";
            this.colPidPort.Name = "colPidPort";
            this.colPidPort.ReadOnly = true;
            this.colPidPort.Width = 80;

            this.colProcPort.HeaderText = "Process Name";
            this.colProcPort.Name = "colProcPort";
            this.colProcPort.ReadOnly = true;
            this.colProcPort.Width = 280;

            // =========================
            // زر التحديث (Refresh)
            // =========================
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Location = new System.Drawing.Point(12, 400);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(150, 35);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "🔄 تحديث الآن";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // =========================
            // زر إنهاء العملية (Kill Process)
            // =========================
            this.btnKill.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnKill.Location = new System.Drawing.Point(622, 400);
            this.btnKill.Name = "btnKill";
            this.btnKill.Size = new System.Drawing.Size(150, 35);
            this.btnKill.TabIndex = 2;
            this.btnKill.Text = "❌ إنهاء العملية";
            this.btnKill.UseVisualStyleBackColor = true;
            this.btnKill.Click += new System.EventHandler(this.btnKill_Click);

            // =========================
            // إعدادات الفورم Form1
            // =========================
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 451); // حجم النافذة
            this.Controls.Add(this.btnKill);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.tabControl1); // إضافة التبويبات للفورم
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog; // حجم ثابت
            this.MaximizeBox = false; // منع تكبير النافذة
            this.Name = "Form1";
            this.Text = "🛡 System Monitor - Process & Port Viewer"; // عنوان النافذة
            this.Load += new System.EventHandler(this.Form1_Load); // حدث التحميل

            // =========================
            // إنهاء تهيئة التبويبات والـ DataGridViews
            // =========================
            this.tabControl1.ResumeLayout(false);
            this.tabPageProcesses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcesses)).EndInit();
            this.tabPagePorts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPorts)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        // =========================
        // تعريف عناصر الفورم
        // =========================
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageProcesses;
        private System.Windows.Forms.DataGridView dgvProcesses;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProcName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPath;
        private System.Windows.Forms.TabPage tabPagePorts;
        private System.Windows.Forms.DataGridView dgvPorts;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProtocol;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocalAddr;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPort;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPidPort;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProcPort;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnKill;
    }
}
