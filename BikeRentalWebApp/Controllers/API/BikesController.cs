using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BikeRental.Model;
using BikeRentalWebApp.Model;

namespace BikeRentalWebApp.Controllers.API
{
    public class BikesController : ApiController
    {
        private BikeRentalContext db = new BikeRentalContext();

        // GET: api/Bikes
        public IQueryable<Bike> GetBikes()
        {
            return db.Bikes;
        }

        // GET: api/Bikes/5
        [ResponseType(typeof(Bike))]
        public IHttpActionResult GetBike(int id)
        {
            Bike bike = db.Bikes.Find(id);
            if (bike == null)
            {
                return NotFound();
            }

            return Ok(bike);
        }

        // PUT: api/Bikes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBike(int id, Bike bike)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bike.Id)
            {
                return BadRequest();
            }

            db.Entry(bike).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BikeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Bikes
        [ResponseType(typeof(Bike))]
        public IHttpActionResult PostBike(Bike bike)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bikes.Add(bike);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bike.Id }, bike);
        }

        // DELETE: api/Bikes/5
        [ResponseType(typeof(Bike))]
        public IHttpActionResult DeleteBike(int id)
        {
            Bike bike = db.Bikes.Find(id);
            if (bike == null)
            {
                return NotFound();
            }

            db.Bikes.Remove(bike);
            db.SaveChanges();

            return Ok(bike);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BikeExists(int id)
        {
            return db.Bikes.Count(e => e.Id == id) > 0;
        }
    }
}