using System.Web.Mvc;

using AttributeRouting.Web.Mvc;

namespace Website.Controllers
{
    public class HomepageController : Controller
    {
        [Route("")]
        public ActionResult Homepage(string option = null)
        {
            if (option == "mobile")
                return View("MobileHomepage");

            return View("Homepage");
        }
    }
}
