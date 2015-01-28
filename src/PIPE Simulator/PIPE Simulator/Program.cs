using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using System.IO;

namespace PIPE_Simulator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DirectoryInfo di = new DirectoryInfo(Application.StartupPath);
            FileInfo[] ff = di.GetFiles("*.txt");
            if (ff.Length != 0)
            {
                foreach (FileInfo fi in ff)
                    fi.Delete();
            }
            FileInfo[] fff = di.GetFiles("*.asm");
            if (fff.Length != 0)
            {
                foreach (FileInfo ffi in fff)
                    ffi.Delete();
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            Application.Run(new Form1());
        }
    }
}
