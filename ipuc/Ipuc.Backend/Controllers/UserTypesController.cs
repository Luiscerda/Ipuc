namespace Ipuc.Backend.Controllers
{
    using Domain;
    using Ipuc.Backend.Models;
    using System.Data.Entity;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    [Authorize(Roles = "Admin")]
    public class UserTypesController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: UserTypes
        public async Task<ActionResult> Index()
        {
            return View(await db.UserTypes.ToListAsync());
        }

        // GET: UserTypes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserType userType = await db.UserTypes.FindAsync(id);
            if (userType == null)
            {
                return HttpNotFound();
            }
            return View(userType);
        }

        // GET: UserTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserTypes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "UserTypeId,Name")] UserType userType)
        {
            if (ModelState.IsValid)
            {
                db.UserTypes.Add(userType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(userType);
        }

        // GET: UserTypes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserType userType = await db.UserTypes.FindAsync(id);
            if (userType == null)
            {
                return HttpNotFound();
            }
            return View(userType);
        }

        // POST: UserTypes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UserTypeId,Name")] UserType userType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(userType);
        }

        // GET: UserTypes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserType userType = await db.UserTypes.FindAsync(id);
            if (userType == null)
            {
                return HttpNotFound();
            }
            return View(userType);
        }

        // POST: UserTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            UserType userType = await db.UserTypes.FindAsync(id);
            db.UserTypes.Remove(userType);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

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
