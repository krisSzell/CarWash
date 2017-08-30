using CarWash.Core.Dtos;
using System.Collections.Generic;
using System.Web.Http;

namespace CarWash.Controllers.api
{
    public class ReservationsController : ApiController
    {
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

        public void Post([FromBody]ReservationDto value)
        {
            var reservationJson = value;
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
