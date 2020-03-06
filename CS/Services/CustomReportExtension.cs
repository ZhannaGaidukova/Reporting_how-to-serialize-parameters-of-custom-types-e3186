using System;
using System.Collections.Generic;
using DevExpress.Xpo;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Extensions;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils;
using DevExpress.Data;
using DevExpress.XtraReports.Parameters;
using System.Linq;
using DevExpress.Data.Filtering;
// ...

namespace AdvancedSupportForEnums {
    public partial class Form1 {
        class CustomReportExtension : ReportDesignExtension {
            public override Type[] GetEditableDataTypes() {
                return new Type[] { typeof(Team), typeof(PayGrade) };
            }
            public override void AddParameterTypes(IDictionary<Type, string> dictionary) {
                base.AddParameterTypes(dictionary);
                dictionary.Add(typeof(PersonGender), "Person's Gender");
                dictionary.Add(typeof(PayGrade), "Person's Pay");                
            }
            [Obsolete]
            public override Type[] GetSerializableDataTypes() {
                return new Type[] { typeof(PayGrade) };
            }
            private RepositoryItem CreateRepositoryItem() {
                RepositoryItemLookUpEdit item = new RepositoryItemLookUpEdit();
                item.NullText = "[Select Pay Grade]";
                item.DataSource = Program.PayGrades;
                item.DisplayMember = "Name";
                item.Columns.Add(new LookUpColumnInfo("Name"));
                item.Columns.Add(new LookUpColumnInfo("Low", "Low", 40, FormatType.Numeric, "c", true, HorzAlignment.Near));
                item.Columns.Add(new LookUpColumnInfo("High", "High", 40, FormatType.Numeric, "c", true, HorzAlignment.Near));
                return item;
            }
            protected override RepositoryItem CreateRepositoryItem(DataColumnInfo dataColumnInfo, Type dataType, XtraReport report) {
                return CreateRepositoryItem();
                }
            protected override RepositoryItem CreateRepositoryItem(Parameter parameter, Type dataType, XtraReport report) {
                return CreateRepositoryItem();
                }
            protected override bool CanSerialize(object data) {
                if (data?.GetType() == typeof(PayGrade))
                    return true;
                if (data is PersonGender)
                    return true;
                return base.CanSerialize(data);
            }
            protected override string SerializeData(object data, XtraReport report) {
                if (data?.GetType() == typeof(PayGrade))
                    return ((XPObject)data).Oid.ToString();                
                if (data?.GetType() == typeof(PersonGender))
                    return Enum.GetName(typeof(PersonGender), data);
                return base.SerializeData(data, report);
            }
            protected override bool CanDeserialize(string value, string typeName) {
                if (typeName == typeof(PayGrade).FullName)
                    return true;                
                if (typeof(PersonGender).FullName == typeName)
                    return true;
                return base.CanDeserialize(value, typeName); 
            }
            protected override object DeserializeData(string value, string typeName, XtraReport report) {
                //if (typeName == typeof(PayGrade).FullName) {
                //    int oif = Convert.ToInt32(value);
                //    return Program.PayGrades.Session.GetObjectByKey(typeof(PayGrade), oif);
                //}
                //if (typeName == typeof(PersonGender).FullName) {
                //    return Enum.Parse(typeof(PersonGender), value);
                //}
                //return base.DeserializeData(value, typeName, report);

                if (typeName == typeof(PayGrade).FullName) {
                    int oid = -1;
                    Int32.TryParse(value, out oid);
                    if (oid > 0)
                        return Program.PayGrades.Session.GetObjectByKey(typeof(PayGrade), oid);
                    else {
                        //PayGrade payGrade = (PayGrade)Program.PayGrades.Session.FindObject(typeof(PayGrade), CriteriaOperator.Parse($"Name='{0}'", value));
                        PayGrade payGrade = (PayGrade)Program.PayGrades.FirstOrDefault(x => x.Name == value);
                        return payGrade;
                    }
                }
                if (typeName == typeof(PersonGender).FullName) {
                    return Enum.Parse(typeof(PersonGender), value);
                }
                return base.DeserializeData(value, typeName, report);
            }         
        }
    }
}
