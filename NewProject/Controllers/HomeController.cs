using NewProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewProject.Controllers
{
    public class HomeController : Controller
    {
       //public var account = Session["usernamesession"] as NewProject.Models.Account;
        Model1 db = new Model1();
        public ActionResult Index()
        {
            return View();
        }   
        public ActionResult listCategory(string id)
        {
            ViewBag.catee = id; 
            return View();
        }
        public List<News> getNewByCategory(string cate)
        {
            return db.News.SqlQuery("select * from News where category = '"+cate+"'").ToList();
        }
        public int getTotalCmtByNew(int idNews)
        {
             //List<Comment> count = db.Comments.SqlQuery("SELECT * FROM [Comment] WHERE [newID] = "+idNews+";");
            var cmt = from e in db.Comments where e.newID == idNews select e;
          int count=  cmt.ToList().Count();
            return count;
        }
        public List<News> getTop1(int top)
        {
            return db.News.SqlQuery("select top " + top + " * from News").ToList();
        }
        public List<News> getTop5HotNew(int top)
        {
            return db.News.SqlQuery("select top " + top + " * from News").ToList();
        }
        public ActionResult NewLater()
        {
            return View();
        }
        public ActionResult MostView()
        {
            return View();
        }
        public ActionResult CreateNews()
        {
            try
            {
                var news = from e in db.News select e;
                return View(news.ToList());
            }
            catch (Exception)
            {

                throw;
            }

        }

        //public Account getInFoUserSESSTION()
        //{
        //    var s = Session["usernamesession"].ToString();

        //    List<Account> accounts = db.Accounts.SqlQuery("SELECT *  FROM [project_news_PRN292].[dbo].[Account] where username like '" + s + "'").ToList();
        //    Account account = accounts.ElementAt(0);
            
        //    return account;
        //}

        [HttpPost]
        public ActionResult CreateNews(string title, string categolySelect, string image, string description)
        {
            News newInfo = new News();
            try
            {
                newInfo.title = title;
                newInfo.category = categolySelect;
                newInfo.description = description;
                newInfo.imageNew = image;
                newInfo.userID = 1;
                newInfo.viewCount = 0;
                DateTime dateTime = DateTime.Now;
                newInfo.datePost = dateTime;
                //newInfo.datePost = Convert.ToDateTime("01/01/2021");
                //newInfo.datePost = dateTime);

                // executes the commands to implement the changes to the database

                db.News.Add(newInfo);

                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            newInfo = getNewsMoiNhat();
            return RedirectToAction("NewDetail", "Home", new { id = newInfo.newID });
        }
        public List<Comment> getAllComentByTimeeeee(int id)
        {
            return db.Comments.SqlQuery("SELECT * FROM [project_news_PRN292].[dbo].[Comment] where NewID = " + id + " order by cmtID desc ").ToList();
        }
        public News getNewsMoiNhat()
        {
            List<News> listNews = db.News.SqlQuery("SELECT * FROM [project_news_PRN292].[dbo].[News] ORDER BY  newID desc").ToList();
            return listNews.ElementAt(0);
        }
        public ActionResult DeletetNewLater()
        {
            int idNewLate = Convert.ToInt32(RouteData.Values["id"]);
            NewsLater newlt = db.NewsLaters.Find(idNewLate) ;
            db.NewsLaters.Remove(newlt);
            db.SaveChanges();
            return RedirectToAction("listNewLater", "Home");
        }
        public List<NewsLater> listNewLaterByAcc()
        {
           List<NewsLater> allNews = db.NewsLaters.SqlQuery("SELECT *  FROM NewsLater where userID ="+1).ToList();
            return (allNews);
        }
        public ActionResult deleteComment()
        {
            int idCMt = Convert.ToInt32(RouteData.Values["id"]);
            Comment comment = db.Comments.Find(idCMt);
            int idNews = comment.newID;
            db.Comments.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("NewDetail", "Home", new { id = idNews});
        }
        public ActionResult listNewLater()
        {

            try
            {
                List<NewsLater> allNewByAcc = listNewLaterByAcc();
                int idNew = Convert.ToInt32(RouteData.Values["id"]);
                if (idNew!=0)
                {
                    Boolean check = true;
                    foreach (var item in allNewByAcc)
                    {
                        if (item.newID == idNew)
                        {
                            check = false;
                        }
                    }
                    if (check == true)
                    {
                        NewsLater newsLater = new NewsLater();
                        newsLater.newID = idNew;
                        newsLater.userID = 1;
                        db.NewsLaters.Add(newsLater);
                        db.SaveChanges();
                    }
                }
               
                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<NewsLater> getAllNewLaterByAcc()
        {
            return  db.NewsLaters.SqlQuery("select * from NewsLater where [userID] = " + 1).ToList();

        }
        public News getNewReturnByNews(int id)
        {
                List<News> newTop1 = getNewByID(1, id);
                return newTop1.ElementAt(0);
        }
        //public Account getAcountReturnOJ(int id)
        //{
        //    List<News> newTop1 = getNewByID(1, id);
        //    return newTop1.ElementAt(0);
        //}
        public ActionResult Edit()
        {
            int idNew = Convert.ToInt32(RouteData.Values["id"]);
             ViewBag.NewsInfoID = idNew;
            return View();
        }
        public ActionResult likeComment()
        {
            int idCMt = Convert.ToInt32(RouteData.Values["id"]);
            Comment comment = db.Comments.Find(idCMt);
            try
            {
              
                var updateCmt = db.Comments.First(g => g.cmtID == idCMt);
                updateCmt.likecmttttt = updateCmt.likecmttttt + 1;
                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("NewDetail", "Home", new { id = comment.newID });
        }
        public ActionResult ListYourNews()
        {
            int idNew = Convert.ToInt32(RouteData.Values["id"]);
            ViewBag.NewsInfoID = idNew;
            return View();
        }
        public ActionResult EditInput(int idNews,string title, string categolySelect, string image, string description)
        {
           try
            {
                var update = db.News.First(g => g.newID == idNews);
                update.title = title.Trim();
                update.category = categolySelect;
                update.description = description.Trim();
                update.imageNew = image.Trim();
                update.userID = 2;
                update.viewCount = 0;
                DateTime dateTime = DateTime.Now;
              
                update.datePost = Convert.ToDateTime(dateTime);

                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
          return  RedirectToAction("ListYourNews", "Home");
        }
       
        public ActionResult DeteleNews()
        {
            int idNew = Convert.ToInt32(RouteData.Values["id"]);
            News newsDte = db.News.Find(idNew);
            db.News.Remove(newsDte);
            db.SaveChanges();
            return RedirectToAction("ListYourNews", "Home");
        }
        public ActionResult NewDetail()
        {

            var x = Convert.ToInt32( RouteData.Values["id"]);
            var cmt = from e in db.Comments where e.newID == x select e;
            var update = db.News.First(g => g.newID == x);
            update.viewCount = update.viewCount + 1 ;
            db.SaveChanges();
            ViewBag.idNew = x;
            return View(cmt.ToList());
        }
        
        public List<News> getNewByID(int top, int id)
        {
            return db.News.SqlQuery("select top " + top + " * from News where newID = "+id).ToList();
        }
        public List<Account> getAccountByID(int top, int id)
        {
            return db.Accounts.SqlQuery("select top " + top + " * from Account where userID = " + 1).ToList();
        }
        public List<News> getNewByAuthor(int id)
        {
            return db.News.SqlQuery("select * from News where UserID = " + 1).ToList();
        }
        public Boolean checkSearch(string txtSearch)
        {
            if (txtSearch.Contains("<") || txtSearch.Contains(">")) ;
            {
                return false;
            }
            return true;
        }
        
        [HttpPost]
        public ActionResult NewDetail(int idUser, int idNews, string contentCmt, string Avt, string userName)
        {
            try
            {
                Comment comment = new Comment();
                comment.userID = 1;
                comment.newID = idNews;
                comment.Avt = Avt.Trim();
                comment.userName = userName.Trim();
                comment.contentComment = contentCmt.Trim();
                //DateTime dateTime = 
                comment.dateComment = DateTime.Now; 
                db.Comments.Add(comment);
                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("NewDetail", "Home");
        }

        // GET: Search
        [ValidateInput(enableValidation:false)]
        public ActionResult Search(string key)
        {

            //ValidateInput(enableValidation: false);
            ViewBag.txtSearch = key;

            return View(); //trả về kết quả
        }

        public List<News> SearchByTilte(string key)
        {
            return db.News.SqlQuery("select * from News where title like '%" + key + "%'").ToList();
        }

    }
}