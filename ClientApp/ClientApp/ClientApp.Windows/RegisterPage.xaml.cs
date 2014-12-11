/*
* FILE          : RegisterPage.xaml.cs
* PROJECT       : PROG2120 - Windows and Mobile Programming - Final Project
* PROGRAMMER    : Kevin Li, Bowen Zhuanj, Michael Da Silva
* FIRST VERSION : 2014-12-06
* DESCRIPTION   : This file contains the Client UI for windows tables that 
* displays the user login page used to connect to the server for the Brain Game.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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

        // NAME     :   LogInBtn_Click()
        // PURPOSE  :   Takes users input from textboxs and sends HTTP request to server to connect with.
        private void LogInBtn_Click(object sender, RoutedEventArgs e)
        {
            client = new MyHttpClient(ServerIPTB.Text, NameTB.Text);
            client.logInRequest();

            //check if ip is valid and the name is already existed on server side
            if (client.logInError == 0)
            {
                Frame.Navigate(typeof(MainPage), client);
                client.sendReady();
            }
            else if(client.logInError == 1)
            {
                ErrorMessageTB.Text = "Invalid IP or Name is already existed";
            }
            else if(client.logInError == 2)
            {
                ErrorMessageTB.Text = "Please wait for next game";
            }
        }
    }
}
