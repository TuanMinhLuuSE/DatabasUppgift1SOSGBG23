using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaserUppgift1VSTuanMinhLuu
{
    public class RentalAccount
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public RentalAccount(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
    }
}
