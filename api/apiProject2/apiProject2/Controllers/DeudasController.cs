using apiProject2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using apiProject2.Services;
using System.Web.Http;

namespace apiProject2.Controllers
{
    public class DeudasController:ApiController
    {
        public IHttpActionResult Get(int id)
        {
            if (id==null||id==0)
            {
                return BadRequest();
            }
            Deuda elem = new Deuda();
            elem = data.getSingleDeudaById(id);
            return Ok(elem);
        }
    }
}