using System.Windows.Controls;

namespace oop_project
{
    public class CartItem
    {
        public MenuItem Item { get; set; }
        public int Quantity { get; set; }
        public CartItem (MenuItem item, int quantity)
        {
            Item = item;
            Quantity = quantity;
        }
        
    }
}