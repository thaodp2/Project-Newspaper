using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewProject.Models;
namespace NewProject.Controllers
{
    public class EditAccController : Controller
    {
        string connectiontString = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=project_news_PRN292;Integrated Security=True";
        // GET: EditAcc
        public ActionResult EditAcc(int? id)
        {
            return View(id);
        }

        [HttpPost]
        public ActionResult EditAccount(Account acc, int? id)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectiontString))
            {
                sqlCon.Open();
                string query = "update Account set name = @name, avatar = @avatar,gmail = @gmail,DOB=@DOB where userID = '"+id+"' ";
                SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
                sqlcmd.Parameters.AddWithValue("@name", acc.name);
                sqlcmd.Parameters.AddWithValue("@avatar", acc.avatar);
                sqlcmd.Parameters.AddWithValue("@gmail", acc.gmail);
                sqlcmd.Parameters.AddWithValue("@DOB", acc.DOB);
                sqlcmd.ExecuteNonQuery();
            }
            return View("Index", "Home");
        }
    }
}