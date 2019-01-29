using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Com.Cooltechworks.Creditcarddesign;
using System;

namespace CreditCard.Droid
{
    [Activity(Label = "CreditCardActivity", MainLauncher = false)]
    public class CreditCardActivity : Activity
    {
        private int CREATE_NEW_CARD = 0;

        private LinearLayout cardContainer;
        private Button addCardButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CreditCardLayout);

            Init();
            SubscribeUi();
        }

        void Init()
        {
            addCardButton = FindViewById<Button>(Resource.Id.add_card);
            cardContainer = FindViewById<LinearLayout>(Resource.Id.card_container);
            LoadSampleCreditCard();
        }

        private void LoadSampleCreditCard()
        {
            //var sampleCreditCardView = new CreditCardView(this);

            //var name = "Glarence Zhao";
            //var cvv = "420";
            //var expiry = "01/18";
            //var cardNumber = "4242424242424242";

            //sampleCreditCardView.CVV = cvv;
            //sampleCreditCardView.CardHolderName = name;
            //sampleCreditCardView.SetCardExpiry(expiry);
            //sampleCreditCardView.CardNumber = cardNumber;

            //cardContainer.AddView(sampleCreditCardView);
            //int index = cardContainer.ChildCount - 1;
            //addCardListener(index, sampleCreditCardView);
        }

        public class ClickListener : Java.Lang.Object, View.IOnClickListener
        {
            public Action<View> Click { get; set; }
            public void OnClick(View v) => Click?.Invoke(v);
        }

        private void SubscribeUi()
        {
            addCardButton.SetOnClickListener(new ClickListener
            {
                Click = v =>
                {
                    Intent intent = new Intent(this, typeof(CardEditActivity));
                    StartActivityForResult(intent, CREATE_NEW_CARD);

                }
            });
        }

        private void EditCreditCardEvent(int index, CreditCardView creditCardView)
        {
            creditCardView.SetOnClickListener(new ClickListener
            {
                Click = v =>
                {
                    var cv = v as CreditCardView;
                    string cardNumber = cv.CardNumber;
                    string expiry = cv.Expiry;
                    string cardHolderName = cv.CardHolderName;
                    string cvv = cv.CVV;

                    Intent intent = new Intent(Application.Context, typeof(CardEditActivity));
                    intent.PutExtra(CreditCardUtils.ExtraCardHolderName, cardHolderName);
                    intent.PutExtra(CreditCardUtils.ExtraCardNumber, cardNumber);
                    intent.PutExtra(CreditCardUtils.ExtraCardExpiry, expiry);
                    intent.PutExtra(CreditCardUtils.ExtraCardShowCardSide, CreditCardUtils.CardSideBack);
                    intent.PutExtra(CreditCardUtils.ExtraValidateExpiryDate, false);

                    // start at the CVV activity to edit it as it is not being passed
                    intent.PutExtra(CreditCardUtils.ExtraEntryStartPage, CreditCardUtils.CardCvvPage);
                    StartActivityForResult(intent, index);
                }
            });
        }


        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (resultCode == Result.Ok)
            {
                //            Debug.printToast("Result Code is OK", getApplicationContext());

                string name = data.GetStringExtra(CreditCardUtils.ExtraCardHolderName);
                string cardNumber = data.GetStringExtra(CreditCardUtils.ExtraCardNumber);
                string expiry = data.GetStringExtra(CreditCardUtils.ExtraCardExpiry);
                string cvv = data.GetStringExtra(CreditCardUtils.ExtraCardCvv);

                if (requestCode == CREATE_NEW_CARD)
                {
                    CreditCardView creditCardView = new CreditCardView(Application.Context)
                    {
                        CVV = cvv,
                        CardHolderName = name,
                        CardNumber = cardNumber
                    };
                    creditCardView.SetCardExpiry(expiry);


                    cardContainer.AddView(creditCardView);
                    int index = cardContainer.ChildCount - 1;
                    EditCreditCardEvent(index, creditCardView);
                }
                else
                {
                    CreditCardView creditCardView = cardContainer.GetChildAt(requestCode) as CreditCardView;

                    creditCardView.SetCardExpiry(expiry);
                    creditCardView.CardNumber = cardNumber;
                    creditCardView.CardHolderName = name;
                    creditCardView.CVV = cvv;
                }
            }
        }
    }
}