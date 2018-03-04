using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SCFOWebsite.Models;
using SCFOWebsite.ViewModels.Home;

namespace SCFOWebsite.Controllers
{
    public class UsersCRUDController : Controller
    {
        private AllContext db = new AllContext();

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

            Org org = db.Orgs.Find(id);           
            return PartialView(org);
        }

        // GET: UsersCRUD/Details/5
        public ActionResult Details(int? id)
        {

            User u = (User)Session["loggedIn"];

            if (id == null)
            {
                if (u != null)
                {
                    id = u.userId;
                } else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                }
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
            ViewBag.orgs = new SelectList(db.Orgs, "OrgId", "Name");        
            return View();
        }

        // POST: UsersCRUD/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "orgId,username,handle,email,pwd,retype,admin")]  ViewModels.Home.RegisterViewModel user)
        {
            if (ModelState.IsValid)
            {
                User validUser = user as User;
                db.Users.Add(validUser);
                db.SaveChanges();
                return RedirectToAction("login", "Users");
            }

            ViewBag.orgs = new SelectList(db.Orgs, "OrgId", "Name");
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
        public ActionResult Edit([Bind(Include = "orgId,username,handle,email,pwd,admin")] User user)
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
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Organizations", "Organizations");
        }

        public ActionResult RemoveFromOrg(int id)
        {
            User user = db.Users.Find(id);
            user.orgId = 1;
            db.Entry(user).State = EntityState.Modified;
            //db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Organizations", "Organizations");
        }

        public ActionResult admin(int id)
        {
            User user = db.Users.Find(id);
            user.admin = !user.admin;
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
