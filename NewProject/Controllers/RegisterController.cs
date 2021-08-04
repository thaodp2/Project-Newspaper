using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewProject.Models;
namespace NewProject.Controllers
{
    public class RegisterController : Controller
    {
        Model1 db = new Model1();
        // GET: Register
        [HttpGet]
        public ActionResult Register()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Register([Bind(Include = "userID,username,password,name,avatar,gmail,DOB,securityAnswer,isAdmin")] Account account)
        {
            if (ModelState.IsValid)
            {
                if (db.Accounts.Any(x => x.username.Equals(account.username)))
                {
                    ViewBag.DuplicateMessage = "Username already exist";
                    return View();
                }
                else
                {
                    db.Accounts.Add(account);
                    db.SaveChanges();
                    ViewBag.SuccessMessage = "Register successful";
                    //return RedirectToAction("Index", "Home");
                }

            }

            return View(account);

        }
    }
}