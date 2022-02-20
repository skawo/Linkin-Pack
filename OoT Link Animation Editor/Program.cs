using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OoT_Link_Animation_Editor
{
    static class Program
    {
        public static MiscUtil.Conversion.BigEndianBitConverter BEConverter = new MiscUtil.Conversion.BigEndianBitConverter();

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
