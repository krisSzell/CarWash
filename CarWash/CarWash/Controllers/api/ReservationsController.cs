using AutoMapper;
using CarWash.Core.UseCases.Logging;
using CarWash.Persistence.Dtos;
using CarWash.Persistence.Models;
using CarWash.Persistence.Repositories;
using CarWash.Persistence.UseCases.Reservations;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;

namespace CarWash.Controllers.api
{
    [RoutePrefix("api/reservations")]
    public class ReservationsController : ApiController
    {
        private readonly ILoggingService _logger;
        private readonly IReservationsService _reservationsService;
        private readonly IAuthRepository _authRepository;

        public ReservationsController(IReservationsService service, IAuthRepository authRepo, ILoggingService logger)
        {
            _logger = logger;
            _reservationsService = service;
            _authRepository = authRepo;
        }

        [Route("unconfirmed")]
        [HttpGet]
        public IHttpActionResult GetUnconfirmed()
        {
            var unconfirmedReservations = _reservationsService.GetUnconfirmed().ToList();
            var resultData = new List<ReservationDto>();

            foreach (var reservation in unconfirmedReservations)
            {
                resultData.Add(Mapper.Map<Reservation, ReservationDto>(reservation));
            }

            return Ok(resultData);
        }

        [Route("confirmed")]
        [HttpGet]
        public IHttpActionResult GetConfirmed()
        {
            var confirmedReservations = _reservationsService.GetConfirmed().ToList();
            var resultData = new List<ReservationDto>();

            foreach (var reservation in confirmedReservations)
            {
                resultData.Add(Mapper.Map<Reservation, ReservationDto>(reservation));
            }

            return Ok(resultData);
        }

        [Route("confirm")]
        [HttpPost]
        public IHttpActionResult Confirm([FromBody]int reservationId)
        {
            _reservationsService.Confirm(reservationId);
            _logger.AddUser(getUsernameFromRequest());
            _logger.AddOperationMade("confirmed reservation");
            _logger.AddDetails("id: " + reservationId);
            _logger.Log();
            return Ok();
        }

        [Route("reject")]
        [HttpPost]
        public IHttpActionResult Reject([FromBody]int reservationId)
        {
            _reservationsService.Reject(reservationId);
            _logger.AddUser(getUsernameFromRequest());
            _logger.AddOperationMade("rejected reservation");
            _logger.AddDetails("id: " + reservationId);
            _logger.Log();
            return Ok();
        }

        [Authorize]
        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody]ReservationDto value)
        {
            var user = _authRepository.FindUserByUsername(value.Username);
            var reservation = Mapper.Map<ReservationDto,Reservation>(value);
            reservation.UserId = user.Id;

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

        private string getUsernameFromRequest()
        {
            var headers = Request.Headers;
            if (headers.Contains("username"))
            {
                return headers.GetValues("username").First();
            }
            return "";
        }
    }
}
