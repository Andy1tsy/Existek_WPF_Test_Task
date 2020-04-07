using System;
using System.Collections.Generic;

namespace DAL_Test_Task.Entities
{
    public partial class PersonContact
    {
        public int PersonId { get; set; }
        public int PersonContactId { get; set; }
        public int ContactTypeId { get; set; }
        public string Txt { get; set; }
        public string Notes { get; set; }
        public sbyte Active { get; set; }

        public virtual Person Person { get; set; }
    }
}
