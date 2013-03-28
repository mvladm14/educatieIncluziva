namespace EduIncluziva.Models
{
    public class Student : User
    {
        private const string ElevRole = "Elev";

        public Student(string parola, string nume, string prenume, string mail, HighSchool scoalaDeProvenienta) :
            base(parola, nume, prenume, mail, scoalaDeProvenienta)
        {
            Role = ElevRole;
        }

        public Student() { }
    }
}