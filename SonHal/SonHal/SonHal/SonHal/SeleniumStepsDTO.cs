using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonHal
{
    public class SeleniumStepsDTO
    {
        public string Url { get; set; }
        public List<CommandDTO> Commands { get; set; }
    }

    public class CommandDTO
    {

        public string Command { get; set; }
        public string Target { get; set; }
        public string Value { get; set; }
    }
}
