namespace Ipuc.Backend.Controllers
{
    using Domain;
    using Ipuc.Backend.Models;
    using System.Data.Entity;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    [Authorize(Roles = "Admin")]
    public class MembersController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: Members
        public async Task<ActionResult> Index()
        {
            return View(await db.Members.ToListAsync());
        }

        // GET: Members/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Members members = await db.Members.FindAsync(id);
            if (members == null)
            {
                return HttpNotFound();
            }
            return View(members);
        }

        //// GET: Members/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Members/Create
        //// Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        //// más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "Identificacion,FirstName,LastName,Telephone,Direccion,Bautizado")] Members members)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Members.Add(members);
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        //    return View(members);
        //}

        //// GET: Members/Edit/5
        //public async Task<ActionResult> Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Members members = await db.Members.FindAsync(id);
        //    if (members == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(members);
        //}

        //// POST: Members/Edit/5
        //// Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        //// más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "Identificacion,FirstName,LastName,Telephone,Direccion,Bautizado")] Members members)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(members).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(members);
        //}

        //// GET: Members/Delete/5
        //public async Task<ActionResult> Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Members members = await db.Members.FindAsync(id);
        //    if (members == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(members);
        //}

        //// POST: Members/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(string id)
        //{
        //    Members members = await db.Members.FindAsync(id);
        //    db.Members.Remove(members);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
