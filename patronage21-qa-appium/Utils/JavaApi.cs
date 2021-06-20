using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using patronage21_qa_appium.Models;
using Newtonsoft.Json;

namespace patronage21_qa_appium.Utils
{
    class JavaApi
    {
        private static readonly string _url = "http://intive-patronage.pl";
        private static RestClient _client = new(_url);
        private static IRestRequest _requestGet;
        private static GetUsersResponse _response;
        private static RestRequest _requestPatch;

        public static void DeactivateUsersByLogin(string contains)
        {
            _requestGet = new RestRequest("/api/users", Method.GET);
            _requestGet = _requestGet.AddParameter("status", "ACTIVE");
            _response = JsonConvert.DeserializeObject<GetUsersResponse>(_client.Execute(_requestGet).Content);
            for (int i = 0; i < _response.users.Count; i++)
            {
                if (_response.users[i].login.Contains(contains))
                {
                    _requestPatch = new RestRequest("/api/users/" + _response.users[i].login + "/deactivate", Method.PATCH);
                    _client.Execute(_requestPatch);
                }
            }
        }
    }
}
