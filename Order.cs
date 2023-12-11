using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_project
{
    internal class Order
    {
        private static int idcounter = 0;
        public int Id { get; set; }
        public List<CartItem> Items { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalAmount { get; set; }
        public List<PaymentMethod> OrderPaymentMethod {  get; set; }
        public Order(List<CartItem> items, List<PaymentMethod> orderPaymentMethod)
        {
            Id = idcounter++;
            Items = items;
            OrderDate = DateTime.Now;
            OrderPaymentMethod = orderPaymentMethod;
            TotalAmount = Items.Sum(item => item.Item.Price * item.Quantity);
        }
    }
}
