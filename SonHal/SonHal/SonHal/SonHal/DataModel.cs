using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonHal
{
    public class DataModel
    {
        public string id { get; set; }
        public string version { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public Test[] tests { get; set; }
        public Suite[] suites { get; set; }
        public object[] urls { get; set; }
        public object[] plugins { get; set; }


        public class Test
        {
            public string id { get; set; }
            public string name { get; set; }
            public Command[] commands { get; set; }
        }

        public class Command
        {
            public string id { get; set; }
            public string comment { get; set; }
            public string command { get; set; }
            public string target { get; set; }
            public string[][] targets { get; set; }
            public string value { get; set; }
        }

        public class Suite
        {
            public string id { get; set; }
            public string name { get; set; }
            public bool persistSession { get; set; }
            public bool parallel { get; set; }
            public int timeout { get; set; }
            public string[] tests { get; set; }
        }

    }
}
