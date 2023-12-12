namespace oop_project
{
    public class CreditCard
    {
        public string CardNumber { get; set; }
        public string ExpiryDate { get; set; }
        public string CVV { get; set; }
        public CreditCard(string cardNumber, string expiryDate, string cVV)
        {
            CardNumber = cardNumber;
            ExpiryDate = expiryDate;
            CVV = cVV;
        }
    }
}