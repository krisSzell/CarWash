using CarWash.Core.Models;
using CarWash.Core.UseCases.WorkDays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarWash.ViewModels
{
    public class HomeIndexViewModel
    {
        private IWorkDaysFactory _factory;
        private IWorkDaysFormatter _formatter;
        public IList<WorkDay> WorkDays { get; set; }
        public IList<WorkHour> WorkHoursLeft { get; set; }


        public HomeIndexViewModel(IWorkDaysFactory factory, IWorkDaysFormatter formatter)
        {
            _factory = factory;
            _formatter = formatter;

            WorkDays = factory.GetNext5WorkDays();
        }

        public void SetWorkHoursLeft()
        {

        }

        public void ChooseDay()
        {

        }

    }
}