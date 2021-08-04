using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewProject.Models;
namespace NewProject.Controllers
{
    public class ForgotPasswordController : Controller
    {

        string connectiontString = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=project_news_PRN292;Integrated Security=True";
        Model1 db = new Model1();
        // GET: Forgot
        public ActionResult Forgot()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Forgot(forgotModel fm)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectiontString))
            {
                try
                {
                    sqlCon.Open();
                    string query = "update Account set password = @password where username = @username and securityAnswer= @securityAnswer";
                    SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
                    sqlcmd.Parameters.AddWithValue("@password", fm.password);
                    sqlcmd.Parameters.AddWithValue("@username", fm.username);
                    sqlcmd.Parameters.AddWithValue("@securityAnswer", fm.securityAnswer);
                    sqlcmd.ExecuteNonQuery();
                    ViewBag.resetSuccess = "Reset password Success";
                }
                catch (Exception)
                {
                    ViewBag.resErro = "Reset password Fail";
                    throw;
                }
               
            }

            return View();
        }
    }
}