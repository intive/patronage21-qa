using System.Collections.Generic;

namespace patronage21_qa_appium.Models
{
    public class GetUserResponse
    {
        public User user { get; set; }

        public GetUserResponse(User user)
        {
            this.user = user;
        }
    }

    public class User
    {
        public string login { get; set; }
        public string image { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string bio { get; set; }
        public List<Projects> projects { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string gitHubUrl { get; set; }
        public string status { get; set; }

        public User(string login, string image, string firstName, string lastName, string email, string phoneNumber, string gitHubUrl, string bio, string status, List<Projects> projects)
        {
            this.login = login;
            this.image = image;
            this.firstName = firstName;
            this.lastName = lastName;
            this.bio = bio;
            this.projects = projects;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.gitHubUrl = gitHubUrl;
            this.status = status;
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