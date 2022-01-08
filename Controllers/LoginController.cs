using Glosy_TestCase.Models.Classes;
using System.Linq;
using System.Web.Security;
using System.Web.Mvc;

namespace Glosy_TestCase.Controllers
{
    public class LoginController : Controller
    {
        Context c = new Context();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Index(Users a)
        {
            var informations = c.Users.FirstOrDefault(x => x.Username == a.Username && x.Password == a.Password);
            bool result = false;

            if (informations != null)
            {
                FormsAuthentication.SetAuthCookie(informations.Username, false);
                Session["Username"] = informations.Username.ToString();
                result = true;
            }
            else
            {
                result = false;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.RemoveAll();
            return RedirectToAction("Index", "Login");
        }
    }
}