using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinnamomum.CinnamomumDE
{
    internal static class InternalUtilities
    {
        /// <summary>
        /// THIS FUNCTION IS FOR INTERNAL STRUCTURE OF CINNAMOMUM, PLEASE DO NOT EDIT/EXECUTE THROUGH KERNEL.
        /// </summary>
        /// <param name="first">First list to add in final. PLEASE DO NOT USE IT OUTSIDE OF CINNAMOMUM SOURCE CODE.</param>
        /// <param name="second">Second list to add on first in final. PLEASE DO NOT USE IT OUTSIDE OF CINNAMOMUM SOURCE CODE.</param>
        /// <returns></returns>
        public static List<windowObject> ConcatTwoWindowObjects(List<windowObject> first, List<windowObject> second)
        {
            var finalList = new List<windowObject>();
            for (var i = 0; i < first.Count; i++) { finalList.Add(first[i]); }
            for (var i = 0; i < second.Count; i++) { finalList.Add(second[i]); }
            return finalList;
        }
    }
}
