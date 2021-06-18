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
    public class MuaThueNhasController : ApiController
    {
        private NhaDatEntities db = new NhaDatEntities();

        // GET: api/MuaThueNhas
        public IQueryable<MuaThueNha> GetMuaThueNhas()
        {
            return db.MuaThueNhas;
        }

        // GET: api/MuaThueNhas/5
        [ResponseType(typeof(MuaThueNha))]
        public IHttpActionResult GetMuaThueNha(int id)
        {
            MuaThueNha muaThueNha = db.MuaThueNhas.Find(id);
            if (muaThueNha == null)
            {
                return NotFound();
            }

            return Ok(muaThueNha);
        }

        // PUT: api/MuaThueNhas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMuaThueNha(int id, MuaThueNha muaThueNha)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != muaThueNha.Id)
            {
                return BadRequest();
            }

            db.Entry(muaThueNha).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MuaThueNhaExists(id))
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

        // POST: api/MuaThueNhas
        [ResponseType(typeof(MuaThueNha))]
        public IHttpActionResult PostMuaThueNha(MuaThueNha muaThueNha)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MuaThueNhas.Add(muaThueNha);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = muaThueNha.Id }, muaThueNha);
        }

        // DELETE: api/MuaThueNhas/5
        [ResponseType(typeof(MuaThueNha))]
        public IHttpActionResult DeleteMuaThueNha(int id)
        {
            MuaThueNha muaThueNha = db.MuaThueNhas.Find(id);
            if (muaThueNha == null)
            {
                return NotFound();
            }

            db.MuaThueNhas.Remove(muaThueNha);
            db.SaveChanges();

            return Ok(muaThueNha);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MuaThueNhaExists(int id)
        {
            return db.MuaThueNhas.Count(e => e.Id == id) > 0;
        }
    }
}