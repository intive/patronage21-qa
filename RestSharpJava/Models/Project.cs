﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpProject.Models
{
    public class ProjectList
    {
        public List<Project> projects { get; set; }
    }

    public class Project
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
