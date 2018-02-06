using SCFOWebsite.Models;
using SCFOWebsite.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCFOWebsite.Controllers
{
    public class UsersController : Controller
    {
        
        public ActionResult Register()
        {
            var factory = new OrgFactory();
            var viewModel = new OrgViewModel(factory.Orgs);


            return View(viewModel);
        }

        public ActionResult Login()
        {



            return View();
        }
    }
}