using Android.App;
using Android.Content;
using Com.Cooltechworks.Creditcarddesign;
using CreditCard.Droid;
using System;

[assembly: Xamarin.Forms.Dependency(typeof(AddCreditCard))]
namespace CreditCard.Droid
{
    public class AddCreditCard : IAddCreditCard
    {
        void IAddCreditCard.AddCreditCard()
        {
            Intent intent = new Intent(Application.Context, typeof(AddCreditCardActivity));
            Application.Context.StartActivity(intent);
        }
    }
}