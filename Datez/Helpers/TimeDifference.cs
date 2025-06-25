using Datez.Helpers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Datez.Helpers
{
    public class TimeDifference
    {
        public static TimeDiff Calculate(DateTime eventDate, DateTime currentDate)
        {
            TimeSpan diff = eventDate - currentDate;
            return new TimeDiff()
            {
                Years = CalculateYearsDifference(diff.Days),
                Months = CalculateMonthDifference(diff.Days),
                Days = CalculateDaysDifference(diff.Days),
            };
        }

        public static int CalculateTimeProgress(int daysDifference, int originalDaysDifference)
        {
            double percent = (double)daysDifference / (double)originalDaysDifference;
            return (int)(percent * 100);
        }

        private static int CalculateMonthDifference(int daysDiff)
        {
            return (daysDiff / 30) - 12;
        }

        private static int CalculateYearsDifference(int daysDiff)
        {
            return daysDiff / 365;
        }

        private static int CalculateDaysDifference(int daysDiff)
        {
            int daysLeft = daysDiff;
            int yearsInTimeSpan = daysLeft / 365;
            daysLeft = daysLeft - 365 * yearsInTimeSpan;

            int monthsInTimeSpan = daysLeft / 30;
            daysLeft = daysLeft - 30 * monthsInTimeSpan;

            return daysLeft;
        }
    }
}
