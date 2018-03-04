using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SCFOWebsite.Models;
using System.Web.Helpers;

namespace SCFOWebsite.Controllers
{
    public class ShipsCRUDController : Controller
    {
        private AllContext db = new AllContext();

        // GET: ShipsCRUD
        public ActionResult Index()
        {
            return View(db.Ships.ToList());
        }

        // GET: ShipsCRUD/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ship ship = db.Ships.Find(id);
            if (ship == null)
            {
                return HttpNotFound();
            }
            return View(ship);
        }

        // GET: ShipsCRUD/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShipsCRUD/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShipId,Name,Manufacturer,Role,ProductionState,CargoCapacity,MaxCrew,MinCrew,SCMSpeed,ABSpeed")] Ship ship)
        {
            if (ModelState.IsValid)
            {
                db.Ships.Add(ship);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ship);
        }

        // GET: ShipsCRUD/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ship ship = db.Ships.Find(id);
            if (ship == null)
            {
                return HttpNotFound();
            }
            return View(ship);
        }

        // POST: ShipsCRUD/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShipId,Name,Manufacturer,Role,ProductionState,CargoCapacity,MaxCrew,MinCrew,SCMSpeed,ABSpeed")] Ship ship)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ship).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ship);
        }

        // GET: ShipsCRUD/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ship ship = db.Ships.Find(id);
            if (ship == null)
            {
                return HttpNotFound();
            }
            return View(ship);
        }

        // POST: ShipsCRUD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ship ship = db.Ships.Find(id);
            db.Ships.Remove(ship);
            db.SaveChanges();
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

        public ActionResult Image(int id)
        {
            
            var ship = db.Ships.Where(p => p.ShipId == id).FirstOrDefault();

            if (ship == null)
            {
                return HttpNotFound();
            }

            var img = new WebImage(string.Format("~/Content/Images/{0}.jpg", ship.ImageName));
            img.Resize(100, 100);

            return File(img.GetBytes(), "image/jpg");
        }

        public ActionResult AddShip(int id)
        {
            if (Session["LoggedIn"] != null)
            {
                
                User user = (User)Session["loggedIn"];
                    
                db.playerShips.Add(new PlayerShips()
                {
                    shipId = id,
                    playerId = user.userId,
                });

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        public ActionResult myShips()
        {      
            User user = (User)Session["loggedIn"];
            //TODO: see if I can do join now
            var IDs = (from p in db.playerShips
                       where p.playerId == user.userId
                       select p.shipId).ToArray();

            List<Ship> myShips = new List<Ship>();
            //because we want to have duplicates shown
            foreach (int ship in IDs)
            {
                myShips.Add(db.Ships.FirstOrDefault(s => s.ShipId == ship));
            }

            return PartialView(myShips.OrderBy(o => o.ShipId).AsEnumerable());
        }

        public ActionResult removeShip(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = (User)Session["loggedIn"];

            var shipId = db.playerShips.FirstOrDefault(s => s.shipId == id && s.playerId == user.userId);

            Ship ship = db.Ships.Find(id);
            if (shipId == null)
            {
                return HttpNotFound();
            }

            db.playerShips.Remove(shipId);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
