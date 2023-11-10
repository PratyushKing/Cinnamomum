using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinnamomum.CinnamomumDE.AppKit
{
    public static class AppMaker
    {
        private static List<windowObject> appsMade = new List<windowObject>();
        private static List<string> appInternalDirectoryNames = new List<string>();

        /// <summary>
        /// THIS FUNCTION IS FOR INTERNAL STRUCTURE OF CINNAMOMUM, PLEASE DO NOT EDIT/EXECUTE THROUGH KERNEL.
        /// </summary>
        public static List<windowObject> GIVEALLAPPS()
        {
            return appsMade;
        }

        /// <summary>
        /// MakeNewApp is a method that allows you to create your own window object with all tools as an app with its internal name.
        /// </summary>
        /// <param name="winObj">Make a separate window object, insert all parameters and then insert here.</param>
        /// <param name="internalName">This is a way to refer the app. Must start with `org.cinnamomum.apps.(name)`.</param>
        public static void MakeNewApp(windowObject winObj, string internalName)
        {
            if (theNameIsWithPrefix(internalName))
            {
                appsMade.Add(winObj);
                appInternalDirectoryNames.Add(internalName);
            }
            else
            {
                GlobalLog.AddLog("SEVERE", "App creation failure, no prefix");
            }
        }

        public static void MakeNewApp(windowObject winObj, string internalName, bool prefix)
        {
            switch (prefix)
            {
                case true:
                    appsMade.Add(winObj);
                    appInternalDirectoryNames.Add("org.cinnamomum.apps." + internalName);
                    break;
                case false:
                    if (theNameIsWithPrefix(internalName))
                    {
                        appsMade.Add(winObj);
                        appInternalDirectoryNames.Add(internalName);
                    }
                    else
                    {
                        GlobalLog.AddLog("SEVERE", "App creation failure, no prefix");
                    }
                    break;
            }
        }

        private static bool theNameIsWithPrefix(string name) { if (!name.StartsWith("org.cinnamomum.apps.")) { return false; } else { return true; } }
    }
}
