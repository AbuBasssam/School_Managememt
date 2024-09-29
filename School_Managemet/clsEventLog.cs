using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace School_Managemet_Repository
{
    public class clsEventLog
    {
        public static void SetEventLog(string Message, EventLogEntryType eventLogEntryType = EventLogEntryType.Error)
        {
            string sourceName = "SchoolDB";

            if (!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, "Application");
            }
            EventLog.WriteEntry(sourceName, Message, eventLogEntryType);
        }
    }
}
