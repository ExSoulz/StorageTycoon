using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageLibs.Utility
{
    public static class Logger
    {
        public delegate void MessageDelegate(string msg);
        public static event MessageDelegate LogMessage;

        internal static void SendLogMessage(string msg)
        {
            LogMessage("LOG: " + msg);
        }
        internal static void SendErrorLogMessage(string msg)
        {
            LogMessage("Error: " + msg);
        }
        internal static void SendWarningLogMessage(string msg)
        {
            LogMessage("Warning: " + msg);
        }
    }
}
