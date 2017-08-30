using AutoMapper;
using CarWash.Persistence.Dtos;
using CarWash.Persistence.Models;
using CarWash.Persistence.UseCases.Reservations;
using System.Collections.Generic;
using System.Web.Http;

namespace CarWash.Controllers.api
{
    public class ReservationsController : ApiController
    {
        private IReservationsService _reservationsService;

        public ReservationsController(IReservationsService service)
        {
            _reservationsService = service;
        }

        // GET: api/Reservations
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Reservations/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Reservations

        public IHttpActionResult Post([FromBody]ReservationDto value)
        {
            var reservation = Mapper.Map<ReservationDto,Reservation>(value);
            _reservationsService.BookReservation(reservation);

            return Created(Request.RequestUri.ToString(), reservation);
        }

        // PUT: api/Reservations/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Reservations/5
        public void Delete(int id)
        {
        }
    }
}
