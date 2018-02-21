using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SCFOWebsite.Models;
using SCFOWebsite.ViewModels.Home;

namespace SCFOWebsite.Controllers
{
    public class OrganizationsController : Controller
    {

        private OrgFactory db = new OrgFactory();


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

    }
}