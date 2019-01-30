using System;

namespace CreditCard
{
    public interface IAddCreditCard 
    {
        EventHandler CreditCardAddedHandler { get; set; }
        CreditCardData CaptureCreditCardData { get; set; }
        void AddCreditCard();
    }
}
