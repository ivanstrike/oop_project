using System.Collections.Generic;

namespace oop_project
{
    public class Restaurant
    {
        private static int idcounter = 0;
        public int Id { private get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Description { get; set; }
        public RestMenu Menu { get; set; }
        public Restaurant(string name, string adress, string description)
        {
            Id = idcounter++;
            Name = name;
            Adress = adress;
            Description = description;
        }
        public RestMenu GetMenu()
        {
            return Menu;
        }

    }
}