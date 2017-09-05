using AutoMapper;
using CarWash.Persistence.Dtos;
using CarWash.Persistence.Models;
using CarWash.Persistence.Repositories;
using CarWash.Persistence.UseCases.Reservations;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;

namespace CarWash.Controllers.api
{
    [RoutePrefix("api/reservations")]
    public class ReservationsController : ApiController
    {
        private IReservationsService _reservationsService;
        private IAuthRepository _authRepository;

        public ReservationsController(IReservationsService service, IAuthRepository authRepo)
        {
            _reservationsService = service;
            _authRepository = authRepo;
        }

        [Route("unconfirmed")]
        public async Task<IHttpActionResult> GetUnconfirmed()
        {
            var unconfirmedReservations = await _reservationsService.GetUnconfirmed();

            return Ok(unconfirmedReservations);
        }

        // POST: api/Reservations
        [Authorize]
        public IHttpActionResult Post([FromBody]ReservationDto value)
        {
            var user = _authRepository.FindUserByUsername(value.Username);

            var reservation = Mapper.Map<ReservationDto,Reservation>(value);
            if (!_reservationsService.BookReservation(reservation))
            {
                return Conflict();
            }

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
