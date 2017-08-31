﻿using CarWash.Persistence.Dtos;
using CarWash.Persistence.UseCases.WorkDays;
using System.Collections.Generic;
using System.Web.Http;

namespace CarWash.Controllers.api
{
    public class WorkDaysController : ApiController
    {
        private readonly IWorkDaysFactory _workDaysFactory;
        private readonly IWorkDaysFormatter _workDaysFormatter;

        public WorkDaysController(
            IWorkDaysFactory factory,
            IWorkDaysFormatter formatter)
        {
            _workDaysFactory = factory;
            _workDaysFormatter = formatter;
        }

        [Route("api/workdays")]
        [HttpGet]
        public IHttpActionResult GetUpcomingWorkDays()
        {
            var workDaysDtos = new List<WorkDayDto>();
            var workDays = _workDaysFactory.GetNext5WorkDays();

            foreach (var workDay in workDays)
            {
                var hours = workDay.GetRemainingHours();

                var workingHours = new List<string>();
                workingHours.AddRange(_workDaysFormatter.WorkingHoursLeftToString(workDay));
                var workDayDto = new WorkDayDto()
                {
                    Year = workDay.GetYear(),
                    Day = workDay.GetDay(),
                    Month = workDay.GetMonth(),
                    WorkHours = workingHours,
                    IsSelected = false
                };
                workDaysDtos.Add(workDayDto);
            }
            workDaysDtos[0].IsSelected = true;

            return Ok(workDaysDtos);
        }
    }
}
