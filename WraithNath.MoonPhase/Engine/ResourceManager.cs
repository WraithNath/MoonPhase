using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WraithNath.MoonPhase.Properties;

namespace WraithNath.MoonPhase.Engine
{
    /// <summary>
    /// Class for managine resources
    /// </summary>
    public static class ResourceManager
    {
        /// <summary>
        /// Gets an icon based on Moon Age
        /// </summary>
        /// <param name="moonAge">The moon Age</param>
        /// <returns>Icon</returns>
        public static Icon GetIcon(int moonAge)
        {
            switch (moonAge)
            {
                case 0: return Resources._00_NewMoon;
                case 1: return Resources._06_Wax_Cres;
                case 2: return Resources._10_Wax_Cres;
                case 3: return Resources._13_Wax_Cres;
                case 4: return Resources._16_Wax_Cres;
                case 5: return Resources._20_Wax_Cres;
                case 6: return Resources._23_Wax_Cres;
                case 7: return Resources._26_Wax_Gib;
                case 8: return Resources._30_Wax_Gib;
                case 9: return Resources._33_Wax_Gib;
                case 10: return Resources._36_Wax_Gib;
                case 11: return Resources._40_Wax_Gib;
                case 12: return Resources._43_Wax_Gib;
                case 13: return Resources._46_Wax_Gib;
                case 14: return Resources._50_FullMoon;
                case 15: return Resources._53_Wan_Gib;
                case 16: return Resources._56_Wan_Gib;
                case 17: return Resources._60_Wan_Gib;
                case 18: return Resources._63_Wan_Gib;
                case 19: return Resources._66_Wan_Gib;
                case 20: return Resources._70_Wan_Gib;
                case 21: return Resources._73_Wan_Cres;
                case 22: return Resources._76_Wan_Cres;
                case 23: return Resources._80_Wan_Cres;
                case 24: return Resources._83_Wan_Cres;
                case 25: return Resources._86_Wan_Cres;
                case 26: return Resources._90_Wan_Cres;
                case 27: return Resources._93_Wan_Cres;
                case 28: return Resources._96_Wan_Cres;
                case 29: return Resources._99_Wan_Cres;
                case 30: return Resources._00_NewMoon;
                default: return Resources._50_FullMoon;
            }
        }
    }
}
