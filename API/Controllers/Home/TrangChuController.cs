using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers.Home
{
    public class TrangChuController : ApiController
    {
        public IHttpActionResult GetMenu()
        {
            return Ok();
        }

        public IHttpActionResult GetOnSaleProducts()
        {
            return Ok();
        }

        public IHttpActionResult LoginOrRegister()
        {
            return Ok();
        }

        public IHttpActionResult GetAboutUs()
        {
            return Ok();
        }
    }
}
