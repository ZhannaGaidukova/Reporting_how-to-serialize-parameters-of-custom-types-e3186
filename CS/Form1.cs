using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using DevExpress.Xpo;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Extensions;
// ...

namespace AdvancedSupportForEnums {
    public partial class Form1 : Form {
        static Form1() {
            ReportDesignExtension.RegisterExtension(new CustomReportExtension(), TeamParameterName);
            CustomReportStorageExtension.RegisterExtensionGlobal(new CustomReportStorageExtension());
        }

        private XtraReport report;
        private const string TeamParameterName = "Team";

        public Form1() {
            InitializeComponent();

            FillDataSource();
            XPCollection<Person> dataSource = new XPCollection<Person>();

            report = new XtraReport();
            report.DataSource = dataSource;

            ReportDesignExtension.AssociateReportWithExtension(report, TeamParameterName);
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
                    Gender = PersonGender.Mr
                }.Save();
                new Person() {
                    FirstName = "Name 1, team2",
                    Team = team2,
                    DateOfBirth = DateTime.Now,
                    Gender = PersonGender.Mrs
                }.Save();
                new Person() {
                    FirstName = "Name 1, team3",
                    Team = team3,
                    DateOfBirth = DateTime.Now,
                    Gender = PersonGender.Mrs
                }.Save();
                new Person() {
                    FirstName = "Name 2, team1",
                    Team = team1,
                    DateOfBirth = DateTime.Now.AddYears(-1),
                    Gender = PersonGender.Mr
                }.Save();
                new Person() {
                    FirstName = "Name 2, team2",
                    Team = team2,
                    DateOfBirth = DateTime.Now,
                    Gender = PersonGender.Mrs
                }.Save();
                new Person() {
                    FirstName = "Name 2, team3",
                    Team = team3,
                    DateOfBirth = DateTime.Now,
                    Gender = PersonGender.Mrs
                }.Save();
            }
        }

        private void btnDesigner_Click(object sender, EventArgs e) {
            report.ShowDesignerDialog();
        }

        class CustomReportExtension : ReportDesignExtension {
            XPCollection<Team> repositoryDataSource = new XPCollection<Team>();
            public CustomReportExtension() {
            }

            public override void AddParameterTypes(IDictionary<Type, string> dictionary) {
                dictionary.Add(typeof(PersonGender), "Person's Gender");
            }

            protected override bool CanSerialize(object data) {
                return data is PersonGender;
            }
            protected override string SerializeData(object data, XtraReport report) {
                return Enum.GetName(typeof(PersonGender), data);
            }
            protected override bool CanDeserialize(string value, string typeName) {
                return typeof(PersonGender).FullName == typeName;
            }
            protected override object DeserializeData(string value, string typeName, XtraReport report) {
                return Enum.Parse(typeof(PersonGender), value);
            }
        }

        class CustomReportStorageExtension : ReportStorageExtension {
            public override void SetData(XtraReport report, Stream stream) {
                report.SaveLayoutToXml(stream);
            }
            public override void SetData(XtraReport report, string url) {
                report.SaveLayoutToXml(url);
            }
        }

    }
}
