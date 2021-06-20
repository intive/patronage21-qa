using System.Collections.Generic;

namespace patronage21_qa_appium.Models
{
    public class GetUsersResponse
    {
        public List<GetUsersUser> users { get; set; }

        public GetUsersResponse(List<GetUsersUser> users)
        {
            this.users = users;
        }
    }

    public class GetUsersUser
    {
        public string login { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string image { get; set; }
        public string status { get; set; }

        public GetUsersUser(string login, string firstName, string lastName, string image, string status)
        {
            this.login = login;
            this.firstName = firstName;
            this.lastName = lastName;
            this.image = image;
            this.status = status;
        }
    }
}