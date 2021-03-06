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





