using Cinnamomum.CinnamomumDE;
using Cosmos.System;
using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace Cinnamomum
{
    public class Kernel : Sys.Kernel
    {

        protected override void BeforeRun()
        {
            System.Console.WriteLine("Cinnamomum Desktop Environment Test!");
            System.Threading.Thread.Sleep(500);
        }

        protected override void Run()
        {
            var config = new Entry.CinaConfigs();
            config.cMode = CinaDrawLib.CanvasMode.Regular;
            if (VMTools.IsQEMU || VMTools.IsVMWare || VMTools.IsVirtualBox)
                config.cMode = CinaDrawLib.CanvasMode.SVGAII;

            Entry.StartDE("CinnamomumTesting", "v0.1", config);
        }
    }
}
