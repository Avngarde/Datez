using Datez.Helpers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatezTests
{
    public class TimeDifferenceTest
    {
        [Fact]
        public void CalculateTimeDifference_ReturnsOneYearTwoMonthsTwoDays()
        {
            DateTime testEvent = DateTime.Parse("2026-08-26");
            DateTime testCurrentDate = DateTime.Parse("2025-06-25");
            var timeDiff = TimeDifference.Calculate(testEvent, testCurrentDate);

            Assert.Equal(1, timeDiff.Years);
            Assert.Equal(2, timeDiff.Months);
            Assert.Equal(2, timeDiff.Days);
        }
    }
}
