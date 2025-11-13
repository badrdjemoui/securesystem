using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace securesystem
{
    /// <summary>
    /// الكلاس الرئيسي للبرنامج.
    /// يحتوي على نقطة البداية Main() لتشغيل التطبيق.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// نقطة البداية الرئيسية للتطبيق.
        /// يجب أن تكون محددة بـ STAThread لأنها تطبيق واجهة مستخدم.
        /// </summary>
        [STAThread] // متطلب لتطبيقات WinForms لتفعيل الـ Single Threaded Apartment
        static void Main()
        {
            // تفعيل التصميم الحديث لعناصر التحكم في الفورم
            Application.EnableVisualStyles();

            // استخدام نظام الرسم المتوافق مع النصوص القديم، غالباً false في التطبيقات الحديثة
            Application.SetCompatibleTextRenderingDefault(false);

            // تشغيل الفورم الرئيسي للتطبيق
            // Form1 هو الفورم الأساسي الذي يظهر عند بدء البرنامج
            Application.Run(new Form1());
        }
    }
}
