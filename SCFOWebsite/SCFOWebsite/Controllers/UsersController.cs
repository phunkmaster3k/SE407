using SCFOWebsite.Models;
using SCFOWebsite.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace SCFOWebsite.Controllers
{
    public class UsersController : Controller
    {

        private AllContext db = new AllContext();

        public ActionResult Register()
        {
            var viewModel = new OrgViewModel(db.Orgs);
            return View(viewModel);
        }

        public ActionResult Login()
        {       
            return View();
        }

        public ActionResult LoggedIn(string password,string username)
        {
            User user = new User();
            try {
                user = db.Users.First(s => s.username == username);
                if (user.pwd == password)
                {
                    Session["LoggedIn"] = user;
                    return RedirectToAction("Index", "Home");
                } else
                {
                    ModelState.AddModelError("password", "Password Invalid");
                    return View("Login");
                }
            } catch
            {
                ModelState.AddModelError("username", "No user with that name");
                return View("Login");
            }          
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Registered()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}