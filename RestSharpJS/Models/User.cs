using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpProject.Models
{
    public class User
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public Nullable<int> phone { get; set; }

        public List<string> technologies { get; set; }

        public string password { get; set; }

        public string login { get; set; }

        public string githubLink { get; set; }


        public User( string name, string surname, string email, Nullable<int> phone, List<string> technology, string password, string login, string githubLink)
        {
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
            string login = $"userLogin{rand.Next(0, 10000)}";

            return login;
        }

        public static string GenerateGithubLink()
        {
            Random rand = new Random();
            string githubLink = "https://github.com/example" + $"{rand.Next(0, 10000)}";
            return githubLink;
        }

        public User CreateUser(User user)
        {
            if (user.firstName == null)
                user.firstName = "Jan";
            if (user.lastName == null)
                user.lastName = "Kowalski";
            if (user.email == null)
                user.email = GenerateEmailAdress();
            if (user.phone == null)
                user.phone = 123456789;
            if (user.technologies == null)
                user.technologies = new List<string>() { "QA" };
            if (user.password == null)
                user.password = "randomPassword6@";
            if (user.login == null)
                user.login = GenerateLogin();
            if (user.githubLink == null)
                user.githubLink = GenerateGithubLink();

            user = new User(firstName, lastName, email, phone, technologies, password, login, githubLink);

            return user;
        }
    }
}
