using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace oop_project
{
    public class UsersRepository
    {
        private List<User> users = new List<User>();
        private string usersFilePath = "users.txt";
        

        public bool SignUp(string name, string surname, string email, string password, string address)
        {
            if (CheckUserExists(email))
            {
                return false; 
            }
            User newUser = new User(name, surname, email, password, address);
            users.Add(newUser);
            string userData = $"{name},{surname},{email},{password},{address}";
            try
            {
                if (!File.Exists(usersFilePath))
                {
                    using (StreamWriter writer = File.CreateText(usersFilePath)) ;
                    
                }
                using (StreamWriter sw = File.AppendText(usersFilePath))
                {
                    sw.WriteLine(userData);
                    sw.Close();
                }
                return true;
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            
        }

        private bool CheckUserExists(string email)
        {
            try
            {
                string usersFilePath = "users.txt";
                string[] allLines = File.ReadAllLines(usersFilePath);

                foreach (string line in allLines)
                {
                    string[] userData = line.Split(',');

                    if (userData.Length >= 3 && userData[2] == email) 
                    {
                        return true; 
                    }
                }
                return false; 
            }
            catch (IOException ex)
            {
                MessageBox.Show("Ошибка при чтении файла: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return true; 
            }
        }

        public bool CheckUserExistence(string email, string password)
        {
            try
            {
                string[] allLines = File.ReadAllLines(usersFilePath);
                foreach (string line in allLines)
                {
                    string[] userData = line.Split(',');
                    if (userData.Length >= 4 && userData[2] == email && userData[3] == password)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        
        public bool LogIn(string email, string password)
        {
            if (CheckUserExistence(email,password))
            {
                return true;
            }
            return false;
        }
    }
}
