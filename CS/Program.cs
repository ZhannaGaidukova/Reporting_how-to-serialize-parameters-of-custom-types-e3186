using DevExpress.Xpo;
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
            InitPayGrades();
            Application.Run(new Form1());
        }
        private static void InitPayGrades() {
            new PayGrade { High = 200000000, Low = 1000000000, Name = "Billionaire", Oid = 1 }.Save();
            new PayGrade { High = 1000000000, Low = 250000, Name = "Good", Oid = 2 }.Save();
            new PayGrade { High = 200000, Low = 60000, Name = "Decent", Oid = 3 }.Save();
            new PayGrade { High = 500, Low = 1, Name = "Low", Oid = 4 }.Save();
        }
    }
}
