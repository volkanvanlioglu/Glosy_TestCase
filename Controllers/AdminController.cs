using Glosy_TestCase.Models.Classes;
using System.Linq;
using System.Web.Mvc;

namespace Glosy_TestCase.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        Context c = new Context();

        //Authorize kullanılarak Admin sayfasından yönetilebilir durumda olması gereken CRUD metodlarına erişim engellemektedir. Ayrıca admin panelinde de kullanıcı rolüne bağlı olarak belirli sayfa ve işlemlere erişim engellenmektedir.

        //İptal: CRUD işlemlerinden sonra javascript alert ile ekranda yazı gösterilmesi veri tipinin int olarak depolanmasından dolayı iptal edildi.

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewsList()
        {
            ViewBag.Users = c.Users.ToList();
            ViewBag.Categories = c.Categories.ToList();

            var values = c.News.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddNewNews()
        {
            var User = c.Users.ToList().Find(u => u.Username == Session["Username"].ToString());
            var RoleID = User.RoleID;

            if (RoleID == 1)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Unauthorized");
            }
        }

        [HttpPost]
        public ActionResult AddNewNews(News I)
        {
            var User = c.Users.ToList().Find(u => u.Username == Session["Username"].ToString());
            var RoleID = User.RoleID;

            if (RoleID == 1)
            {
                c.News.Add(I);
                c.SaveChanges();
                return RedirectToAction("NewsList");
            }
            else
            {
                return RedirectToAction("Unauthorized");
            }            
        }

        public ActionResult GetNews(int id)
        {
            var User = c.Users.ToList().Find(u => u.Username == Session["Username"].ToString());
            var RoleID = User.RoleID;

            if (RoleID == 1)
            {
                var i = c.News.Find(id);
                return View("GetNews", i);
            }
            else
            {
                return RedirectToAction("Unauthorized");
            }
        }

        public ActionResult UpdateNews(News I)
        {
            var User = c.Users.ToList().Find(u => u.Username == Session["Username"].ToString());
            var RoleID = User.RoleID;

            if (RoleID == 1)
            {
                var i = c.News.Find(I.ID);
                i.UserID = I.UserID;
                i.CategoryID = I.CategoryID;
                i.Title = I.Title;
                i.Description = I.Description;
                i.Detail = I.Detail;
                i.Link = I.Link;
                i.Image = I.Image;
                i.Date = I.Date;

                c.SaveChanges();
                return RedirectToAction("NewsList");
            }
            else
            {
                return RedirectToAction("Unauthorized");
            }
        }

        public ActionResult DeleteNews(int id)
        {
            var User = c.Users.ToList().Find(u => u.Username == Session["Username"].ToString());
            var RoleID = User.RoleID;

            if (RoleID == 1)
            {
                var delete = c.News.Find(id);
                c.News.Remove(delete);
                c.SaveChanges();

                return RedirectToAction("NewsList");
            }
            else
            {
                return RedirectToAction("Unauthorized");
            }
        }

        public ActionResult CategoryList()
        {
            var values = c.Categories.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddNewCategory()
        {
            var User = c.Users.ToList().Find(u => u.Username == Session["Username"].ToString());
            var RoleID = User.RoleID;

            if (RoleID == 1)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Unauthorized");
            }
        }

        [HttpPost]
        public ActionResult AddNewCategory(Categories I)
        {
            var User = c.Users.ToList().Find(u => u.Username == Session["Username"].ToString());
            var RoleID = User.RoleID;

            if (RoleID == 1)
            {
                c.Categories.Add(I);
                c.SaveChanges();
                return RedirectToAction("CategoryList");
            }
            else
            {
                return RedirectToAction("Unauthorized");
            }
        }

        public ActionResult GetCategory(int id)
        {
            var User = c.Users.ToList().Find(u => u.Username == Session["Username"].ToString());
            var RoleID = User.RoleID;

            if (RoleID == 1)
            {
                var i = c.Categories.Find(id);
                return View("GetCategory", i);
            }
            else
            {
                return RedirectToAction("Unauthorized");
            }
        }

        public ActionResult UpdateCategory(Categories I)
        {
            var User = c.Users.ToList().Find(u => u.Username == Session["Username"].ToString());
            var RoleID = User.RoleID;

            if (RoleID == 1)
            {
                var i = c.Categories.Find(I.ID);
                i.Name = I.Name;
                c.SaveChanges();
                return RedirectToAction("CategoryList");
            }
            else
            {
                return RedirectToAction("Unauthorized");
            }
        }

        public ActionResult DeleteCategory(int id)
        {
            var User = c.Users.ToList().Find(u => u.Username == Session["Username"].ToString());
            var RoleID = User.RoleID;

            if (RoleID == 1)
            {
                var delete = c.Categories.Find(id);
                c.Categories.Remove(delete);
                c.SaveChanges();

                return RedirectToAction("CategoryList");
            }
            else
            {
                return RedirectToAction("Unauthorized");
            }
        }

        public ActionResult UserList()
        {
            var User = c.Users.ToList().Find(u => u.Username == Session["Username"].ToString());
            var RoleID = User.RoleID;

            if (RoleID == 1)
            {
                ViewBag.Roles = c.Roles.ToList();
                var values = c.Users.ToList();
                return View(values);
            }
            else
            {
                return RedirectToAction("Unauthorized");
            }
        }

        [HttpPost]
        public ActionResult AddNewUser(Users I)
        {
            c.Users.Add(I);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetUser(int id)
        {
            var User = c.Users.ToList().Find(u => u.Username == Session["Username"].ToString());
            var RoleID = User.RoleID;

            if (RoleID == 1)
            {
                var i = c.Users.Find(id);
                return View("GetUser", i);
            }
            else
            {
                return RedirectToAction("Unauthorized");
            }
        }

        public ActionResult UpdateUser(Users I)
        {
            var User = c.Users.ToList().Find(u => u.Username == Session["Username"].ToString());
            var RoleID = User.RoleID;

            if (RoleID == 1)
            {

                var i = c.Users.Find(I.ID);
                i.RoleID = I.RoleID;
                i.Username = I.Username;
                i.Password = I.Password;

                c.SaveChanges();
                return RedirectToAction("UserList");
            }
            else
            {
                return RedirectToAction("Unauthorized");
            }
        }

        public ActionResult DeleteUser(int id)
        {
            var User = c.Users.ToList().Find(u => u.Username == Session["Username"].ToString());
            var RoleID = User.RoleID;

            if (RoleID == 1)
            {
                var delete = c.Users.Find(id);

                if (delete.RoleID != 1)
                {
                    c.Users.Remove(delete);
                    c.SaveChanges();
                }

                return RedirectToAction("UserList");
            }
            else
            {
                return RedirectToAction("Unauthorized");
            }
        }

        public ActionResult RoleList()
        {
            var User = c.Users.ToList().Find(u => u.Username == Session["Username"].ToString());
            var RoleID = User.RoleID;

            if (RoleID == 1)
            {
                var values = c.Roles.ToList();
                return View(values);
            }
            else
            {
                return RedirectToAction("Unauthorized");
            }
        }

        [HttpGet]
        public ActionResult AddNewRole()
        {
            var User = c.Users.ToList().Find(u => u.Username == Session["Username"].ToString());
            var RoleID = User.RoleID;

            if (RoleID == 1)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Unauthorized");
            }
        }

        [HttpPost]
        public ActionResult AddNewRole(Models.Classes.Roles I)
        {
            var User = c.Users.ToList().Find(u => u.Username == Session["Username"].ToString());
            var RoleID = User.RoleID;

            if (RoleID == 1)
            {
                c.Roles.Add(I);
                c.SaveChanges();
                return RedirectToAction("RoleList");
            }
            else
            {
                return RedirectToAction("Unauthorized");
            }
        }

        public ActionResult GetRole(int id)
        {
            var User = c.Users.ToList().Find(u => u.Username == Session["Username"].ToString());
            var RoleID = User.RoleID;

            if (RoleID == 1)
            {
                var i = c.Roles.Find(id);
                return View("GetRole", i);
            }
            else
            {
                return RedirectToAction("Unauthorized");
            }
        }

        public ActionResult UpdateRole(Models.Classes.Roles I)
        {
            var User = c.Users.ToList().Find(u => u.Username == Session["Username"].ToString());
            var RoleID = User.RoleID;

            if (RoleID == 1)
            {
                var i = c.Roles.Find(I.ID);
                i.Name = I.Name;

                c.SaveChanges();
                return RedirectToAction("RoleList");
            }
            else
            {
                return RedirectToAction("Unauthorized");
            }
        }

        public ActionResult DeleteRole(int id)
        {
            var delete = c.Roles.Find(id);

            var User = c.Users.ToList().Find(u => u.Username == Session["Username"].ToString());
            var RoleID = User.RoleID;

            if (RoleID == 1)
            {
                if (delete.ID != 1)
                {
                    c.Roles.Remove(delete);
                    c.SaveChanges();
                }

                return RedirectToAction("RoleList");
            }
            else
            {
                return RedirectToAction("Unauthorized");
            }
        }

        public ActionResult Unauthorized()
        {
            return View();
        }
    }
}