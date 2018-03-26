using beWELL05.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace beWELL05
{
	public partial class MainPage : ContentPage
	{
        IEnumerable<HealthProvider> providers = new ObservableCollection<HealthProvider>();

        public MainPage()
        {
            Task.Run(async () =>
            {
                providers = await HealthProviderManager.GetHealthProvidersAsync();
            });


            InitializeComponent();
            lblTitle.Text = "Time is:" + DateTime.Now.ToShortTimeString();
            lstProviders.BeginRefresh();
            lstProviders.BindingContext = providers;
            lstProviders.EndRefresh();
        }
        private void OnSearchChanged(object sender, TextChangedEventArgs e)
        {
            var filteredProviders = providers;
            lstProviders.BeginRefresh();
            if (string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                filteredProviders = CountryPicker.SelectedIndex == -1 ? providers : providers.Where(i => i.Country.ToLower() == CountryPicker.SelectedItem.ToString().ToLower());
                filteredProviders = CityPicker.SelectedIndex == -1 ? filteredProviders : filteredProviders.Where(i => i.City.ToLower() == CityPicker.SelectedItem.ToString().ToLower());
                lstProviders.ItemsSource = filteredProviders;
            }
            else
            {

                filteredProviders = CountryPicker.SelectedIndex == -1 ? providers : providers.Where(i => i.Country.ToLower() == CountryPicker.SelectedItem.ToString().ToLower());
                filteredProviders = CityPicker.SelectedIndex == -1 ? filteredProviders : filteredProviders.Where(i => i.City.ToLower() == CityPicker.SelectedItem.ToString().ToLower());
                lstProviders.ItemsSource = filteredProviders.Where(i => i.Name.ToLower().Contains(e.NewTextValue.ToLower()));
            }

            lstProviders.EndRefresh();
        }
        private void OnCountryPickerChanged(object sender, EventArgs e)
        {
            var filteredProviders = lstProviders.ItemsSource as IEnumerable<HealthProvider>;
            CityPicker.SelectedIndex = -1;
            Picker pic = (Picker)sender;

            lstProviders.BeginRefresh();
            if (pic.SelectedIndex == -1)
                lstProviders.ItemsSource = filteredProviders;
            else
            {

                var result = filteredProviders.Where(i => i.Country.ToLower() == pic.SelectedItem.ToString().ToLower());
                lstProviders.ItemsSource = result;
                var cityList = result.Select(r => r.City).Distinct().ToList<string>();
                CityPicker.ItemsSource = cityList;
            }

            lstProviders.EndRefresh();
        }
        private void OnCityPickerChanged(object sender, EventArgs e)
        {
            var filteredProviders = lstProviders.ItemsSource as IEnumerable<HealthProvider>;
            Picker cityPic = (Picker)sender;
            lstProviders.BeginRefresh();
            if (cityPic.SelectedIndex == -1)
                lstProviders.ItemsSource = filteredProviders;
            else
            {

                lstProviders.ItemsSource = filteredProviders.Where(i => i.City.ToLower() == cityPic.SelectedItem.ToString().ToLower());
            }
            lstProviders.EndRefresh();
        }

        private async void OnProvderTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new ProviderDetail((HealthProvider)e.Item));

        }

    }
}
