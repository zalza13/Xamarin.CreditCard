using Android.App;
using Android.Content;
using Android.OS;
using Com.Cooltechworks.Creditcarddesign;
using System;

namespace CreditCard.Droid
{
    [Activity(Label = "AddCreditCardActivity", MainLauncher = false)]
    public class AddCreditCardActivity : Activity
    {
        /// <summary>
        /// Credit Card Data
        /// </summary>
        public class CreditCardData
        {
            public string Name { get; set; }
            public string Number { get; set; }
            public string Expiry { get; set; }
            public string CVV { get; set; }
        }

        private readonly int CREATE_NEW_CARD = 0;
        public static EventHandler AddCreditCardResultHandler;
        public CreditCardData CreditCardRawData { get; set; }

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

                //TODO: Validate data

                CreditCardRawData = new CreditCardData()
                {
                    Name = name,
                    Number = cardNumber,
                    Expiry = expiry,
                    CVV = cvv
                };

                AddCreditCardResultHandler?.Invoke(this, null);
                Finish();
            }
        }
    }
}