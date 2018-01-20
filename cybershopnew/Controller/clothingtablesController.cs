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
    public class clothingtablesController : ApiController
    {
        private cygnewEntities1 db = new cygnewEntities1();

        // GET: api/clothingtables
        public IQueryable<clothingtable> Getclothingtables()
        {
            return db.clothingtables;
        }
    }
}

//        // GET: api/clothingtables/5
//        [ResponseType(typeof(clothingtable))]
//        public IHttpActionResult Getclothingtable(int id)
//        {
//            clothingtable clothingtable = db.clothingtables.Find(id);
//            if (clothingtable == null)
//            {
//                return NotFound();
//            }

//            return Ok(clothingtable);
//        }

//        // PUT: api/clothingtables/5
//        [ResponseType(typeof(void))]
//        public IHttpActionResult Putclothingtable(int id, clothingtable clothingtable)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            if (id != clothingtable.Sno)
//            {
//                return BadRequest();
//            }

//            db.Entry(clothingtable).State = EntityState.Modified;

//            try
//            {
//                db.SaveChanges();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!clothingtableExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return StatusCode(HttpStatusCode.NoContent);
//        }

//        // POST: api/clothingtables
//        [ResponseType(typeof(clothingtable))]
//        public IHttpActionResult Postclothingtable(clothingtable clothingtable)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            db.clothingtables.Add(clothingtable);

//            try
//            {
//                db.SaveChanges();
//            }
//            catch (DbUpdateException)
//            {
//                if (clothingtableExists(clothingtable.Sno))
//                {
//                    return Conflict();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return CreatedAtRoute("DefaultApi", new { id = clothingtable.Sno }, clothingtable);
//        }

//        // DELETE: api/clothingtables/5
//        [ResponseType(typeof(clothingtable))]
//        public IHttpActionResult Deleteclothingtable(int id)
//        {
//            clothingtable clothingtable = db.clothingtables.Find(id);
//            if (clothingtable == null)
//            {
//                return NotFound();
//            }

//            db.clothingtables.Remove(clothingtable);
//            db.SaveChanges();

//            return Ok(clothingtable);
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        private bool clothingtableExists(int id)
//        {
//            return db.clothingtables.Count(e => e.Sno == id) > 0;
//        }
//    }
//}