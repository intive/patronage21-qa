using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpProject.Models
{
    public class UserData
    {
        string Title { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
        string Email { get; set; }
        int Phone { get; set; }

        string[] arrayOfTechnologies = new string[3];

        string Password { get; set; }

        string Login { get; set; }

        string GithubLink { get; set; }


        public UserData(string title, string name, string surname, string email, int phone, string[] technologies, string password, string login, string githubLink)
        {
            this.Title = title;
            this.Name = name;
            this.Surname = surname;
            this.Email = email;
            this.Phone = phone;         
            this.arrayOfTechnologies = technologies;
            this.Password = password;
            this.Login = login;
            this.GithubLink = githubLink;
        }
    }
}
