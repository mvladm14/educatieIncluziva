using System;
using System.Collections.Generic;

namespace EduIncluziva.Models
{
    public class User
    {
        public System.Guid User_ID { get; set; }
        public string Role { get; set; }
        public string Mail { get; set; }
        public string Parola { get; set; }
    }
}
