using System;
using System.IO;
using System.Text;
using System.Globalization;
namespace lib2
{
    public class DateTimeUtils
    {

        private const int DaysPer100Years = 36524;
        private const int DaysPer400Years = 146097;
        private const int DaysPer4Years = 1461;
        private const int DaysPerYear = 365;
        private const long TicksPerDay = 864000000000L;
        static int[] DaysToMonth365 = new[] { 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334, 365 };
        static int[] DaysToMonth366 = new[] { 0, 31, 60, 91, 121, 152, 182, 213, 244, 274, 305, 335, 366 };

        //   code from
        //  https://github.com/JamesNK/Newtonsoft.Json/blob/master/Src/Newtonsoft.Json/Utilities/DateTimeUtils.cs
        
        public static void GetDateValues(DateTime td, out int year, out int month, out int day)
        {
            long ticks = td.Ticks;
            // n = number of days since 1/1/0001
            int n = (int)(ticks / TicksPerDay);
            // y400 = number of whole 400-year periods since 1/1/0001
            int y400 = n / DaysPer400Years;
            // n = day number within 400-year period
            n -= y400 * DaysPer400Years;
            // y100 = number of whole 100-year periods within 400-year period
            int y100 = n / DaysPer100Years;
            // Last 100-year period has an extra day, so decrement result if 4
            if (y100 == 4)
            {
                y100 = 3;
            }
            // n = day number within 100-year period
            n -= y100 * DaysPer100Years;
            // y4 = number of whole 4-year periods within 100-year period
            int y4 = n / DaysPer4Years;
            // n = day number within 4-year period
            n -= y4 * DaysPer4Years;
            // y1 = number of whole years within 4-year period
            int y1 = n / DaysPerYear;
            // Last year has an extra day, so decrement result if 4
            if (y1 == 4)
            {
                y1 = 3;
            }

            year = y400 * 400 + y100 * 100 + y4 * 4 + y1 + 1;

            // n = day number within year
            n -= y1 * DaysPerYear;

            // Leap year calculation looks different from IsLeapYear since y1, y4,
            // and y100 are relative to year 1, not year 0
            bool leapYear = y1 == 3 && (y4 != 24 || y100 == 3);

            // uncomment any of these lines and it will work:
            //Console.WriteLine("[{0}]", string.Join(", ", DaysToMonth365));
            //Console.WriteLine("[{0}]", string.Join(", ", DaysToMonth366));
            //Console.WriteLine("bla");

            int[] days = leapYear ? DaysToMonth366 : DaysToMonth365;
			
            // All months have less than 32 days, so n >> 5 is a good conservative
            // estimate for the month
            int m = n >> 5 + 1;
            // m = 1-based month number
            while (n >= days[m])
            {
                m++;
            }

            month = m;

            // Return 1-based day-of-month
            day = n - days[m - 1] + 1;
        }
    }

}
