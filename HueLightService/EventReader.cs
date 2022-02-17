using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace HueLightService {
    public class EventReader {
        private const string APCUPSSERVICE = "APC UPS Service";

        public List<EventLogEntry> GetReleventEvents() {
            var applicationEventEntries = EventLog.GetEventLogs()
                .First(t => t.Log == "Application")
                .Entries;
            var eventLogEntries = new EventLogEntry[applicationEventEntries.Count];
            applicationEventEntries.CopyTo(eventLogEntries, 0);

            var apcUpsServiceLogs = new List<EventLogEntry>();
            var twentyFourHourseAgo = DateTime.Now.AddHours(-24);
            foreach (var log in eventLogEntries.Where(log => log.TimeWritten.Date >= twentyFourHourseAgo.Date && log.TimeWritten.Date <= DateTime.Now.Date &&
                                                             log.Source.Equals(APCUPSSERVICE, StringComparison.OrdinalIgnoreCase))) {
                apcUpsServiceLogs.Add(log);
            }

            return apcUpsServiceLogs;
        }
    }
}
