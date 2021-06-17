using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpProject.Models
{
    public class UserModel
    {
        public string _id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public Nullable<int> phone { get; set; }
        public List<string> technologies { get; set; }
        public string password { get; set; }
        public string login { get; set; }
        public string githubLink { get; set; }
    }

    public class Response
    {
        public Fields fields { get; set; }
        public List<string> general { get; set; }
    }

    public class Fields
    {
        public List<string> firstName { get; set; }
        public List<string> lastName { get; set; }
        public List<string> gender { get; set; }
        public List<string> email { get; set; }

        public List<string> phone { get; set; }

        public List<string> technologies { get; set; }

        public List<string> password { get; set; }

        public List<string> login { get; set; }

        public List<string> githubLink { get; set; }
    }
}
