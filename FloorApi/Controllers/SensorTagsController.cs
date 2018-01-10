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
using FloorApi.Models;

namespace FloorApi.Controllers
{
    public class SensorTagsController : ApiController
    {
        private SensorDbContext db = new SensorDbContext();

        // GET: api/SensorTags
        public IQueryable<SensorTag> GetSensorTags()
        {
            return db.SensorTags;
        }

        // GET: api/SensorTags/5
        [ResponseType(typeof(SensorTag))]
        public IHttpActionResult GetSensorTag(string id)
        {
            SensorTag sensorTag = db.SensorTags.Find(id);
            if (sensorTag == null)
            {
                return NotFound();
            }

            return Ok(sensorTag);
        }

        // PUT: api/SensorTags/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSensorTag(string id, SensorTag sensorTag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sensorTag.id)
            {
                return BadRequest();
            }

            db.Entry(sensorTag).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SensorTagExists(id))
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

        // POST: api/SensorTags
        [ResponseType(typeof(SensorTag))]
        public IHttpActionResult PostSensorTag(SensorTag sensorTag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SensorTags.Add(sensorTag);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SensorTagExists(sensorTag.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sensorTag.id }, sensorTag);
        }

        // DELETE: api/SensorTags/5
        [ResponseType(typeof(SensorTag))]
        public IHttpActionResult DeleteSensorTag(string id)
        {
            SensorTag sensorTag = db.SensorTags.Find(id);
            if (sensorTag == null)
            {
                return NotFound();
            }

            db.SensorTags.Remove(sensorTag);
            db.SaveChanges();

            return Ok(sensorTag);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SensorTagExists(string id)
        {
            return db.SensorTags.Count(e => e.id == id) > 0;
        }
    }
}