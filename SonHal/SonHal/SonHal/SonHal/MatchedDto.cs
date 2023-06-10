using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonHal
{
    public class MatchedDto
    {
        public string SideValues { get; set; }
        public string UserValues { get; set; }
        public string ExcelHeaders { get; set; }

        public string sideFile { get; set; }
        public bool isExcel { get; set; }

        public bool isRepeat { get; set; }
    }
}
