using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SCFOWebsite.Models;
using SCFOWebsite.ViewModels.Home;
using System.Data.Entity;

namespace SCFOWebsite.Controllers
{
    public class OrganizationsController : Controller
    {
        private AllContext db = new AllContext();

        public ActionResult Organizations()
        {        
            return View();
        }

        public ActionResult OrgSearch(string searchOrg, string by)
        {
            
            IQueryable<Org> orgs = db.Orgs.OrderBy(p => p.Name);

            if (searchOrg != null)
            {
                if (by == "Name")
                {
                    orgs = orgs.Where(p => p.Name.Contains(searchOrg));
                } else if ( by == "Focus")
                {
                    orgs = orgs.Where(p => p.Focus.Contains(searchOrg));
                }
                
            }

            var orgsList = orgs.Take(1000).ToList();
            var viewModel = new OrgViewModel(orgs);

            return PartialView(viewModel);
        }

        public ActionResult Addmember(string searchUser)
        {
            
            User userLoggedIn = (User)Session["loggedIn"];

            //get users not already in org
            var users = (from p in db.Users
                         where p.orgId != userLoggedIn.orgId
                         select p).ToList().AsQueryable(); 

            if (searchUser != null)
            {
                users = users.Where(p => p.username.Contains(searchUser));
            }

            var userList = users.Take(500).ToList();
            
            return View(userList);
        }

        public ActionResult AddToOrg(int? id)
        {
            
            User user = db.Users.Find(id);
            
            if (Session["LoggedIn"] != null)
            {
                User lg = (User)Session["loggedIn"];
                user.orgId = lg.orgId;
            }

            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            return View("Organizations");
        }

    }
}