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
using DataAccess.Models;
using DataAccess.Repositories;

namespace API.Controllers.Admin
{
    public class NhasController : ApiController
    {
        private NhaDatEntities db = new NhaDatEntities();
        private NhaRepository nhaRepository = new NhaRepository();
        private GiaNhaRepository giaNhaRepository = new GiaNhaRepository();

        // GET: api/Nhas
        public IQueryable<Nha> GetNhas()
        {
            return db.Nhas;
        }

        // GET: api/Nhas/5
        [ResponseType(typeof(Nha))]
        public IHttpActionResult GetNha(int id)
        {
            Nha nha = db.Nhas.Find(id);
            if (nha == null)
            {
                return NotFound();
            }

            return Ok(nha);
        }

        // PUT: api/Nhas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNha(int id, Nha nha)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nha.MaNha)
            {
                return BadRequest();
            }

            db.Entry(nha).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NhaExists(id))
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

        // POST: api/Nhas
        [ResponseType(typeof(Nha))]
        public IHttpActionResult PostNha(Nha nha)
        {
            if (!ModelState.IsValid|| nha.GiaHienTai==null)
            {
                return BadRequest(ModelState);
            }


            nhaRepository.Create(nha);
            giaNhaRepository.Create(nha.GiaHienTai);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = nha.MaNha }, nha);
        }

        // DELETE: api/Nhas/5
        [ResponseType(typeof(Nha))]
        public IHttpActionResult DeleteNha(int id)
        {
            Nha nha = db.Nhas.Find(id);
            if (nha == null)
            {
                return NotFound();
            }

            db.Nhas.Remove(nha);
            db.SaveChanges();

            return Ok(nha);
        }

        [HttpPost]
        [Route("tim-kiem")]
        public IHttpActionResult GetNhaTimKiem(int loaiNha, int xa, int huyen, int tinh, int trangthai, int loaiGia, decimal giaMin, decimal giaMax, int? index, int? size)
        {
            return Ok(nhaRepository.TimKiem(loaiNha, xa, huyen, tinh, trangthai, loaiGia, giaMin, giaMax, index, size));
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NhaExists(int id)
        {
            return db.Nhas.Count(e => e.MaNha == id) > 0;
        }
    }
}