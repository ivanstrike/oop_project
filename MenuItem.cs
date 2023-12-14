using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_project
{
    public class MenuItem : INotifyPropertyChanged
    {
        private static int idcounter;
        public int Id { private get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public MenuItem(string name, string description, double price) 
        {
            Id = idcounter++;
            Name = name;
            Description = description;
            Price = price;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
