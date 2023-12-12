namespace oop_project
{
    public class Delivery
    {
        public string DeliveryAddress { get; set; }
        public bool IsDelivered { get; set; }
        public string DeliveryStatus { get; set; }

        public Delivery(string adress) 
        {
            DeliveryAddress = adress;
            IsDelivered = false;
            DeliveryStatus = "Ожидает доставки";
        }
        public void ProcessDelivery()
        {
            IsDelivered = true;
            DeliveryStatus = "Доставлен";

        }
    }
}