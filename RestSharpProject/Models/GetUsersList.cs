using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpProject.Models
{
    public class GetUsersList
    {
        public List<GetUserData> users { get; set; }
    }

    public class GetUserData
    {
        public string login { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public List<string> image { get; set; } = null!;
        public string status { get; set; }
    }
}





