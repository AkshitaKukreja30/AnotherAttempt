using cybershopnew.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace cybershopnew.Controller
{
    public class mobilestablesController : ApiController
    {
        private cygnewEntities1 db = new cygnewEntities1();

        // GET: api/mobilestable
        public IQueryable<mobilestable> Getmobilestables()
        {
            return db.mobilestables;
        }

        
    }
}
