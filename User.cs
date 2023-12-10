using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_project
{
    internal class User
    {
        private static int idcouner = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age {  get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public User(string name, string surname, int age, string email ) 
        { 
            Id = idcouner++;
            Name = name;
            Surname = surname;
            Age = age;
            Email = email;

        }

    }
}
