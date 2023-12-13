using System.Windows.Controls;

namespace oop_project
{
    public class CartItem : MenuItem
    {
        public int Quantity { get; set; }
        public CartItem (string name, string description, double price, int quantity) :base(name, description, price)
        {
            Quantity = quantity;
        }
        
    }
}