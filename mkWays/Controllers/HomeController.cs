using System.Threading;
using System.Web.Mvc;
using mkWays;
using mkWays.Models;

namespace MkWays.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Ajax()
        {
            this.ViewBag.Name = "Ajax";
            return this.View();
        }

        public ActionResult Documentation()
        {
            this.ViewBag.Name = "Documentation";
            return this.View();
        }

        public ActionResult Changelog()
        {
            this.ViewBag.Name = "Changelog";
            return this.View();
        }

        public ActionResult Download()
        {
            this.ViewBag.Name = "Download";
            return this.View();
        }

        public ActionResult About()
        {
            return this.View();
        }

        public ActionResult Contact()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Contact(MailModel e)
        {
            if (this.ModelState.IsValid)
            {
                (new Thread(() => Mail.SendEmail(e)) {IsBackground = true}).Start();
            }
            return this.View();
        }
    }
}