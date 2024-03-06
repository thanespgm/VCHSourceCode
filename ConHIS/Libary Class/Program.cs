using System;
using System.Windows.Forms;
using System.Threading; //

namespace ConHIS
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            bool InstructionCountOne = false;

            using (Mutex mtex = new Mutex(true, "MyRunningApp", out InstructionCountOne))
            {
                if (InstructionCountOne)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new FrmMain());
                    mtex.ReleaseMutex();
                    //Application.Run(new PrescriptionPage());
                }
                else
                {
                    MessageBox.Show("ขณะนี้โปรเเกรม Interface เปิดใช้งานเเล้ว ไม่สามารถเปิดซ้ำได้", "แจ้งเตือนสถานะการทำงานของโปรเเกรม", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
           
        }
    }
}