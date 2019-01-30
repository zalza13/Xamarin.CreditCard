using System;
using Xamarin.Forms;

namespace CreditCard
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            void handlerCCDAdded(object sender, EventArgs args)
            {
                CreditCardData ccd =  DependencyService.Get<IAddCreditCard>().CaptureCreditCardData;
                CCName.Text = "Name: " + ccd.Name;
                CCNumber.Text = "Number: " + ccd.Number;
                CCExpiry.Text = "Expiry: " + ccd.Expiry;
                CCCVV.Text = "CVV: " + ccd.CVV;

            }
            DependencyService.Get<IAddCreditCard>().CreditCardAddedHandler += handlerCCDAdded;
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            DependencyService.Get<IAddCreditCard>().AddCreditCard();
        }
    }
}