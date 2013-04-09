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

        public ActionResult PaginaElevului()
        {
            var path = Server.MapPath("~/Pictures/Profesori/Test");
            Directory.CreateDirectory(path);
            return View();
        }
    }
}
