using System;
using EduIncluziva.Models;

namespace InsertInitialData
{
    class InserareLicee
    {
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

        public void InsertInitialHighSchools()
        {
            using (var context = new EducatieIncluzivaDBContext())
            {
                foreach (var numeLiceu in _numeLicee)
                {
                    var highSchool = new HighSchool();
                    highSchool.Nume = numeLiceu;
                    highSchool.HighSchoolId = Guid.NewGuid();
                    context.HighSchools.Add(highSchool);
                }
                context.SaveChanges();
            }
        }
    }
}
