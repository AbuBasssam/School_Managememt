using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace School_Managemet_Repository
{
    public class clsEventLog
    {
        private readonly ILogger<clsEventLog> _logger;

        public clsEventLog(ILogger<clsEventLog> logger)
        {
            _logger = logger;
        }

        public void LogEvent(string message, LogLevel logLevel = LogLevel.Error)
        {
            _logger.Log(logLevel, message);
        }
    }

}
