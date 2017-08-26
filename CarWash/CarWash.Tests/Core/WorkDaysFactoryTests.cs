using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarWash.Core.UseCases.WorkDays;
using System.Collections.Generic;
using CarWash.Core.Models;

namespace CarWash.Tests.Core
{
    [TestClass]
    public class WorkDaysFactoryTests
    {
        [TestMethod]
        public void ShouldReturnMondayToFridayGivenMondayAsCurrentDay()
        {
            // given
            var factory = new WorkDaysFactory();
            var expected = new List<WorkDay>()
            {
            };

            // when

            // then
        }
    }
}
