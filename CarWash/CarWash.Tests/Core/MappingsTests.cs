using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarWash.Persistence.Dtos;
using CarWash.Persistence.Models;
using CarWash.Persistence.UseCases.Mapping;

namespace CarWash.Tests.Core
{
    [TestClass]
    public class MappingsTests
    {
        public ReservationDto ReservationDto { get; set; }
        public Reservation Reservation { get; set; }

        [TestInitialize]
        public void SetupTests()
        {
            Date date = new Date()
            {
                Year = 2017,
                Month = 8,
                Day = 31,
                Hour = "08:30"
            };
            Service service = new Service()
            {
                DurationInMinutes = 15,
                Name = "Srebrny",
                Price = 15,
                ServiceId = 2
            };
            string userId = "aaa-aaa-aaa";
            Schedule schedule = new Schedule()
            {
                StartDate = new DateTime(2017, 8, 31, 8, 30, 0),
                EndDate = new DateTime(2017, 8, 31, 8, 45, 0),
                IsAvailable = false
            };

            ReservationDto = new ReservationDto()
            {
                Date = date,
                Service = service,
                UserId = userId
            };
            Reservation = new Reservation()
            {
                Service = service,
                Status = new Status() { IsAccepted = false, IsArchived = false },
                Schedule = schedule,
                UserId = userId
            };
        }

        [TestMethod]
        public void ShouldCorrectlyMapReservationDtoToReservation()
        {
            // given 
            ReservationDto dto = ReservationDto;
            var mapper = new ReservationDtoToReservationConverter();
            Reservation expected = Reservation;

            // when
            var result = mapper.Convert(dto, null, null);

            // then
            Assert.IsTrue(areSchedulesEqual(expected.Schedule, result.Schedule));
            Assert.IsTrue(areServicesEqual(expected.Service, result.Service));
            Assert.AreEqual(expected.Status.IsAccepted, false);
            Assert.AreEqual(expected.Status.IsArchived, false);
            Assert.AreEqual(expected.UserId, result.UserId);
        }

        private bool areSchedulesEqual(Schedule obj1, Schedule obj2)
        {
            var result = false;
            result = obj1.StartDate == obj2.StartDate ? true : false;
            result = obj1.EndDate == obj2.EndDate ? true : false;
            result = obj1.IsAvailable == obj2.IsAvailable ? true : false;

            return result;
        }
        private bool areServicesEqual(Service obj1, Service obj2)
        {
            var result = false;
            result = obj1.DurationInMinutes == obj2.DurationInMinutes ? true : false;
            result = obj1.Name == obj2.Name ? true : false;
            result = obj1.Price == obj2.Price ? true : false;
            result = obj1.ServiceId == obj2.ServiceId ? true : false;

            return result;
        }
    }
}
