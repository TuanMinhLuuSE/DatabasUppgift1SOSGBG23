using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaserUppgift1VSTuanMinhLuu
{
    public class RenterInfo
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }

        public RenterInfo(string firstName, string lastName, string address, int zipCode, string city, string country, string email)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            this.ZipCode = zipCode;
            this.City = city;
            this.Country = country;
            this.Email = email;
        }
    }
}
