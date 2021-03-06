﻿using CarWash.Persistence.UseCases.WorkDays;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace CarWash.Tests.Core
{
    [TestClass]
    public class WorkDaysFactoryTests
    {
        [TestMethod]
        public void ShouldNotReturnWeekendDays()
        {
            // given
            var factory = new WorkDaysFactory();
            var expected = true;

            // when
            var resultList = factory.GetNext5WorkDays();
            var actual = resultList.Any(d =>
                {
                    if (d.GetDayOfWeek() == DayOfWeek.Saturday)
                    {
                        return false;
                    }
                    if (d.GetDayOfWeek() == DayOfWeek.Sunday)
                    {
                        return false;
                    }
                    return true;
                });

            // then
            Assert.AreEqual(expected, actual);
        }
    }
}
