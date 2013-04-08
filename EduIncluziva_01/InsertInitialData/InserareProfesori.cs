using System;
using EduIncluziva.Metrics;
using EduIncluziva.Models;

namespace InsertInitialData
{
    class InserareProfesori
    {
        private readonly ResourcesRepository _resourcesRepository;
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

        public InserareProfesori()
        {
            _resourcesRepository = new ResourcesRepository();
        }

        public void InseramProfesori()
        {
            using (var context = new EducatieIncluzivaDbContext())
            {
                string parola = "parola";
                string nume = "nume";
                string prenume = "prenume";
                string mail = "prof@yahoo.com";

                for (int i = 0; i < 10; i++)
                {
                    Random random = new Random();

                    int rand = random.Next(0, _numeLicee.Length);
                    string name = _numeLicee[rand];

                    HighSchool highSchool = _resourcesRepository.GetHighSchoolByName(name);

                    var teacher = new Teacher(parola + i.ToString(), nume + i.ToString(),
                        prenume + i.ToString(), mail + i.ToString(), highSchool,"urltest" + i.ToString(),"Bio test in care punem si liceul "+highSchool);

                    context.Teachers.Add(teacher);
                }
                context.SaveChanges();
            }
        }
    }
}
