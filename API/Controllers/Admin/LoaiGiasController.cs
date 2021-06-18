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
using DataAccess.Repositories.Interfaces;

namespace API.Controllers.Admin
{
    public class LoaiGiasController : ApiController
    {
        private NhaDatEntities db = new NhaDatEntities();
        private IBaseRepository<LoaiGia> baseRepository;

        public LoaiGiasController (IBaseRepository<LoaiGia> baseRepository)
        {
            this.baseRepository = baseRepository;
        }

        // GET: api/LoaiGias
        public IQueryable<LoaiGia> GetLoaiGias()
        {
            return db.LoaiGias;
        }

        // GET: api/LoaiGias/5
        [ResponseType(typeof(LoaiGia))]
        public IHttpActionResult GetLoaiGia(int id)
        {
            LoaiGia loaiGia = db.LoaiGias.Find(id);
            if (loaiGia == null)
            {
                return NotFound();
            }

            return Ok(loaiGia);
        }

        // PUT: api/LoaiGias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLoaiGia(int id, LoaiGia loaiGia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != loaiGia.Id)
            {
                return BadRequest();
            }

            db.Entry(loaiGia).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoaiGiaExists(id))
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

        // POST: api/LoaiGias
        [ResponseType(typeof(LoaiGia))]
        public IHttpActionResult PostLoaiGia(LoaiGia loaiGia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LoaiGias.Add(loaiGia);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = loaiGia.Id }, loaiGia);
        }

        // DELETE: api/LoaiGias/5
        [ResponseType(typeof(LoaiGia))]
        public IHttpActionResult DeleteLoaiGia(int id)
        {
            LoaiGia loaiGia = db.LoaiGias.Find(id);
            if (loaiGia == null)
            {
                return NotFound();
            }

            db.LoaiGias.Remove(loaiGia);
            db.SaveChanges();

            return Ok(loaiGia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LoaiGiaExists(int id)
        {
            return db.LoaiGias.Count(e => e.Id == id) > 0;
        }
    }
}