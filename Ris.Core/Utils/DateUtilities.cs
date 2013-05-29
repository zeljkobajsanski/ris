using System;

namespace Rs.Dnevnik.Ris.Core.Utils
{
    /// <summary>
    /// Common DateTime Methods.
    /// </summary>
    /// 
    public enum Quarter
    {
        First = 1,
        Second = 2,
        Third = 3,
        Fourth = 4
    }

    public enum Month
    {
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12
    }

    public static class DateUtilities
    {
        #region Quarter
        public static DateTime GetStartOfQuarter(int year, Quarter qtr)
        {
            switch(qtr)
            {
            case Quarter.First:
                // 1st Quarter = January 1 to March 31
                return new DateTime(year, 1, 1, 0, 0, 0, 0);
            case Quarter.Second:
                // 2nd Quarter = April 1 to June 30
                return new DateTime(year, 4, 1, 0, 0, 0, 0);
            case Quarter.Third:
                // 3rd Quarter = July 1 to September 30
                return new DateTime(year, 7, 1, 0, 0, 0, 0);
            default:
                // 4th Quarter = October 1 to December 31
                return new DateTime(year, 10, 1, 0, 0, 0, 0);
            }
        }

        public static DateTime GetEndOfQuarter(int year, Quarter qtr)
        {
            switch(qtr)
            {
            case Quarter.First:
                // 1st Quarter = January 1 to March 31
                return new DateTime(year, 3, DateTime.DaysInMonth(year, 3), 23, 59, 0);
            case Quarter.Second:
                // 2nd Quarter = April 1 to June 30
                return new DateTime(year, 6, DateTime.DaysInMonth(year, 6), 23, 59, 0);
            case Quarter.Third:
                // 3rd Quarter = July 1 to September 30
                return new DateTime(year, 9, DateTime.DaysInMonth(year, 9), 23, 59, 0);
            default:
                // 4th Quarter = October 1 to December 31
                return new DateTime(year, 12, DateTime.DaysInMonth(year, 12), 23, 59, 0);
            }
        }

        public static Quarter GetQuarter(Month month)
        {
            if(month <= Month.March) // 1st Quarter = January 1 to March 31
            {
                return Quarter.First;
            }
            if((month >= Month.April) && (month <= Month.June)) // 2nd Quarter = April 1 to June 30
            {
                return Quarter.Second;
            }
            if((month >= Month.July) && (month <= Month.September)) // 3rd Quarter = July 1 to September 30
            {
                return Quarter.Third;
            }
            // 4th Quarter = October 1 to December 31
            return Quarter.Fourth;
        }

        public static Quarter GetQuarter(this DateTime dateTime)
        {
            return GetQuarter((Month)dateTime.Month);
        }

        public static DateTime GetEndOfLastQuarter()
        {
            //go to last quarter of previous year
            //or return last quarter of current year
            return DateTime.Now.Month <= (int)Month.March
                       ? GetEndOfQuarter(DateTime.Now.Year - 1, GetQuarter(Month.December))
                       : GetEndOfQuarter(DateTime.Now.Year, GetQuarter((Month)DateTime.Now.Month));
        }

        public static DateTime GetStartOfLastQuarter()
        {
            //go to last quarter of previous year
            //or return last quarter of current year
            return DateTime.Now.Month <= 3
                       ? GetStartOfQuarter(DateTime.Now.Year - 1, GetQuarter(Month.December))
                       : GetStartOfQuarter(DateTime.Now.Year, GetQuarter((Month)DateTime.Now.Month));
        }

        public static DateTime GetStartOfCurrentQuarter()
        {
            return GetStartOfQuarter(DateTime.Now.Year, GetQuarter((Month)DateTime.Now.Month));
        }

        public static DateTime GetEndOfCurrentQuarter()
        {
            return GetEndOfQuarter(DateTime.Now.Year, GetQuarter((Month)DateTime.Now.Month));
        }
        #endregion

        #region Weeks
        public static DateTime GetStartOfLastWeek()
        {
            int daysToSubtract = (int)DateTime.Now.DayOfWeek + 7;
            var dt = DateTime.Now.Subtract(TimeSpan.FromDays(daysToSubtract));
            return new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
        }

        public static DateTime GetEndOfLastWeek()
        {
            var dt = GetStartOfLastWeek().AddDays(6);
            return new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59, 999);
        }

        public static DateTime GetStartOfCurrentWeek()
        {
            int daysToSubtract = (int)DateTime.Now.DayOfWeek;
            var dt = DateTime.Now.Subtract(TimeSpan.FromDays(daysToSubtract));
            return new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
        }

        public static DateTime GetEndOfCurrentWeek()
        {
            var dt = GetStartOfCurrentWeek().AddDays(6);
            return new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59, 999);
        }

        ////public static DateTime GetBeginingDateForWeek(int year, int weekNumber)
        ////{
        ////    //find the first day of the first week (skips days of the last week of previous year)
        ////    var date = new DateTime(year, 1, 1);
        ////    while (date. != 1)
        ////    {
        ////        date = date.AddDays(1);
        ////    }

        ////    date = date.AddDays((weekNumber - 1)*7);

        ////    return date;
        ////}

        ////public static DateTime GetEndingDateForWeek(int year, int weekNumber)
        ////{
        ////    var date = GetBeginingDateForWeek(year, weekNumber);
        ////    date = date.AddDays(6);

        ////    return date;
        ////}
        #endregion

        #region Months
        public static DateTime GetStartOfMonth(int month, int year)
        {
            return new DateTime(year, month, 1, 0, 0, 0, 0);
        }

        public static DateTime GetEndOfMonth(int month, int year)
        {
            return new DateTime(year, month, DateTime.DaysInMonth(year, month), 23, 59, 0);
        }

        public static DateTime GetStartOfLastMonth()
        {
            return DateTime.Now.Month == 1
                       ? GetStartOfMonth(12, DateTime.Now.Year - 1)
                       : GetStartOfMonth(DateTime.Now.Month - 1, DateTime.Now.Year);
        }

        public static DateTime GetEndOfLastMonth()
        {
            return DateTime.Now.Month == 1
                       ? GetEndOfMonth(12, DateTime.Now.Year - 1)
                       : GetEndOfMonth(DateTime.Now.Month - 1, DateTime.Now.Year);
        }

        public static DateTime GetStartOfCurrentMonth()
        {
            return GetStartOfMonth(DateTime.Now.Month, DateTime.Now.Year);
        }

        public static DateTime GetEndOfCurrentMonth()
        {
            return GetEndOfMonth(DateTime.Now.Month, DateTime.Now.Year);
        }
        #endregion

        #region Years
        public static DateTime GetStartOfYear(int year)
        {
            return new DateTime(year, 1, 1, 0, 0, 0, 0);
        }

        public static DateTime GetEndOfYear(int year)
        {
            return new DateTime(year, 12, DateTime.DaysInMonth(year, 12), 23, 59, 59, 999);
        }

        public static DateTime GetStartOfLastYear()
        {
            return GetStartOfYear(DateTime.Now.Year - 1);
        }

        public static DateTime GetEndOfLastYear()
        {
            return GetEndOfYear(DateTime.Now.Year - 1);
        }

        public static DateTime GetStartOfCurrentYear()
        {
            return GetStartOfYear(DateTime.Now.Year);
        }

        public static DateTime GetEndOfCurrentYear()
        {
            return GetEndOfYear(DateTime.Now.Year);
        }
        #endregion

        #region Days
        public static DateTime GetStartOfDay(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
        }

        public static DateTime GetEndOfDay(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);
        }
        #endregion

        #region Constructors
        public static DateTime GetDate(DateTime date, TimeSpan time)
        {
            return new DateTime(date.Year, date.Month, date.Day, time.Hours, time.Minutes, time.Seconds, time.Milliseconds);
        }

        public static DateTime GetDate(DateTime datePart, DateTime timePart)
        {
            return new DateTime(datePart.Year, datePart.Month, datePart.Day, timePart.Hour, timePart.Minute, timePart.Second, timePart.Millisecond);
        }
        #endregion
    }
}