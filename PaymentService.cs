using System.Windows;

namespace oop_project
{
    public  class PaymentService
    {
        
        public  bool IsPayment(CreditCard card)
        {
            if (!IsDigit(card.CardNumber) || card.CardNumber.Length != 16 || !IsDigit(card.CVV) || card.CVV.Length != 3 || card.ExpiryDate.Length!=5)
            {
                return false;
            }
            return true;
        }

        private  bool IsDigit(string cardNumber)
        {
            foreach (char c in cardNumber)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}