using System;
using System.Collections.Generic;

using System.Diagnostics.Contracts;

using System.Globalization;
using Pie.Math;
using Pie.Strings;

namespace Pie.Time
{
    /// <summary>
    /// A static class with extension methods for date and time.
    /// </summary>
    public static class TimeExtensions
    {
        /// <summary>
        /// Sets the current instance to the specified hour, minute, second and millisecond.
        /// </summary>
        /// <param name="datetime">The current instance.</param>
        /// <param name="hour">The specified hour.</param>
        /// <param name="minute">The specified minute.</param>
        /// <param name="second">The specified second.</param>
        /// <param name="millisecond">The specified millisecond.</param>
        /// <returns>The new DateTime.</returns>
        public static DateTime At(this DateTime datetime, int hour, int minute = 0, int second = 0, int millisecond = 0)
        {
            Contract.Requires(hour >= 0 && hour <= 23);
            Contract.Requires(minute >= 0 && hour <= 59);
            Contract.Requires(second >= 0 && second <= 59);
            Contract.Requires(millisecond >= 0 && millisecond <= 999);

            return new DateTime(datetime.Year, datetime.Month, datetime.Day, hour, minute, second, millisecond);
        }

        #region To

        /// <summary>
        /// Returns a collection of DateTimes with a one date interval.
        /// </summary>
        /// <param name="from">The current instance, or the DateTime to start at.</param>
        /// <param name="to">The DateTime to end at.</param>
        /// <returns>A collection of DateTimes with a one date interval.</returns>
        public static IEnumerable<DateTime> To(this DateTime from, DateTime to)
        {
            return from.To(to, TimeSpan.FromDays(1));
        }

        /// <summary>
        /// Returns a collection of DateTimes with the specified interval.
        /// </summary>
        /// <param name="from">The current instance, or the DateTime to start at.</param>
        /// <param name="to">The DateTime to end at.</param>
        /// <param name="step">The step to take on each iteration.</param>
        /// <returns>A collection of DateTimes with a one date interval.</returns>
        public static IEnumerable<DateTime> To(this DateTime from, DateTime to, TimeSpan step)
        {
            if (from <= to)
            {
                do
                {
                    yield return from;
                    from += step;
                }
                while (from <= to);
            }
            else if (from > to)
            {
                do
                {
                    yield return from;
                    from -= step;
                } while (from >= to);
            }
        }

        /// <summary>
        /// Returns a collection of DateTimes with a the specified interval.
        /// </summary>
        /// <param name="from">The current instance, or the DateTime to start at.</param>
        /// <param name="to">The DateTime to end at.</param>
        /// <param name="step">The step to take on each iteration.</param>
        /// <returns>A collection of DateTimes with a one date interval.</returns>
        public static IEnumerable<DateTime> To(this DateTime from, DateTime to, Func<DateTime, DateTime> step)
        {
            Contract.Requires(step != null);

            if (from <= to)
            {
                do
                {
                    yield return from;
                    from = step(from);
                }
                while (from <= to);
            }
            else if (from > to)
            {
                do
                {
                    yield return from;
                    from = step(from);
                } while (from >= to);
            }
        }

        #endregion To

        /// <summary>
        /// Returns what week of the year, the current instance is on.
        /// </summary>
        /// <param name="datetime">The current instance.</param>
        /// <returns>What week of the year, the current instance is on.</returns>
        public static int WeekOfYear(this DateTime datetime)
        {
            return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(datetime, CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);
        }

        /// <summary>
        /// Converts the specified int to a weekday
        /// </summary>
        /// <param name="day">The current int</param>
        /// <param name="start">The start of the week, defaults to Sunday(0)</param>
        /// <returns>A datetime with the current day of week</returns>
        public static DateTime AsDayOfWeek(this int day, int start = 0)
        {
            Contract.Requires(day >= 0);
            Contract.Requires(start >= 0);
            //3.3.2013 was a sunday, assume that day 0 is there
            return (new DateTime(2013, 3, 3)).AddDays((start + day) % 7);
        }

        /// <summary>
        /// Converts the datetime object into a string representing the current day of week in the current culture
        /// </summary>
        /// <param name="datetime">The current datetime object</param>
        /// <returns>A string with the day of week</returns>
        public static string ToStringDayOfWeek(this DateTime datetime)
        {
            return datetime.ToString("dddd").ToTitleCase();
        }

        #region Constellations
        /// <summary>
        /// Returns the constellation of the current DateTime object
        /// </summary>
        /// <param name="date">The current date</param>
        /// <returns>The name signifying the current constellation</returns>
        public static string Constellation(this DateTime date)
        {
            Contract.Requires(date != null);
            return date.Constellation(new string[] { "Steingeit", "Vatnsberi", "Fiskur", "Hrútur", "Naut", "Tvíburi", "Krabbi", "Ljón", "Meyja", "Vog", "Sporðdreki", "Bogmaður" });
        }

        /// <summary>
        /// Returns the constellation of the current DateTime object
        /// </summary>
        /// <param name="date">The current date</param>
        /// <param name="names">A string array containing all the names of the constellations in the current language</param>
        /// <returns>The name signifying the current constellation</returns>
        public static string Constellation(this DateTime date, string[] names)
        {
            Contract.Requires(date != null);
            Contract.Requires(names.Length == 12);
            switch (date.Month)
            {
                case 1: if (date.Day <= 20)
                    { return names[0]; }
                    else
                    { return names[1]; }
                case 2: if (date.Day <= 19)
                    { return names[1]; }
                    else
                    { return names[2]; }
                case 3: if (date.Day <= 20)
                    { return names[2]; }
                    else
                    { return names[3]; }
                case 4: if (date.Day <= 20)
                    { return names[3]; }
                    else
                    { return names[4]; }
                case 5: if (date.Day <= 21)
                    { return names[4]; }
                    else
                    { return names[5]; }
                case 6: if (date.Day <= 22)
                    { return names[5]; }
                    else
                    { return names[6]; }
                case 7: if (date.Day <= 22)
                    { return names[6]; }
                    else
                    { return names[7]; }
                case 8: if (date.Day <= 23)
                    { return names[7]; }
                    else
                    { return names[8]; }
                case 9: if (date.Day <= 23)
                    { return names[8]; }
                    else
                    { return names[9]; }
                case 10: if (date.Day <= 23)
                    { return names[9]; }
                    else
                    { return names[10]; }
                case 11: if (date.Day <= 22)
                    { return names[10]; }
                    else
                    { return names[11]; }
                case 12: if (date.Day <= 21)
                    { return names[11]; }
                    else
                    { return names[0]; }
                default:
                    return "";
            }
        }
        #endregion
    }
}