using Android.App;
using Android.Content;
using Android.OS;
using CreditCard.Droid;
using System;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(AddCreditCard))]
namespace CreditCard.Droid
{
    [Activity(Label = "AddCreditCard", MainLauncher = false)]
    public class AddCreditCard : IAddCreditCard
    {
        public CreditCardData CaptureCreditCardData { get; set; }
        public EventHandler CreditCardAddedHandler { get; set; }

        void IAddCreditCard.AddCreditCard()
        {
            Intent intent = new Intent(Application.Context, typeof(AddCreditCardActivity));
            Application.Context.StartActivity(intent);

            void handler(object sender, EventArgs args)
            {
                AddCreditCardActivity.AddCreditCardResultHandler -= handler;
                CaptureCreditCardData = ((AddCreditCardActivity)sender).CreditCardRawData;
                CreditCardAddedHandler?.Invoke(this, null);
            }

            AddCreditCardActivity.AddCreditCardResultHandler += handler;
        }
    }
}