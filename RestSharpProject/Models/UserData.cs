using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpProject.Models
{
    public class UserData
    {
        public string title { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public Nullable<int> phone { get; set; }

        public string[] technologies = new string[3];

        public string password { get; set; }

        public string login { get; set; }

        public string githubLink { get; set; }


        public UserData(string title, string name, string surname, string email, Nullable<int> phone, string[] technology, string password, string login, string githubLink)
        {
            this.title = title;
            this.firstName = name;
            this.lastName = surname;
            this.email = email;
            this.phone = phone;         
            this.technologies = technology;
            this.password = password;
            this.login = login;
            this.githubLink = githubLink;
        }

        public static string GenerateEmailAdress()
        {
            Random rand = new Random();
            string email = $"example{rand.Next(0, 10000)}@email.com";

            return email;
        }

        public static string GenerateLogin()
        {
            Random rand = new Random();
            string login = $"exampleLogin{rand.Next(0, 10000)}";

            return login;
        }

        public static string GenerateGithubLink()
        {
            Random rand = new Random();
            string githubLink = "https://github.com/example" + $"{rand.Next(0, 10000)}";
            return githubLink;
        }
    }
}
