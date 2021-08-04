using NewProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewProject.Controllers
{
    //public class SearchController : Controller
    //{
    //    // GET: Search
    //    Model1 db = new Model1();
    //    public ActionResult Search(string key)
    //    {
    //        //string textSearch = "top";
    //        key = "top";
    //        //var newsSearch = from e in db.News where e.title == textSearch  select e;
    //        //return View(newsSearch.ToList());

    //        var links = from l in db.News // lấy toàn bộ liên kết
    //                    select l;

    //        if (!String.IsNullOrEmpty(key)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
    //        {
    //            links = links.Where(s => s.title.Contains(key)); //lọc theo chuỗi tìm kiếm
    //        }

    //        return View(links); //trả về kết quả
    //    }

    //    public List <News> SearchByTilte(string key)
    //    {
    //        return db.News.SqlQuery("select * from News where title like '%" + key+"%'").ToList();
    //    }
    //}
}