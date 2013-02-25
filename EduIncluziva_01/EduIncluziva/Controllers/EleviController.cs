using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EduIncluziva.Models;
using EduIncluziva.Metrics;

namespace EduIncluziva.Controllers
{
    public class EleviController : Controller
    {
        //
        // GET: /Elevi/

        EducatieIncluzivaDBContext3 _educatieIncluzivaDB = new EducatieIncluzivaDBContext3();

        public ActionResult Index()
        {
            /*
            var elev = new Elevi()
            {
                Nume = "mirel2",
                Prenume = "Vlad",
                Mail = "mvladm2@yahoo.com",
                Parola = "vlad",
                Elev_ID = Guid.NewGuid()
            };
            */
            

            /*
            _educatieIncluzivaDB.Elevis.Add(elev);
            _educatieIncluzivaDB.SaveChanges();
             *
            var model = _educatieIncluzivaDB.Elevis;*/

            /*
            var model = from b in _educatieIncluzivaDB.Elevis
                        where b.Mail.Equals("mvladm2@yahoo.com")
                        select b;
             * */
            /*
            List<Elevi> le = new List<Elevi>();
            le.Add(new ResourcesRepository().GetEleviByMail("mvladm@yahoo.com"));
            var model = le;
            */
            
            
            return View();
        }
    }
}
