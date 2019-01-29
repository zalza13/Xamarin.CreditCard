using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Com.Cooltechworks.Creditcarddesign;
using System;

namespace CreditCard.Droid
{
    [Activity(Label = "AddCreditCardActivity", MainLauncher = false)]
    public class AddCreditCardActivity : Activity
    {
        private readonly int CREATE_NEW_CARD = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Intent intent = new Intent(this, typeof(CardEditActivity));
            StartActivityForResult(intent, CREATE_NEW_CARD);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (resultCode == Result.Ok)
            {
                string name = data.GetStringExtra(CreditCardUtils.ExtraCardHolderName);
                string cardNumber = data.GetStringExtra(CreditCardUtils.ExtraCardNumber);
                string expiry = data.GetStringExtra(CreditCardUtils.ExtraCardExpiry);
                string cvv = data.GetStringExtra(CreditCardUtils.ExtraCardCvv);
            }

            Finish();
        }
    }
}