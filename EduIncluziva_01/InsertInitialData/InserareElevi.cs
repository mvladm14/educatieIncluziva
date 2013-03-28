using System;
using EduIncluziva.Metrics;
using EduIncluziva.Models;

namespace InsertInitialData
{
    class InserareElevi
    {
        private ResourcesRepository _resourcesRepository;
        private readonly string[] _numeLicee =
            {
                "Gradinita Speciala",
                "Centrul Scolar pentru Educatie Incluziva",
                "Scoala Gimnaziala Speciala Centrul de Resurse si Documentare in Educatia Incluziva",
                "Liceul pentru Deficienti de Vedere",
                "Liceul pentru Deficienti de Auz ",
                "Scoala de Arte si Meserii SAMUS",
                "Scoala Gimnaziala Speciala Transilvania Baciu",
                "Scoala Gimnaziala Speciala Dej",
                "Scoala Gimnaziala Speciala Huedin"
            };

        public InserareElevi()
        {
            _resourcesRepository = new ResourcesRepository();
        }

        public void InseramElevi()
        {
            using (var context = new EducatieIncluzivaDbContext())
            {
                string parola = "parola";
                string nume = "nume";
                string prenume = "prenume";
                string mail = "mail@yahoo.com";

                for (int i = 0; i < 10; i++)
                {
                    Random random = new Random();

                    int rand = random.Next(0, _numeLicee.Length);
                    string name = _numeLicee[rand];

                    HighSchool highSchool = _resourcesRepository.GetHighSchoolByName(name);

                    Student student = new Student(parola + i.ToString(), nume + i.ToString(),
                        prenume + i.ToString(), mail + i.ToString(), highSchool);

                    context.Students.Add(student);
                }
                context.SaveChanges();
            }
        }

    }
}
