using Glosy_TestCase.Models.Classes;
using System.Linq;
using System.Web.Mvc;

namespace Glosy_TestCase.Controllers
{
    public class NewsController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            ViewBag.Users = c.Users.ToList();
            ViewBag.Categories = c.Categories.ToList();
            var values = c.News.ToList();
            return View(values);
        }

        public ActionResult Detail(int id)
        {
            ViewBag.Users = c.Users.ToList();
            var i = c.News.Find(id);
            return View("Detail", i);
        }

        public ActionResult Categorize(int CategoryID)
        {
            var List = c.News.Where(n => n.CategoryID == CategoryID).ToList();
            return View(List);
        }
    }
}