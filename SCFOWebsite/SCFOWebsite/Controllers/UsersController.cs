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
            //Save for easy login
            /*User user = new User();
            user = db.Users.First();

            Session["LoggedIn"] = user;*/

            /*SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["NEITCON"].ConnectionString);

            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM test";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            con.Open();

            reader = cmd.ExecuteReader();

            string UserName;
            while (reader.Read())
            {
                UserName = (string)reader["Name"];
               
            } */

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