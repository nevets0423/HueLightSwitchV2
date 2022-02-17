using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMP {
    class Program {
        static void Main(string[] args) {
            var tmp = EventLog.GetEventLogs();
            var appLogs = tmp.First(t => t.Log == "Application").Entries;

            var apcUpsServiceLogs = new List<string>();
            foreach(EventLogEntry log in appLogs) {
                if(log.TimeWritten.Date != DateTime.Now.Date || 
                    !log.Source.Equals("APC UPS Service", StringComparison.OrdinalIgnoreCase)) {
                    continue;
                }

                var t = log;
            }
        }
    }
}
