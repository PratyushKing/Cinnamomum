using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinnamomum.CinnamomumDE
{
    public static class ConfigPaths
    {
        private static string Cinnamomum_Canvas_Preference = "Canvas";
        private static string Cinnamomum_CurrentRunningSystem_OSName = "UNKNOWN";
        private static string Cinnamomum_CurrentRunningSystem_OSVer = "v0.0";


        /// <summary>
        /// This accesses a specified config at a path, example: "org.cinnamomum.canvas.preference" and returns a string of that path.
        /// </summary>
        /// <param name="path">This path must start with 'org.cinnamomum.' to signify that it's only accessing cinnamomum configs, could be modified to add kernel configs.</param>
        /// <returns></returns>
        public static string AccessConfig(string path)
        {
            switch (path)
            {
                case "org.cinnamomum.canvas.preference":
                    return Cinnamomum_Canvas_Preference;
                case "org.cinnamomum.currentsys.osname":
                    return Cinnamomum_CurrentRunningSystem_OSName;
                case "org.cinnamomum.currentsys.osversion":
                    return Cinnamomum_CurrentRunningSystem_OSVer;
                default:
                    GlobalLog.AddLog("SEVERE", "Invalid Attempt to fetch a config that doesn't exist!");
                    return "DENIED";
            }
        }

        /// <summary>
        /// This modifies a specified config at a path, example: "org.cinnamomum.canvas.preference" with the data given in data parameter.
        /// </summary>
        /// <param name="path">This path must start with 'org.cinnamomum.' to signify that it's only modifying cinnamomum configs, could be modified to add kernel configs.</param>
        /// <param name="data">This is data, it must be string content only.</param>
        public static void ModifyConfig(string path, string data)
        {
            switch (path)
            {
                case "org.cinnamomum.canvas.preference":
                    Cinnamomum_Canvas_Preference = data;
                    return;
                case "org.cinnamomum.currentsys.osname":
                    Cinnamomum_CurrentRunningSystem_OSName = data;
                    return;
                case "org.cinnamomum.currentsys.osversion":
                    Cinnamomum_CurrentRunningSystem_OSVer = data;
                    return;
                default:
                    GlobalLog.AddLog("SEVERE", "Invalid Attempt to modify a config that doesn't exist!");
                    return;
            }
        }

    }
}
