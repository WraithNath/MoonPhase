using System;
using System.Collections.Generic;
using System.Text;

namespace WraithNath.MoonPhase.Moon
{
    /// <summary>
    /// Class for calculating Moon Phase
    /// </summary>
    public static class MoonPhase
    {
        /// <summary>
        /// Gets the Phase of the Moon
        /// </summary>
        /// <param name="date">The Date</param>
        /// <returns>Phase</returns>
        public static double GetMoonPhase(DateTime date)
        {
            return GetMoonPhase(date.Day, date.Month, date.Year);
        }

        /// <summary>
        /// Gets the Phase of the Moon
        /// </summary>
        /// <param name="day">The Day</param>
        /// <param name="month">The Month</param>
        /// <param name="year">The Year</param>
        /// <returns>Phase</returns>
        public static double GetMoonPhase(int day, int month, int year)
        {
            int julianDate = JulianDate.GetJulianDate(day, month, year);

            //Calculate the approximate phase of the moon
            double moonPhase = (julianDate + 4.867) / 29.53059;
            moonPhase = moonPhase - Math.Floor(moonPhase);

            return moonPhase;
        }

        public static string GetPhaseName(double phase)
        {
            double rounded = Math.Round(phase, 2);

            return string.Empty;
        }
    }
}
