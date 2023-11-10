using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Cinnamomum.CinnamomumDE
{
    public static class GlobalLog
    {
        public static List<string> Log = new List<string>();

        /// <summary>
        /// Adds log to the global log of Cinnamomum, can be accessed by the kernel itself to troubleshoot itself.
        /// </summary>
        /// <param name="strictness">
        /// The strictness parameter can have 3 values, "SEVERE", "WARNING", "INFO", if not used any of these 3, then it uses default, "INFO".
        /// </param>
        /// <param name="loginfo">
        /// The loginfo is what you want the message to be, could include an error code for example.
        /// </param>
        public static void AddLog(string strictness, string loginfo)
        {
            switch (strictness)
            {
                case "SEVERE":
                case "WARNING":
                case "INFO":
                    Log.Add("[" + strictness + "] " + loginfo);
                    return;
                default:
                    Log.Add("[INFO] " + loginfo);
                    return;
            }
        }

        /// <summary>
        /// This function gives you access to the data in the log at the specified index parameter.
        /// </summary>
        /// <param name="index">This index must be in bounds with the Log's count or else it will deny your request.</param>
        /// <returns></returns>
        public static string AccessLogAtIndex(int index) { if (index < Log.Count - 1) { return Log[index]; } else { return "DENIED_REQUEST"; } }
    }
}
