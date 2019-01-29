using Android.Content;
using CreditCard.Controls;
using CreditCard.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CreditCardControl), typeof(CreditCardControlAndroid))]
namespace CreditCard.Droid
{
    public class CreditCardControlAndroid : ViewRenderer<CreditCardControl, Android.Views.View>
    {
        private readonly Context _context;
        public CreditCardControlAndroid(Context context) : base(context)
        {
            _context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<CreditCardControl> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                _context.StartActivity(typeof(CreditCardActivity));
            }
        }
    }
}