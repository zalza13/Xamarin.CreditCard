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
        void IAddCreditCard.AddCreditCard()
        {
            Intent intent = new Intent(Application.Context, typeof(AddCreditCardActivity));
            Application.Context.StartActivity(intent);

            var tcs = new TaskCompletionSource<string>();

            void handler(object sender, EventArgs args)
            {
                AddCreditCardActivity.AddCreditCardResultHandler -= handler;
                var ccd = ((AddCreditCardActivity)sender).CreditCardRawData;
            }

            AddCreditCardActivity.AddCreditCardResultHandler += handler;
        }
    }
}