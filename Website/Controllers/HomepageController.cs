using System.Web.Mvc;

using AttributeRouting.Web.Mvc;

namespace Website.Controllers
{
    public class HomepageController : Controller
    {
        [Route("")]
        public ActionResult Homepage(bool isMobile = false)
        {
            if (isMobile)
                return View("MobileHomepage");

            return View("Homepage");
        }
    }
}
