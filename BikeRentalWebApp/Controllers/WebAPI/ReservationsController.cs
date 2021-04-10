using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Routing;
using BikeRental.Model;
using BikeRentalWebApp.Model;

namespace BikeRentalWebApp.Controllers.WebAPI
{
    public class ReservationsController : ApiController
    {
        private BikeRentalContext db = new BikeRentalContext();

        // GET: api/Reservations
        public IQueryable<Reservation> GetReservations()
        {
            return db.Reservations;
        }

        // GET: api/Reservations/5
        [ResponseType(typeof(Reservation))]
        public IHttpActionResult GetReservation(int id)
        {
            var reservation = from r in db.Reservations where r.Customer_Id == id select r;
            if (reservation == null)
            {
                return NotFound();
            }

            return Ok(reservation);
        }
    }
}