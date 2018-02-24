using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SCFOWebsite.Models;

namespace SCFOWebsite.Controllers
{
    public class UsersCRUDController : Controller
    {
        private UserFactory db = new UserFactory();

        // GET: UsersCRUD
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        public ActionResult List(int id)
        {
            var query = (from p in db.Users
                         where p.orgId == id
                         select p).ToList();

            return PartialView(query);
        }

        public ActionResult OrgName(int id) {

            OrgFactory f = new OrgFactory();
            Org org = f.Orgs.Find(id);
            
            return PartialView(org);
        }

        // GET: UsersCRUD/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: UsersCRUD/Create
        public ActionResult Create()
        {
            OrgFactory fac = new OrgFactory();
            List<SelectListItem> list = new List<SelectListItem>();
            SelectListItem itm = new SelectListItem { Text = "None", Value = "0" };
            list.Add(itm);

            foreach (Org o in fac.Orgs)
            {
                SelectListItem item = new SelectListItem { Text = o.Name, Value = o.OrgId.ToString() };
                list.Add(item);           
            }

            ViewBag.orgs = new SelectList(list, "Value", "Text");
            return View();
        }

        // POST: UsersCRUD/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userId,orgId,username,handle,email,pwd,admin")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("login", "Users");

            }

            return View(user);
        }

        // GET: UsersCRUD/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: UsersCRUD/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userId,orgId,username,handle,email,pwd,admin")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Organizations", "Organizations");

            }
            return View(user);
        }


        
        // GET: UsersCRUD/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: UsersCRUD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            user.orgId = 0;
            db.Entry(user).State = EntityState.Modified;
            //db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Organizations", "Organizations");
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
