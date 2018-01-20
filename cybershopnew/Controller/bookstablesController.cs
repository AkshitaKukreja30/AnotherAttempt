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
    public class bookstablesController : ApiController
    {
        private cygnewEntities1 db = new cygnewEntities1();

        // GET: api/bookstables
        public IQueryable<bookstable> Getbookstables()
        {
            return db.bookstables;
        }

        // GET: api/bookstables/5
        [ResponseType(typeof(bookstable))]
        public IHttpActionResult Getbookstable(int id)
        {
            bookstable bookstable = db.bookstables.Find(id);
            if (bookstable == null)
            {
                return NotFound();
            }

            return Ok(bookstable);
        }

        // PUT: api/bookstables/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putbookstable(int id, bookstable bookstable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bookstable.Sno)
            {
                return BadRequest();
            }

            db.Entry(bookstable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!bookstableExists(id))
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

        // POST: api/bookstables
        [ResponseType(typeof(bookstable))]
        public IHttpActionResult Postbookstable(bookstable bookstable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.bookstables.Add(bookstable);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (bookstableExists(bookstable.Sno))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = bookstable.Sno }, bookstable);
        }

        // DELETE: api/bookstables/5
        [ResponseType(typeof(bookstable))]
        public IHttpActionResult Deletebookstable(int id)
        {
            bookstable bookstable = db.bookstables.Find(id);
            if (bookstable == null)
            {
                return NotFound();
            }

            db.bookstables.Remove(bookstable);
            db.SaveChanges();

            return Ok(bookstable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool bookstableExists(int id)
        {
            return db.bookstables.Count(e => e.Sno == id) > 0;
        }
    }
}