using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL_Test_Task.DTO
{
    public class Customer
    {
        public int Id { get; set; }
        public string Cpny { get; set; }
        public int GreetingId { get; set; }
        public string GreetingTxt { get; set; }
        public string GreetingTxt1 { get; set; }
        public string GreetingTxt2 { get; set; }
        public string GreetingTxt3 { get; set; }
        public string GreetingTxt4 { get; set; }
        public string Title { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Street { get; set; }
        public string CountryCode { get; set; }
        public string CountryTxt { get; set; }
        public string CountryTxt1 { get; set; }
        public string CountryTxt2 { get; set; }
        public string CountryTxt3 { get; set; }
        public string CountryTxt4 { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public IEnumerable<CustomerContact> CustomerContacts { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime FirstContact { get; set; }

        public Customer()
        {
            GreetingTxt = GreetingTxt1;
        }

    }
}
