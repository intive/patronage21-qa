using System.Collections.Generic;

namespace patronage21_qa_appium.Models
{
    public class PostUserRequest
    {
        public string firstName { get; set; }
        public string login { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string gitHubUrl { get; set; }
        public string gender { get; set; }
        public List<Group> groups { get; set; }

        public PostUserRequest(string firstName, string login, string lastName, string email, string phoneNumber, string gitHubUrl, string gender, List<Group> groups)
        {
            this.firstName = firstName;
            this.login = login;
            this.lastName = lastName;
            this.gender = gender;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.gitHubUrl = gitHubUrl;
            this.groups = groups;
        }
    }

    public class Group
    {
        public string name { get; set; }

        public Group(string name)
        {
            this.name = name;
        }
    }
}