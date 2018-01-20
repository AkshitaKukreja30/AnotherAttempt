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
using cybershopnew.Model;

namespace cybershopnew.Controller
{
    public class accessoriesController : ApiController
    {
        private cygnewEntities1 db = new cygnewEntities1();

        // GET: api/accessories/Getaccessories
        public IQueryable<accessory> Getaccessories()
        {
            return db.accessories;
        }

        // GET: api/accessories/5
        [ResponseType(typeof(accessory))]
        public IHttpActionResult Getaccessory(int id)
        {
            accessory accessory = db.accessories.Find(id);
            if (accessory == null)
            {
                return NotFound();
            }

            return Ok(accessory);
        }

        // PUT: api/accessories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putaccessory(int id, accessory accessory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accessory.Sno)
            {
                return BadRequest();
            }

            db.Entry(accessory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!accessoryExists(id))
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

        // POST: api/accessories
        [ResponseType(typeof(accessory))]
        public IHttpActionResult Postaccessory(accessory accessory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.accessories.Add(accessory);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (accessoryExists(accessory.Sno))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = accessory.Sno }, accessory);
        }

        // DELETE: api/accessories/5
        [ResponseType(typeof(accessory))]
        public IHttpActionResult Deleteaccessory(int id)
        {
            accessory accessory = db.accessories.Find(id);
            if (accessory == null)
            {
                return NotFound();
            }

            db.accessories.Remove(accessory);
            db.SaveChanges();

            return Ok(accessory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool accessoryExists(int id)
        {
            return db.accessories.Count(e => e.Sno == id) > 0;
        }
    }
}