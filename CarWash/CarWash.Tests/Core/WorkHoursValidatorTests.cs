using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarWash.Persistence.Models;
using System.Collections.Generic;
using CarWash.Core.UseCases.WorkDays;
using Moq;
using CarWash.Persistence.Repositories;

namespace CarWash.Tests.Core
{
    [TestClass]
    public class WorkHoursValidatorTests
    {
        [TestMethod]
        public void ShouldRemoveScheduledHoursFromRemainingWorkHoursInDay()
        {
            // given
            var repoMock = new Mock<IReservationsRepository>();
            var workHoursValidator = new WorkHoursValidator(repoMock.Object);
            var workDay = new WorkDay(new DateTime(2017, 8, 1, 7, 0, 0));
            var schedule = new Schedule()
            {
                StartDate = new DateTime(2017, 8, 1, 11, 15, 0),
                EndDate = new DateTime(2017, 8, 1, 11, 45, 0)
            };
            var expected = workDay.GetRemainingHours();
            expected.Remove(new WorkHour(11, 15));
            expected.Remove(new WorkHour(11, 30));

            // when
            workHoursValidator.CheckAndUpdate(new List<WorkDay>() { workDay });
            var result = workDay.GetRemainingHours();

            // then
            Assert.AreEqual(expected.Count, result.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }
    }
}
