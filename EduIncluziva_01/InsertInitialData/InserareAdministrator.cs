using EduIncluziva.Metrics;
using EduIncluziva.Models;

namespace InsertInitialData
{
    class InserareAdministrator
    {
        private const string SchoolName = "Centrul Scolar pentru Educatie Incluziva";
        private const string Nume = "Admin";
        private const string Prenume = "Admin";
        private const string Parola = "@dministrat0r";
        private const string Mail = "admin@adm1n.c0m";

        public void InsertAdministrator()
        {
             using (var context = new EducatieIncluzivaDBContext())
             {
                 var resourcesRepository = new ResourcesRepository();
                 var highSchool = resourcesRepository.GetHighSchoolByName(SchoolName);
                 var administrator = 
                     new Administrator(Parola,Nume,Prenume,Mail,highSchool);
                 context.Administrators.Add(administrator);
                 context.SaveChanges();
             }
        }
    }
}
