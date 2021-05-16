using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpProject.Model
{
    public class Users
    {
        public string login { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string gitHubUrl { get; set; }
        public string userName { get; set; }
    }

    public class Response
    {
        public List<string> firstName { get; set; }
        public List<string> lastName { get; set; }
        public List<string> userName { get; set; }
    }
}
