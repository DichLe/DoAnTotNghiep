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

namespace API.Controllers.Admin
{
    public class LoaiNhasController : ApiController
    {
        private NhaDatEntities db = new NhaDatEntities();

        // GET: api/LoaiNhas
        public IQueryable<LoaiNha> GetLoaiNhas()
        {
            return db.LoaiNhas;
        }

        // GET: api/LoaiNhas/5
        [ResponseType(typeof(LoaiNha))]
        public IHttpActionResult GetLoaiNha(int id)
        {
            LoaiNha loaiNha = db.LoaiNhas.Find(id);
            if (loaiNha == null)
            {
                return NotFound();
            }

            return Ok(loaiNha);
        }

        // PUT: api/LoaiNhas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLoaiNha(int id, LoaiNha loaiNha)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != loaiNha.MaLoai)
            {
                return BadRequest();
            }

            db.Entry(loaiNha).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoaiNhaExists(id))
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

        // POST: api/LoaiNhas
        [ResponseType(typeof(LoaiNha))]
        public IHttpActionResult PostLoaiNha(LoaiNha loaiNha)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LoaiNhas.Add(loaiNha);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = loaiNha.MaLoai }, loaiNha);
        }

        // DELETE: api/LoaiNhas/5
        [ResponseType(typeof(LoaiNha))]
        public IHttpActionResult DeleteLoaiNha(int id)
        {
            LoaiNha loaiNha = db.LoaiNhas.Find(id);
            if (loaiNha == null)
            {
                return NotFound();
            }

            db.LoaiNhas.Remove(loaiNha);
            db.SaveChanges();

            return Ok(loaiNha);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LoaiNhaExists(int id)
        {
            return db.LoaiNhas.Count(e => e.MaLoai == id) > 0;
        }
    }
}