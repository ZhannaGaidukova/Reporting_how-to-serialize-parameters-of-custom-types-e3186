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
            InitPayGrades();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
			DevExpress.Xpo.XpoDefault.DataLayer = new DevExpress.Xpo.SimpleDataLayer(new DevExpress.Xpo.DB.InMemoryDataStore());
            Application.Run(new Form1());
        }
        public static XPCollection<PayGrade> PayGrades { get; } = new XPCollection<PayGrade>();

        private static void InitPayGrades() {
            XpoDefault.DataLayer = new SimpleDataLayer(new DevExpress.Xpo.DB.InMemoryDataStore());
            PayGrades.Add(new PayGrade { High = 200000000, Low = 1000000000, Name = "Billionaire", Oid = 1 });
            PayGrades.Add(new PayGrade { High = 1000000000, Low = 250000, Name = "Good", Oid = 2 });
            PayGrades.Add(new PayGrade { High = 200000, Low = 60000, Name = "Decent", Oid = 3 });
            PayGrades.Add(new PayGrade { High = 500, Low = 1, Name = "Low", Oid = 4 });
            PayGrades.Session.Save(PayGrades);
        }
    }
}
