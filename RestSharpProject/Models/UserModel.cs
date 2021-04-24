using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpProject.Models
{
    public class UserModel
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public Nullable<int> phone { get; set; }
        public List<string> technologies { get; set; }
        public string password { get; set; }
        public string login { get; set; }
        public string githubLink { get; set; }
    }
}
