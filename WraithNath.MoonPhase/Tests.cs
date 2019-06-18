using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace WraithNath.MoonPhase
{
    public static class Tests
    {
        public static void TestPhaseRange()
        {
            List<double> phases = new List<double>();

            for (DateTime day = DateTime.Today; day <= DateTime.Now.AddYears(1); day = day.AddDays(1))
            {
                Console.WriteLine("Processing day: " + day.ToLongDateString());

                double phase = Moon.MoonPhase.GetMoonPhase(day);

                Console.WriteLine("Phase: " + phase);

                phases.Add(phase);
            }

            double min = phases.Min();

            double max = phases.Max();

            Console.WriteLine("Min: " + min);
            Console.WriteLine("Max: " + max);
        }
    }
}
