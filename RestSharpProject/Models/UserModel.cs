﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpProject.Models
{
    public class UserModel
    {
        public List<string> technologies { get; set; }
        public string _id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public Nullable<int> phone { get; set; }
        public string login { get; set; }
        public string githubLink { get; set; }
    }
}