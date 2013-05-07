using EduIncluziva.Metrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduIncluziva.Controllers
{
    public class MaterieController : Controller
    {

        public ActionResult VizualizareLectiiMaterie(string mail, string numeMaterie)
        {
            var rr = new ResourcesRepository();
            var model = rr.GetAllLessons(mail, numeMaterie);
            return View(model);
        }


        public ActionResult Download(string virtualPath, string fileDownloadName)
        {
            return new DownloadResult { VirtualPath = virtualPath, FileDownloadName = fileDownloadName };
        }

    }
}
