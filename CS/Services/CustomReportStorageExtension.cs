using System.IO;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Extensions;
// ...

namespace AdvancedSupportForEnums {
    public partial class Form1 {
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
