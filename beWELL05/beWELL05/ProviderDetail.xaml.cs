using beWELL05.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace beWELL05
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProviderDetail : ContentPage
	{
		public ProviderDetail ()
		{
			InitializeComponent ();
		}
        public ProviderDetail(HealthProvider provider)
        {
            InitializeComponent();
            BindingContext = provider;
            this.Title = provider.Name ;
           
        }
        private void OnWebSiteClicked(object sender, TappedEventArgs e)
        {
            Device.OpenUri(new Uri(((Label)sender).Text));
        }
       

    }
}