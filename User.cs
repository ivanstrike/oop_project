using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_project
{
    public class User
    {
        private static int idcouner = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Adress { get; set; }
        public User(string name, string surname, string email, string password, string adress ) 
        { 
            Id = idcouner++;
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
            Adress = adress;
        }

    }
}
