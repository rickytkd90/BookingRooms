using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BookingRooms.Common
{
    public class LogManager
    {
        private static Logger log = NLog.LogManager.GetCurrentClassLogger();

        public static void Error(Exception ex)
        {
            log.Error(ex, ex.Message);
        }

        public static void Error(string message)
        {
            log.Error(message);
        }

        public static void Warning(string message)
        {
            log.Warn(message);
        }

        public static void Info(string message)
        {
            log.Info(message);
        }

        public static void Debug(string message)
        {
            log.Debug(message);
        }
    }
}
