using System.Windows.Controls;

namespace oop_project
{
    public class CartItem : MenuItem
    {
        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (quantity != value)
                {
                    quantity = value;
                    OnPropertyChanged(nameof(Quantity));
                }
            }
        }
        public CartItem (string name, string description, double price, int quantity) :base(name, description, price)
        {
            Quantity = quantity;
        }
        
    }
}