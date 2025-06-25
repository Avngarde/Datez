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
            int days = 0;
            int months = 0;
            int years = 0;

            TimeSpan diff = eventDate - currentDate;
            int daysDiff = diff.Days;
            if (daysDiff >= 365)
            {
                years = daysDiff / 365;
                daysDiff = daysDiff - 365 * years;
            }

            if (daysDiff >= 30)
            {
                months = daysDiff / 30;
                daysDiff = daysDiff - 30 * months;
            }

            if (daysDiff < 30)
            {
                days = daysDiff;
            }


            return new TimeDiff()
            {
                Years = years,
                Months = months,
                Days = days
            };
        }

        public static int CalculateTimeProgress(int daysDifference, int originalDaysDifference)
        {
            double percent = (double)daysDifference / (double)originalDaysDifference;
            return (int)(percent * 100);
        }
    }
}
