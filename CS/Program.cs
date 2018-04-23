using System;
using System.Windows.Forms;

namespace AdvancedSupportForEnums {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
			DevExpress.Xpo.XpoDefault.DataLayer = new DevExpress.Xpo.SimpleDataLayer(new DevExpress.Xpo.DB.InMemoryDataStore());
            Application.Run(new Form1());
        }
    }
}
