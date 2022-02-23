using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatteryLog.Entities
{
    class Meas
    {
        public string Date { get; set; }
        public string Hour { get; set; }
        public string Voltage { get; set; }
        public string Current { get; set; }

        public Meas(string date, string hour, string voltage, string current)
        {
            Date = date;
            Hour = hour;
            Voltage = voltage;
            Current = current;
        }
    }
}
