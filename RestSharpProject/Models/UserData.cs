using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpProject.Models
{
    public class UserData
    {
        string Gender { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
        string Email { get; set; }
        string Phone { get; set; }
        string Password { get; set; }

        public UserData(string gender, string name, string surname, string email, string phone, string password)
        {
            this.Gender = gender;
            this.Name = name;
            this.Surname = surname;
            this.Email = email;
            this.Phone = phone;
            this.Password = password;
        }
    }
}
