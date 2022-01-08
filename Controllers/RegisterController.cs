using Glosy_TestCase.Models.Classes;
using System.Linq;
using System.Web.Mvc;

namespace Glosy_TestCase.Controllers
{
    public class RegisterController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Index(Users a)
        {
            var informations = c.Users.FirstOrDefault(x => x.Username == a.Username);
            bool result = false;

            if (informations != null)
            {
                result = true;
            }
            else
            {
                result = false;
                c.Users.Add(a);
                a.RoleID = 2; //Yeni kaydolan kullanıcılar user rolünde eklenir.
                c.SaveChanges();
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}