using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ClientApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegisterPage : Page
    {
        private MyHttpClient client;

        public RegisterPage()
        {
            this.InitializeComponent();         
        }

        private void LogInBtn_Click(object sender, RoutedEventArgs e)
        {
            client = new MyHttpClient(ServerIPTB.Text, NameTB.Text);
            client.logInRequest();
            Frame.Navigate(typeof(MainPage), client);
        }
    }
}
