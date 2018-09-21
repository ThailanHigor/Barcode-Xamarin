using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace BarCode
{
    public partial class MainPage : ContentPage
    {

        ZXingScannerPage scanPage;

        public MainPage()
        {
            InitializeComponent();
            BotaoScanPrinc.Clicked += BotaoScanPrinc_Clicked;
            
        }

        private async void BotaoScanPrinc_Clicked(object sender, EventArgs e)
        {
            scanPage = new ZXingScannerPage();
            scanPage.OnScanResult += (result) =>
            {
                scanPage.IsScanning = false;

                //quando tiver lido
                Device.BeginInvokeOnMainThread(() =>
                {
                    Navigation.PopAsync();
                    DisplayAlert("Lendo Código de Barras", result.Text, "Ok");
                });
            };
            await Navigation.PushModalAsync(scanPage);
        }
    }
}
