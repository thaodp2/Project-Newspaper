using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewProject.Models;
namespace NewProject.Controllers
{
    public class LoginController : Controller
    {
       Model1 db = new Model1();
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

    [HttpPost]
    public ActionResult Login(Account acc)
    {
        var obj = db.Accounts.Where(x => x.username == acc.username && x.password == acc.password).FirstOrDefault();
        if (obj == null)
        {
            ViewBag.messageError = "wrong username or password";
            return View("Login", acc);
        }
        else
        {
            Session["userIDsession"] = acc.userID;
            Session["usernamesession"] = acc.username;
            Session["passwordsession"] = acc.password;
            
            Session["SecirityAnswersession"] = acc.securityAnswer;
                return RedirectToAction("Index", "Home");
        }
    }

}
}