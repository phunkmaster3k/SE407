using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SCFOWebsite.Models;
using SCFOWebsite.ViewModels.Home;
using System.Data.Entity;
using System.Net.Mail;

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
            //get rid of the None org
            orgs = orgs.Where(s => s.OrgId != 1);

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
                         where p.orgId == 1
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

        public ActionResult joinOrg(int id)
        {

            User user = (User)Session["loggedIn"];
            Org org = db.Orgs.Find(id);
           
            //get all admin emails for org
            var emails = (from p in db.Users
                       where p.orgId == id && p.admin == true
                       select p.email).ToArray();

            MailMessage mail = new MailMessage();

            /*
            foreach (var email in emails)
            {
                mail.To.Add(email);
            } */

            mail.To.Add("antelope81796@yahoo.com");
            mail.From = new MailAddress("cptjtkirk9000@gmail.com");
            mail.Subject = "New Organization Invite Request";

            //join org link
            string Body = "Click here to accept <a href=\"http://localhost:59444/Organizations/emailResponse/" + user.userId + ">\"";
            mail.Body = Body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("cptjtkirk9000@gmail.com", "spaceman");  
            smtp.EnableSsl = true;
            smtp.Send(mail);

            return RedirectToAction("Feedback", "Home", new { feedback = "Emails sent!" });
        }

        public ActionResult emailResponse(int id)
        {
            User user = (User)Session["loggedIn"];
            User newUser = db.Users.Find(id);

            if (user != null && user.admin && user.orgId != id)
            {
                if (newUser == null )
                {
                    return RedirectToAction("Feedback", "Home", new { feedback = "User does not exist" });
                } else if ( newUser.orgId == user.orgId)
                {
                    return RedirectToAction("Feedback", "Home", new { feedback = "User already in organization" });
                } else
                {
                    newUser.orgId = user.orgId;
                    db.Entry(newUser).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Feedback", "Home", new { feedback = "User added" });
                }

            } else
            {
                Session.Abandon();
                return RedirectToAction("Login","Users");
            }

        }



    }
}