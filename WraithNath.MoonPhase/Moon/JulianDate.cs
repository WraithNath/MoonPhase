using System;
using System.Collections.Generic;
using System.Text;

namespace WraithNath.MoonPhase.Moon
{
    /// <summary>
    /// Class for calculating Julian Dates
    /// </summary>
    public static class JulianDate
    {
        /// <summary>
        /// Gets a Julian Date
        /// </summary>
        /// <param name="date">The Date Time</param>
        /// <returns>Julian Date</returns>
        public static int GetJulianDate(DateTime date)
        {
            return GetJulianDate(date.Day, date.Month, date.Year);
        }

        /// <summary>
        /// Gets a Julian Date
        /// </summary>
        /// <param name="day">The Day</param>
        /// <param name="month">The Month</param>
        /// <param name="year">The Year</param>
        /// <returns>Julian Date</returns>
        public static int GetJulianDate(int day, int month, int year)
        {
            int mm, yy;
            int k1, k2, k3;
            int j;

            yy = year - (int)((12 - month) / 10);
            mm = month + 9;
            if (mm >= 12)
            {
                mm = mm - 12;
            }
            k1 = (int)(365.25 * (yy + 4712));
            k2 = (int)(30.6001 * mm + 0.5);
            k3 = (int)((int)((yy / 100) + 49) * 0.75) - 38;

            // 'j' for dates in Julian calendar:
            j = k1 + k2 + day + 59;

            if (j > 2299160)
            {
                // For Gregorian calendar:
                j = j - k3;  // 'j' is the Julian date at 12h UT (Universal Time)
            }

            return j;
        }
    }
}
