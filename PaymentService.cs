using System.Windows;

namespace oop_project
{
    public class PaymentService
    {
        public bool Payment(string cardNumber, string expiryDate, string cvv, double amount)
        {
            if (!IsDigit(cardNumber) || cardNumber.Length != 16 || !IsDigit(cvv) || cvv.Length != 3 )
            {
                return false;
            }
            return true;
        }

        private bool IsDigit(string cardNumber)
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