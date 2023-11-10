using Cosmos.System;
using Cosmos.System.Graphics;
using IL2CPU.API.Attribs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinnamomum.CinnamomumDE
{
    public static class CursorHandler
    {
        [ManifestResourceStream(ResourceName = "Cinnamomum.Resources.Pointer.bmp")] public static byte[] cinaPointer;
        public static Bitmap normal = new Bitmap(cinaPointer);

        public static CursorMode mode = CursorMode.Normal;

        public enum CursorMode
        {
            Normal,
            Click
        }

        public static void DrawCursor()
        {
            switch (mode)
            {
                case CursorMode.Normal:
                    CinaDrawLib.DrawImageAlpha(normal, (int)MouseManager.X, (int)MouseManager.Y);
                    break;
                default:
                    GlobalLog.AddLog("WARNING", "Possibility vulnerability in cursor mode selection, using default cursor as fallback");
                    CinaDrawLib.DrawImageAlpha(normal, (int)MouseManager.X, (int)MouseManager.Y);
                    break;
            }
        }
    }
}
