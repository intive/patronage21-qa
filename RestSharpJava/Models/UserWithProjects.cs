using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpProject.Models
{
    public class UserWithProjects
    {
        public string login { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string gitHubUrl { get; set; }
        public string bio { get; set; }
        public List<Projects> projects { get; set; }

        public UserWithProjects(string login, string firstName, string lastName, string email, string phoneNumber, string gitHubUrl, string bio, List<Projects> projects)
        {
            this.login = login;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.gitHubUrl = gitHubUrl;
            this.bio = bio;
            this.projects = projects;
        }
    }
        public class Projects
        {
            public string name { get; set; }
            public string role { get; set; }

            public Projects(string name, string role)
            {
                this.role = role;
                this.name = name;
            }
        }
    }


