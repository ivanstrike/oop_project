using System.Collections.Generic;
using System.Windows.Documents;

namespace oop_project
{
    public class RestMenu
    {
        public List<MenuItem> Items { get; set; }
        public RestMenu() 
        { 
            Items = new List<MenuItem>();
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