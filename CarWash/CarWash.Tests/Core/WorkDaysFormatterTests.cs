using CarWash.Persistence.Models;
using CarWash.Persistence.UseCases.WorkDays;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CarWash.Tests.Core
{
    [TestClass]
    public class WorkDaysFormatterTests
    {
        [TestMethod]
        public void ShouldReturnListOfUpcomingWeekdaysAsString_DAYdotMONTH()
        {
            // given
            var formatter = new WorkDaysFormatter();
            var expectedList = new List<string>()
            {
                "11.11",
                "12.11",
                "13.11"
            };
            var listOfDaysToFormat = new List<WorkDay>()
            {
                new WorkDay(new DateTime(2017,11,11)),
                new WorkDay(new DateTime(2017,11,12)),
                new WorkDay(new DateTime(2017,11,13))
            };

            // when
            var resultList = formatter.WorkDaysToString(listOfDaysToFormat);

            // then
            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(expectedList[i], resultList[i]);
            }
        }

        [TestMethod]
        public void ShouldReturnMonthAndDayWithZeroBeforeNumberWhenNumberHasOneLetter()
        {
            // given
            var formatter = new WorkDaysFormatter();
            var expectedList = new List<string>()
            {
                "01.01",
                "02.01",
                "03.01"
            };
            var listOfDaysToFormat = new List<WorkDay>()
            {
                new WorkDay(new DateTime(2017,01,01)),
                new WorkDay(new DateTime(2017,01,02)),
                new WorkDay(new DateTime(2017,01,03))
            };

            // when
            var resultList = formatter.WorkDaysToString(listOfDaysToFormat);

            // then
            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(expectedList[i], resultList[i]);
            }
        }

        [TestMethod]
        public void ShouldReturnStringOf4WorkHoursGivenWorkDayAt3Oclock()
        {
            // given
            var formatter = new WorkDaysFormatter();
            var workDay = new WorkDay(new DateTime(2017, 01, 01, 15, 0, 0));
            var expected = new List<string>()
            {
                "15:00",
                "15:15",
                "15:30",
                "15:45"
            };

            // when
            var result = formatter.WorkingHoursLeftToString(workDay);

            // then
            Assert.AreEqual(expected.Count, result.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }
    }
}
