using System.Collections.Generic;

namespace oop_project
{
    public class Restaurant
    {
        private static int idcounter = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Description { get; set; }
        //public Menu menu;
        public Restaurant(string name, string adress, string description)
        {
            Id = idcounter++;
            Name = name;
            Adress = adress;
            Description = description;
        }
        /*public List<MenuItem> GetMenu()
        {
            return menu;
        }*/

    }
}