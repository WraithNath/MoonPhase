using System;
using System.Collections.Generic;
using System.Text;

namespace WraithNath.MoonPhase.Moon
{
    /// <summary>
    /// Classed used to calculate The Age of the current moon for the specified cycle date
    /// </summary>
    public static class MoonAge
    {
        /// <summary>
        /// Gets the Moon Age
        /// </summary>
        /// <param name="date">The Date</param>
        /// <returns></returns>
        public static double GetMoonAge(DateTime date)
        {
            return GetMoonAge(date.Day, date.Month, date.Year);
        }

        /// <summary>
        /// Gets the Moon Age
        /// </summary>
        /// <param name="day">The Day</param>
        /// <param name="month">The Month</param>
        /// <param name="year">The Year</param>
        /// <returns>Moon Sage</returns>
        public static double GetMoonAge(int day, int month, int year)
        {
            double moonPhase = MoonPhase.GetMoonPhase(day, month, year);

            return GetMoonAge(moonPhase);
        }

        /// <summary>
        /// Gets the Moon Age
        /// </summary>
        /// <param name="day">The Day</param>
        /// <param name="month">The Month</param>
        /// <param name="year">The Year</param>
        /// <param name="moonPhase">The Phase</param>
        /// <returns>Moon Age</returns>
        public static double GetMoonAge(double moonPhase)
        {
            double moonAge = 0;

            if (moonPhase < 0.5)
                moonAge = moonPhase * 29.53059 + 29.53059 / 2;
            else
                moonAge = moonPhase * 29.53059 - 29.53059 / 2;

            // Moon's age in days
            moonAge = Math.Floor(moonAge) + 1;

            return moonAge;
        }
    }
}
