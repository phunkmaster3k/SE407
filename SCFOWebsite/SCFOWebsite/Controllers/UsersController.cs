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
        
        public ActionResult Register()
        {
            var factory = new OrgFactory();
            var viewModel = new OrgViewModel(factory.Orgs);
            return View(viewModel);
        }

        public ActionResult Login()
        {

            //temp stuff!!
            var factory = new UserFactory();

            User user = new User();
            user = factory.Users.First();

            Session["LoggedIn"] = user;

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

        public ActionResult LoggedIn()
        {

            
            var userExists = true;
            if (userExists)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.res = "Invalid Login";
                return View("Response");
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