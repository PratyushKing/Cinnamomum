using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinnamomum.CinnamomumDE
{
    public static class Entry
    {
        /// <summary>
        /// This marks the entry point of Cinnamomum, use it to start the OS normally with configs.
        /// </summary>
        /// <param name="osname">Specify your wonderful kernel name!</param>
        /// <param name="osver">Specify your current OS/kernel version!</param>
        /// <param name="config">Specify configs that you could have setup!</param>
        public static void StartDE(string osname, string osver, CinaConfigs config)
        {
            ConfigPaths.ModifyConfig("org.cinnamomum.currentsys.osname", osname);
            ConfigPaths.ModifyConfig("org.cinnamomum.currentsys.osversion", osver);
            AllInit(config.cMode);
        }

        /// <summary>
        /// This marks the entry point of Cinnamomum, use it to start the OS without specifying configs, essentially safe mode.
        /// </summary>
        /// <param name="osname">Specify your wonderful kernel name!</param>
        /// <param name="osver">Specify your current OS/kernel version!</param>
        public static void StartDE(string osname, string osver)
        {
            ConfigPaths.ModifyConfig("org.cinnamomum.currentsys.osname", osname);
            ConfigPaths.ModifyConfig("org.cinnamomum.currentsys.osversion", osver);
            AllInit();
        }

        public struct CinaConfigs
        {
            //settings and all
            public CinaDrawLib.CanvasMode cMode;
        }

        /// <summary>
        /// THIS FUNCTION IS FOR INTERNAL STRUCTURE OF CINNAMOMUM, PLEASE DO NOT EDIT/EXECUTE THROUGH KERNEL.
        /// </summary>
        /// <param name="mode"></param>
        public static void AllInit(CinaDrawLib.CanvasMode mode = CinaDrawLib.CanvasMode.Regular)
        {
            GlobalLog.AddLog("INFO", "CINNAMOMUM HAS STARTED!");
            CinaDrawLib.INITIALIZE(mode);
            switch (ConfigPaths.AccessConfig("org.cinnamomum.canvas.preference"))
            {
                case "Canvas":
                    CinaDrawLib.regularcanvas = FullScreenCanvas.GetFullScreenCanvas(new(640, 480, ColorDepth.ColorDepth32));
                    CinaDrawLib.RUN();
                    break;
                case "SVGAII":
                    CinaDrawLib.svgaiicanvas = new(new(640, 480, ColorDepth.ColorDepth32));
                    CinaDrawLib.RUN(true);
                    break;
                default:
                    CinaDrawLib.RUN();
                    break;
            }
        }
    }
}
