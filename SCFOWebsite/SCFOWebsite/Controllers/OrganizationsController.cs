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

        public ActionResult Organizations()
        {        
            return View();
        }

        public ActionResult OrgSearch(string searchOrg, string by)
        {
            var factory = new OrgFactory();
            IQueryable<Org> orgs = factory.Orgs.OrderBy(p => p.Name);

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

            var orgsList = orgs.Take(100).ToList();
            var viewModel = new OrgViewModel(orgs);

            return PartialView(viewModel);
        }

        public ActionResult Addmember(string searchUser)
        {
            UserFactory fac = new UserFactory();
            User lg = (User)Session["loggedIn"];

            //get users not already in org
            var users = (from p in fac.Users
                         where p.orgId != lg.orgId
                         select p).ToList().AsQueryable(); 


            //var users = query.AsQueryable();

            if (searchUser != null)
            {
                users = users.Where(p => p.username.Contains(searchUser));
            }

            var userList = users.Take(500).ToList();
            
            return View(userList);
        }

        public ActionResult AddToOrg(int? id)
        {
            UserFactory fac = new UserFactory();
            User user = fac.Users.Find(id);
            
            if (Session["LoggedIn"] != null)
            {
                User lg = (User)Session["loggedIn"];
                user.orgId = lg.orgId;
            }

            fac.Entry(user).State = EntityState.Modified;
            fac.SaveChanges();
            return View("Organizations");
        }

    }
}