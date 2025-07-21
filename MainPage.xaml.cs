using WX.Services.API;
using WX.Services.Preferences;

namespace WX
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);

            var se = new WeatherAPIService("https://api.open-meteo.com/v1/forecast?", new PreferencesService());
            se.RegisterParameter("latitude", "52.52");
            se.RegisterParameter("longitude", "13.41");
            await se.FetchData();
        }
    }
}
