using CarWash.Persistence.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CarWash.Tests.Core
{
    [TestClass]
    public class WorkDayTests
    {
        [TestMethod]
        public void ShouldReturnWorkingHoursWhenTimeOfDayIsBeforeStartingHour()
        {
            // given
            var dateTime = new DateTime(2017, 8, 1, 7, 0, 0);
            var workDay = new WorkDay(dateTime);
            var expectedHours = new List<WorkHour>();

            for (int i = 8; i < 16; i++)
            {
                for (int j = 0; j < 60; j += 15)
                {
                    expectedHours.Add(new WorkHour(i, j));
                }
            }

            // when
            var resultHours = workDay.GetRemainingHours();

            // then
            int index = 0;
            Assert.AreEqual(expectedHours.Count, resultHours.Count);
            foreach (var hour in resultHours)
            {
                Assert.AreEqual(hour.Hour, expectedHours[index].Hour);
                Assert.AreEqual(hour.Minute, expectedHours[index].Minute);
                index++;
            }
        }

        [TestMethod]
        public void ShouldReturnSubsetOfWorkingHoursStartingWithEqualHourInTheMiddleOfOpenHours()
        {
            // given
            var dateTime = new DateTime(2017, 8, 1, 14, 0, 0);
            var workDay = new WorkDay(dateTime);
            var expectedHours = new List<WorkHour>();

            for (int i = 14; i < 16; i++)
            {
                for (int j = 0; j < 60; j += 15)
                {
                    expectedHours.Add(new WorkHour(i, j));
                }
            }

            // when
            var resultHours = workDay.GetRemainingHours();

            // then
            int index = 0;
            Assert.AreEqual(expectedHours.Count, resultHours.Count);
            foreach (var hour in resultHours)
            {
                Assert.AreEqual(hour.Hour, expectedHours[index].Hour);
                Assert.AreEqual(hour.Minute, expectedHours[index].Minute);
                index++;
            }
        }

        [TestMethod]
        public void ShouldReturnSubsetOfWorkHoursStartingWithNotEqualHourInTheMiddleOfOpenHours()
        {
            // given
            var dateTime = new DateTime(2017, 8, 1, 14, 30, 0);
            var workDay = new WorkDay(dateTime);
            var expectedHours = new List<WorkHour>();

            int startingMinute = 30;
            for (int i = 14; i < 16; i++)
            {
                for (int j = startingMinute; j < 60; j += 15)
                {
                    expectedHours.Add(new WorkHour(i, j));
                }
                startingMinute = 0;
            }

            // when
            var resultHours = workDay.GetRemainingHours();

            // then
            int index = 0;
            Assert.AreEqual(expectedHours.Count, resultHours.Count);
            foreach (var hour in resultHours)
            {
                Assert.AreEqual(hour.Hour, expectedHours[index].Hour);
                Assert.AreEqual(hour.Minute, expectedHours[index].Minute);
                index++;
            }
        }
    }
}
