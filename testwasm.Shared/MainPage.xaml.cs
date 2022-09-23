using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System.Net.Http;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace testwasm
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void GetSomeData_Click(object sender, RoutedEventArgs e)
        {
            System.Net.Http.HttpClient cli = new System.Net.Http.HttpClient();
            try
            {
                HttpResponseMessage res = null;
                res = await cli.GetAsync("http://localhost:7878/WeatherForecast");
                if (res.IsSuccessStatusCode)
                {
                    FeedBack("Success call");
                }
                else
                {
                    FeedBack($"Error call: {res.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                FeedBack($"Exception call: {ex.Message}");
            }
        }

        private void FeedBack(string text)
        {
            TextResult.Text = text;
        }
    }
}
