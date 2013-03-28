using System;
using EduIncluziva.Metrics;
using EduIncluziva.Models;

namespace InsertInitialData
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Console.WriteLine("Populating with highschools");

            var inserareLicee = new InserareLicee();
            inserareLicee.InsertInitialHighSchools();

            Console.WriteLine("Finished with high schools");
            

            Console.WriteLine("Adaugam elevi");
            var inserareElevi = new InserareElevi();
            inserareElevi.InseramElevi();
            Console.Write("Am terminat de adaugat elevi");
             

            var inserareAdministrator = new InserareAdministrator();
            inserareAdministrator.InsertAdministrator();
            */
            /*
            var inserareProfesori = new InserareProfesori();
            inserareProfesori.InseramProfesori();
            Console.Write("Am terminat de adaugat profesori");
            */
            var rr = new ResourcesRepository();
            var h = rr.GetHighSchoolById(new Guid("80bc4591-cc75-4b1a-8162-1808ad8ff8f7"));
            
            Console.ReadLine();
            //rr.
        }
    }
}
