using System;
using System.Windows.Forms;
using DevExpress.Xpo;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Extensions;
using System.Linq;
using DevExpress.Data.Filtering;
// ...

namespace AdvancedSupportForEnums {
    public partial class Form1 : Form {
        static Form1() {
            ReportDesignExtension.RegisterExtension(new CustomReportExtension(), PersonEnums);
            CustomReportStorageExtension.RegisterExtensionGlobal(new CustomReportStorageExtension());
        }

        private XtraReport report;
        private const string PersonEnums = "PersonEnums";

        public Form1() {
            InitializeComponent();

            FillDataSource();
            XPCollection<Person> dataSource = new XPCollection<Person>();
         
            report = new XtraReport();
            report.DataSource = dataSource;

            ReportDesignExtension.AssociateReportWithExtension(report, PersonEnums);
        }

        private void FillDataSource() {
            if (new XPCollection<Person>().Count < 6) {
                Team team1 = new Team() { Name = "Team 1" };
                team1.Save();
                Team team2 = new Team() { Name = "Team 2" };
                team2.Save();
                Team team3 = new Team() { Name = "Team 3" };
                team3.Save();

                new Person() {
                    FirstName = "Name 1, team1",
                    Team = team1,
                    DateOfBirth = DateTime.Now.AddYears(-1),
                    Gender = PersonGender.Mr,
                    Pay = GetPayType("Billionaire")
                }.Save();
                new Person() {
                    FirstName = "Name 1, team2",
                    Team = team2,
                    DateOfBirth = DateTime.Now,
                    Gender = PersonGender.Mrs,
                    Pay = GetPayType("Good")
                }.Save();
                new Person() {
                    FirstName = "Name 1, team3",
                    Team = team3,
                    DateOfBirth = DateTime.Now,
                    Gender = PersonGender.Mrs,
                    Pay = GetPayType("Low")
                }.Save();
                new Person() {
                    FirstName = "Name 2, team1",
                    Team = team1,
                    DateOfBirth = DateTime.Now.AddYears(-1),
                    Gender = PersonGender.Mr,
                    Pay = GetPayType("Good")
                }.Save();
                new Person() {
                    FirstName = "Name 2, team2",
                    Team = team2,
                    DateOfBirth = DateTime.Now,
                    Gender = PersonGender.Mrs,
                    Pay = GetPayType("Decent")
                }.Save();
                new Person() {
                    FirstName = "Name 2, team3",
                    Team = team3,
                    DateOfBirth = DateTime.Now,
                    Gender = PersonGender.Mrs,
                    Pay = GetPayType("Low")
                }.Save();
            }
        }

        private static PayGrade GetPayType(string payTypeName) {
            return (PayGrade)XpoDefault.Session.FindObject(typeof(PayGrade), CriteriaOperator.Parse("Name=?", payTypeName));            
        }

        private void btnDesigner_Click(object sender, EventArgs e) {
            report.ShowDesignerDialog();
        }
    }
}
