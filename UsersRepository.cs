using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_project
{
    public class UsersRepository
    {
        private List<User> users = new List<User>();
        public bool SignUp(string name, string surname, string email, string password, string address)
        {
            if (UserExists(email))
            {
                return false; 
            }
            User newUser = new User(name, surname, email, password, address);
            users.Add(newUser);
            return true;
        }

        private bool UserExists(string email)
        {
            foreach (User user1 in users)
            {
                if (user1.Email == email) { return true; }
            }
            return false;
        }
        public bool LogIn(string email, string password)
        {
            if (UserExists(email))
            {
                return true;
            }
            return false;
        }
    }
}
