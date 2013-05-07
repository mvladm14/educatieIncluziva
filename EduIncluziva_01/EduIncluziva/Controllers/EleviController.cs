using EduIncluziva.Metrics;
using System.IO;
using System.Web.Mvc;

namespace EduIncluziva.Controllers
{
    public class EleviController : Controller
    {
        //
        // GET: /Elevi/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PaginaElevului(string mail)
        {
            var rr = new ResourcesRepository();
            var user = rr.GetUserByMail(mail);
            var highschoolId = user.ScoalaDeProvenientaId;
            var highschool = rr.GetHighSchoolById(highschoolId);
            return View(highschool);
        }
    }
}
