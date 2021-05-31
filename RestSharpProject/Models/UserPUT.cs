using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpProject.Models
{
    public class RootPUT
    {
        public UserPUT user { get; set; }
    }

    public class UserPUT
    {
        public string login { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string gitHubUrl { get; set; }
        public string bio { get; set; }
        public string status { get; set; }
    }

    public class RejectedValue
    {

    }

    public class ViolationError
    {
        public string fieldName { get; set; }
        public string message { get; set; }
    }

    public class RootResponse
    {
        public List<ViolationError> violationErrors { get; set; }
    }
}


