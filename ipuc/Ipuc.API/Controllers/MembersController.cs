using System;
using System.Collections.Generic;
using System.Data;
namespace Ipuc.API.Controllers
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Description;
    using Domain;
    using Newtonsoft.Json;

    [RoutePrefix("api/Members")]
    public class MembersController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Members
        public IQueryable<Members> GetMembers()
        {
            return db.Members;
        }

        // GET: api/Members/5
        [ResponseType(typeof(Members))]
        public async Task<IHttpActionResult> GetMembers(string id)
        {
            Members members = await db.Members.FindAsync(id);
            if (members == null)
            {
                return NotFound();
            }

            return Ok(members);
        }

        // PUT: api/Members/5
        [Authorize]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMembers(string id, Members members)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != members.Identificacion)
            {
                return BadRequest();
            }

            db.Entry(members).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MembersExists(id))
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

        // POST: api/Members
        [ResponseType(typeof(Members))]
        public async Task<IHttpActionResult> PostMembers(Members members)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Members.Add(members);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MembersExists(members.Identificacion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = members.Identificacion }, members);
        }

        // DELETE: api/Members/5
        [ResponseType(typeof(Members))]
        public async Task<IHttpActionResult> DeleteMembers(string id)
        {
            Members members = await db.Members.FindAsync(id);
            if (members == null)
            {
                return NotFound();
            }

            db.Members.Remove(members);
            await db.SaveChangesAsync();

            return Ok(members);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MembersExists(string id)
        {
            return db.Members.Count(e => e.Identificacion == id) > 0;
        }
    }
}