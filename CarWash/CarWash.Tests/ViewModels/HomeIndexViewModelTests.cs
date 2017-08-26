using System;
using System.Text;
using System.Collections.Generic;
using CarWash.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarWash.Tests.ViewModels
{
    [TestClass]
    public class HomeIndexViewModelTests
    {
        [TestMethod]
        public void ShouldReturnListOfUpcomingWeekdaysAsString_DAYdotMONTH()
        {
            // given
            var viewModel = new HomeIndexViewModel();
            var expectedList = new List<string>();
            for (int i = 0; i < 7; i++)
            {
                var day = DateTime.Now;
                day = day.AddDays(i);
                expectedList.Add(day.Day + "." + day.Month);
            }

            // when
            var resultList = viewModel.GetUpcomingWeekDays();

            // then
            for (int i = 0; i < 7; i++)
            {
                Assert.AreEqual(expectedList[i], resultList[i]);
            }
        }
    }
}
