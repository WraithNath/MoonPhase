using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WraithNath.MoonPhase.Engine
{
    /// <summary>
    /// Class for handling State Data
    /// </summary>
    public static class StateManager 
    {
        /// <summary>
        /// Gets or Sets the Current Date
        /// </summary>
        public static DateTime CurrentDate;

        /// <summary>
        /// Gets or Sets the Moon Phase
        /// </summary>
        public static double MoonPhase;

        /// <summary>
        /// Gets or Sets the Moon Age
        /// </summary>
        public static double MoonAge;

        /// <summary>
        /// Gets or Sets whether the Icon should also Update
        /// </summary>
        public static bool AutoUpdate;

        /// <summary>
        /// Gets or Sets whether the App Auto Runs
        /// </summary>
        public static bool AutoRun;
    }
}
