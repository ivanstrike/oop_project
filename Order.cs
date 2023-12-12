using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        public bool IsPaid {  get; set; }
        public string Status { get; set; }
        public Order(List<CartItem> items)
        {
            Id = idcounter++;
            Items = items;
            OrderDate = DateTime.Now;
            TotalAmount = Items.Sum(item => item.Item.Price * item.Quantity);
            IsPaid = false;
            Status = "Oжидание платежа";
        }
        public void AddItem(CartItem item)
        {
            Items.Add(item);
            TotalAmount += item.Item.Price;
        }
        public void RemoveItem(CartItem item)
        {
            Items.Remove(item);
            TotalAmount -= item.Item.Price; 
        }

        public void PaymentProcess(CreditCard card)
        {
            PaymentService paymentService = new PaymentService();
            bool paymentSuccess = false;

            if (paymentService.Payment(card.CardNumber, card.ExpiryDate, card.CVV, TotalAmount))
            {
                paymentSuccess = true;
            }
            
            if (paymentSuccess)
            {
                IsPaid = true;
                Status = "Оплачен. Происходит доставка";
            }
            else
            {
                IsPaid = false;
                Status = "Что-то пошло не так, ждем опалату";
            }

        }
        public void Delivery(User user)
        {
            Delivery delivery = new Delivery(user.Adress);
            Status = "Ожидает доставки";
            Thread.Sleep(10000);
            delivery.ProcessDelivery();
            Status = "Доставлен";
        }


    }
}
