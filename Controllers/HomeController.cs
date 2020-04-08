using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace DocuViewareCoreDemo
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Locale = Globals.GetDocuViewareLocale(HttpContext.Request);
            ViewBag.SessionID = Globals.BuildDocuViewareControlSessionID(HttpContext, "DocuVieware1");
            return View();
        }      
    }
}