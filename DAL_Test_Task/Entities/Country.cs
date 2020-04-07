using System;
using System.Collections.Generic;

namespace DAL_Test_Task.Entities
{
    public partial class Country
    {
        public Country()
        {
            Person = new HashSet<Person>();
        }

        public string Code { get; set; }
        public string Txt1 { get; set; }
        public string Txt2 { get; set; }
        public string Txt3 { get; set; }
        public string Txt4 { get; set; }
        public string IntDialCode { get; set; }
        public sbyte AddrFormatId { get; set; }
        public sbyte IsVatIncluded { get; set; }
        public sbyte Active { get; set; }

        public virtual ICollection<Person> Person { get; set; }
    }
}
