using Xamarin.Forms;

namespace CreditCard
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            DependencyService.Get<IAddCreditCard>().AddCreditCard();
        }
    }
}
