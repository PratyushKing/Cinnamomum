using Cinnamomum.CinnamomumDE.AppKit;
using Cosmos.System;
using Cosmos.System.Graphics;
using IL2CPU.API.Attribs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinnamomum.CinnamomumDE
{
    public static class CinaDrawLib
    {
        [ManifestResourceStream(ResourceName = "Cinnamomum.Resources.CinnamomumDefaultBundledWallpaper.bmp")] public static byte[] cinaBundledWallpaper;
        public static Bitmap wallpaper = new Bitmap(cinaBundledWallpaper);

        public enum CanvasMode
        {
            SVGAII,
            Regular
        }

        /// <summary>
        /// THIS FUNCTION IS FOR INTERNAL STRUCTURE OF CINNAMOMUM, PLEASE DO NOT EDIT/EXECUTE THROUGH KERNEL.
        /// </summary>
        /// <param name="cMode"></param>
        public static void INITIALIZE(CanvasMode cMode)
        {
            MouseManager.ScreenWidth = 640;
            MouseManager.ScreenHeight = 480;
            switch (cMode)
            {
                case CanvasMode.SVGAII:
                    ConfigPaths.ModifyConfig("org.cinnamomum.canvas.preference", "SVGAII");
                    svgaiicanvas = new(new(640, 480, ColorDepth.ColorDepth32));
                    break;
                case CanvasMode.Regular:
                    ConfigPaths.ModifyConfig("org.cinnamomum.canvas.preference", "Canvas");
                    regularcanvas = FullScreenCanvas.GetFullScreenCanvas(new(640, 480, ColorDepth.ColorDepth32));
                    break;
                default:
                    ConfigPaths.ModifyConfig("org.cinnamomum.canvas.preference", "Canvas");
                    regularcanvas = FullScreenCanvas.GetFullScreenCanvas(new(640, 480, ColorDepth.ColorDepth32));
                    break;
            }
        }

        public static Canvas regularcanvas;
        public static SVGAIICanvas svgaiicanvas;

        /// <summary>
        /// THIS FUNCTION IS FOR INTERNAL STRUCTURE OF CINNAMOMUM, PLEASE DO NOT EDIT/EXECUTE THROUGH KERNEL.
        /// </summary>
        public static void RUN(bool svgaiiCanvas)
        {
            var testObj = new windowObject(0, 10, 10, 100, 150, "TestingIt!", new(), MuffleTheme.DefaultCinnamomum, new());
            AppMaker.MakeNewApp(testObj, "testing", true);
            while (true)
            {
                svgaiicanvas.DrawImage(wallpaper, 0, 0);
                Muffled.DrawAll();

                CursorHandler.DrawCursor();
                svgaiicanvas.Display();
            }
        }


        /// <summary>
        /// THIS FUNCTION IS FOR INTERNAL STRUCTURE OF CINNAMOMUM, PLEASE DO NOT EDIT/EXECUTE THROUGH KERNEL.
        /// </summary>
        public static void RUN()
        {
            while (true)
            {
                regularcanvas.DrawImage(wallpaper, 0, 0);
                Muffled.DrawAll();

                CursorHandler.DrawCursor();
                regularcanvas.Display();
            }
        }

        /// <summary>
        /// THIS FUNCTION IS FOR INTERNAL STRUCTURE OF CINNAMOMUM, PLEASE DO NOT EDIT/EXECUTE THROUGH KERNEL.
        /// </summary>
        public static void DrawFilledRectangle(System.Drawing.Color color, int x, int y, int w, int h)
        {
            switch (ConfigPaths.AccessConfig("org.cinnamomum.canvas.preference"))
            {
                case "Canvas":
                    regularcanvas.DrawFilledRectangle(color, x, y, w, h);
                    break;
                case "SVGAII":
                    svgaiicanvas.DrawFilledRectangle(color, x, y, w, h);
                    break;
                default:
                    regularcanvas.DrawFilledRectangle(color, x, y, w, h);
                    break;
            }
        }

        /// <summary>
        /// THIS FUNCTION IS FOR INTERNAL STRUCTURE OF CINNAMOMUM, PLEASE DO NOT EDIT/EXECUTE THROUGH KERNEL.
        /// </summary>
        public static void DrawRectangle(System.Drawing.Color color, int x, int y, int w, int h)
        {
            switch (ConfigPaths.AccessConfig("org.cinnamomum.canvas.preference"))
            {
                case "Canvas":
                    regularcanvas.DrawRectangle(color, x, y, w, h);
                    break;
                case "SVGAII":
                    svgaiicanvas.DrawRectangle(color, x, y, w, h);
                    break;
                default:
                    regularcanvas.DrawRectangle(color, x, y, w, h);
                    break;
            }
        }

        /// <summary>
        /// THIS FUNCTION IS FOR INTERNAL STRUCTURE OF CINNAMOMUM, PLEASE DO NOT EDIT/EXECUTE THROUGH KERNEL.
        /// </summary>
        public static void DrawFilledCircle(System.Drawing.Color color, int x, int y, int radius)
        {
            switch (ConfigPaths.AccessConfig("org.cinnamomum.canvas.preference"))
            {
                case "Canvas":
                    regularcanvas.DrawFilledCircle(color, x, y, radius);
                    break;
                case "SVGAII":
                    svgaiicanvas.DrawFilledCircle(color, x, y, radius);
                    break;
                default:
                    regularcanvas.DrawFilledCircle(color, x, y, radius);
                    break;
            }
        }

        /// <summary>
        /// THIS FUNCTION IS FOR INTERNAL STRUCTURE OF CINNAMOMUM, PLEASE DO NOT EDIT/EXECUTE THROUGH KERNEL.
        /// </summary>
        public static void DrawCircle(System.Drawing.Color color, int x, int y, int radius)
        {
            switch (ConfigPaths.AccessConfig("org.cinnamomum.canvas.preference"))
            {
                case "Canvas":
                    regularcanvas.DrawCircle(color, x, y, radius);
                    break;
                case "SVGAII":
                    svgaiicanvas.DrawCircle(color, x, y, radius);
                    break;
                default:
                    regularcanvas.DrawCircle(color, x, y, radius);
                    break;
            }
        }

        /// <summary>
        /// THIS FUNCTION IS FOR INTERNAL STRUCTURE OF CINNAMOMUM, PLEASE DO NOT EDIT/EXECUTE THROUGH KERNEL.
        /// </summary>
        public static void DrawImageAlpha(Bitmap img, int x, int y)
        {
            switch (ConfigPaths.AccessConfig("org.cinnamomum.canvas.preference"))
            {
                case "Canvas":
                    regularcanvas.DrawImageAlpha(img, x, y);
                    break;
                case "SVGAII":
                    svgaiicanvas.DrawImageAlpha(img, x, y);
                    break;
                default:
                    regularcanvas.DrawImageAlpha(img, x, y);
                    break;
            }
        }

        /// <summary>
        /// THIS FUNCTION IS FOR INTERNAL STRUCTURE OF CINNAMOMUM, PLEASE DO NOT EDIT/EXECUTE THROUGH KERNEL.
        /// </summary>
        public static void DrawImage(Bitmap img, int x, int y)
        {
            switch (ConfigPaths.AccessConfig("org.cinnamomum.canvas.preference"))
            {
                case "Canvas":
                    regularcanvas.DrawImage(img, x, y);
                    break;
                case "SVGAII":
                    svgaiicanvas.DrawImage(img, x, y);
                    break;
                default:
                    regularcanvas.DrawImage(img, x, y);
                    break;
            }
        }
    }
}
