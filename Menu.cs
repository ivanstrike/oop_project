using System.Collections.Generic;
using System.Windows.Documents;

namespace oop_project
{
    public class Menu
    {
        public List<MenuItem> Items { get; set; }
        public Menu(List<MenuItem> items) 
        {
            Items = items;
        }
        public void Add(MenuItem item)
        {
            Items.Add(item);
        }
        public void Remove(MenuItem item)
        {
            Items.Remove(item);
        }
    }

}