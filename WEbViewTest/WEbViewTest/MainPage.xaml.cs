using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WEbViewTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await prgloading.ProgressTo(0.9, 900, Easing.SpringIn);
        }
        private void Openurl(object sender, EventArgs e)
        {
            Browser.Source = Entryurl.Text;
            prgloading.IsVisible = true;

        }
        void Handle_Navigated(object sender, WebNavigatedEventArgs e)
        {
            prgloading.IsVisible = false;
            switch (e.Result)
            {
                case WebNavigationResult.Cancel:
                    // TODO - do stuff here
                    break;
                case WebNavigationResult.Failure:
                    var htmlSource = new HtmlWebViewSource();
                    htmlSource.Html = @"<html><body><p>Intente usar la url completa incluyendo https://</p></body></html>";
                   

                    Browser.Source = htmlSource;
                    break;
                case WebNavigationResult.Success:
                    // TODO - do stuff here
                    break;
                case WebNavigationResult.Timeout:
                    // TODO - do stuff here
                    break;
                default:
                    // TODO - do stuff here
                    break;
            }
        }
        void Handle_Navigating(object sender, WebNavigatingEventArgs e)
        {
            prgloading.IsVisible = true;
        }
    }
}
