using System;
using DevExpress.Xpo;

namespace AdvancedSupportForEnums {
    public enum PersonGender { Mr, Mrs }
    public class PayGrade : XPObject {
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public string Name { get; set; }
        public override string ToString() => Oid.ToString();
    }
    public class Person : XPObject {
        public PersonGender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Person Owner { get; set; }
        public string FirstName { get; set; }
        public Team Team { get; set; }
        public PayGrade Pay { get; set; }
        public override string ToString() => Oid.ToString();
    }

    public class Team : XPObject {
        public string Name { get; set; }
    }
}
