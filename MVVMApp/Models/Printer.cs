using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMApp.Models
{
   public class Printer:Entity
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public string Vendor { get; set; }
    }
}
