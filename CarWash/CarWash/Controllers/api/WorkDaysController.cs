using CarWash.Core.UseCases.WorkDays;
using CarWash.Persistence.Dtos;
using CarWash.Persistence.UseCases.WorkDays;
using System.Collections.Generic;
using System.Web.Http;

namespace CarWash.Controllers.api
{
    public class WorkDaysController : ApiController
    {
        private readonly IWorkDaysFactory _workDaysFactory;
        private readonly IWorkDaysFormatter _workDaysFormatter;
        private readonly IWorkHoursValidator _workHoursValidator;

        public WorkDaysController(
            IWorkDaysFactory factory,
            IWorkDaysFormatter formatter,
            IWorkHoursValidator validator)
        {
            _workDaysFactory = factory;
            _workDaysFormatter = formatter;
            _workHoursValidator = validator;
        }

        [Route("api/workdays")]
        [HttpGet]
        public IHttpActionResult GetUpcomingWorkDays()
        {
            var workDaysDtos = new List<WorkDayDto>();
            var workDays = _workDaysFactory.GetNext5WorkDays();
            _workHoursValidator.CheckAndUpdate(workDays);

            foreach (var workDay in workDays)
            {
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
