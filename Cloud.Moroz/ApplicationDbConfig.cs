using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Moroz
{
    public class ApplicationDbConfig
    {
        public string Database_Name { get; set; }
        public string Phones_Collection_name { get; set; }
        public string Tablets_Collection_name { get; set; }
        public string Computers_Collection_name { get; set; }
        public string Connection_String { get; set; }
    }
}
