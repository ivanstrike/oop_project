using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace oop_project
{
    internal class Order 
    {
        private static int idcounter = 0;
        public int Id { private get; set; }
        public List<CartItem> Items { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalAmount { get; set; }
        public bool IsPaid {  get; set; }
        public string Status { get; set; }
        public Order()
        {
            Id = idcounter++;
            Items = new List<CartItem>();
            OrderDate = DateTime.Now;
            TotalAmount = 0;
            IsPaid = false;
            Status = "Создание";
        }

        public double TotalAmountCount()
        {
            return Items.Sum(item => item.Price* item.Quantity);
        }

        public void AddItem(CartItem item)
        {
            Items.Add(item);
            TotalAmount += item.Price;
        }
        public void RemoveItem(CartItem item)
        {
            Items.Remove(item);
            TotalAmount -= item.Price; 
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

        public event PropertyChangedEventHandler PropertyChanged;
       

    }
}
