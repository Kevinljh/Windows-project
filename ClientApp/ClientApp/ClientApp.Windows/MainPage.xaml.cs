/*
* FILE          : MainPage.xaml.cs
* PROJECT       : PROG2120 - Windows and Mobile Programming - final Project
* PROGRAMMER    : Kevin Li, Bowen Zhuanj, Michael Da Silva
* FIRST VERSION : 2014-12-06
* DESCRIPTION   : This file contains the Client UI for windows tablets,
*  this is the users interface for the Brain Game.
*/

using ClientApp.Common;
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
using System.ComponentModel;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace ClientApp
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        DispatcherTimer dispatcherTimer;
        
        int seconds2 = 0;
        int seconds = 0;

        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        MyHttpClient client;

        public TextBlock messageTB;
        public Button nextGameBtn;
        public TextBlock questionTB;
        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }


        public MainPage()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;
            messageTB = ResultTB;
            nextGameBtn = NextGameBtn;
            questionTB = QuestionPlaceHolder;
        }

        /// <summary>
        /// Populates the page with content passed during navigation. Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session. The state will be null the first time a page is visited.</param>
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            Windows.Storage.ApplicationDataContainer roamingSettings =
                Windows.Storage.ApplicationData.Current.RoamingSettings;
            if (roamingSettings.Values.ContainsKey("Abutton"))
            {
                // Abutton = (int)roamingSettings.Values["Abutton"];
            }
            if (roamingSettings.Values.ContainsKey("Bbutton"))
            {
                // Abutton = (int)roamingSettings.Values["Abutton"];
            }
            if (roamingSettings.Values.ContainsKey("Cbutton"))
            {
                // Abutton = (int)roamingSettings.Values["Abutton"];
            }
            if (roamingSettings.Values.ContainsKey("Dbutton"))
            {
                // Abutton = (int)roamingSettings.Values["Abutton"];
            }

            client = e.NavigationParameter as MyHttpClient;
            client.myMainPage = this;
            ScoreTb.DataContext = client;
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {

        }

        #region NavigationHelper registration

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        // NAME     :   DispatcherTimerSetup()
        // PURPOSE  :   Setups the dispatcherTimer, and adds the ticks together 
        public void DispatcherTimerSetup()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1);
        }

        // NAME     :   dispatcherTimer_Tick()
        // PURPOSE  :   Acts as the clock, every second/tick, 1 is added to the seconds
        void dispatcherTimer_Tick(object sender, object e)
        {
            Timer.Text = "Time:" + seconds2 + seconds;
                       
            
            seconds++;
            if (seconds > 9)
            {
                seconds2++;
                seconds = 0;
            }
            else if (seconds2 > 0)
            {
                seconds2 = 0;
                seconds = 0;
                disableEnable();
            }

            if (seconds2 == 0 && seconds == 0)
            {
                //TimerStop();
                client.sendQuestionRequest();
            }

            // save the session variable to keep track of seconds while application is closed or on another page
            Windows.Storage.ApplicationDataContainer roamingSettings =
            Windows.Storage.ApplicationData.Current.RoamingSettings;
            roamingSettings.Values["TimerSave"] = Timer.Text;
            roamingSettings.Values["seconds"] = seconds;
            roamingSettings.Values["seconds2"] = seconds2;
            
        }

        // NAME     :   Timer_Loaded()
        // PURPOSE  :   Setup the dispatch timer when loaded and hide to stop button
        private void Timer_Load(object sender, RoutedEventArgs e)
        {
            DispatcherTimerSetup();         
        }
        // NAME     :   TimerStart()
        // PURPOSE  :   Function To start the dispatcherTimer
        public void TimerStart()
        {
            dispatcherTimer.Start();
        }

        // NAME     :   TimerStop()
        // PURPOSE  :   Function To Stop the dispatcherTimer
        public void TimerStop()
        {
            dispatcherTimer.Stop();
        }

        // NAME     :   TimerReset()
        // PURPOSE  :   Function To Reset the dispatcherTimer to 00
        private void TimerReset()
        {
            seconds = 0;
            seconds2 = 0;
            Windows.Storage.ApplicationDataContainer roamingSettings =
            Windows.Storage.ApplicationData.Current.RoamingSettings;
            roamingSettings.Values["seconds"] = 0;
            roamingSettings.Values["seconds2"] = 0;
        }

        // NAME     :   AButton_Click()
        // PURPOSE  :   When Button "a" is pressed the client will send that user pressed "a"
        private void disableEnable()
        {
            if ((ButtonA.IsEnabled == true) || (ButtonB.IsEnabled == true) || (ButtonC.IsEnabled == true) || (ButtonD.IsEnabled == true))
            {
                ButtonA.IsEnabled = false;
                ButtonB.IsEnabled = false;
                ButtonC.IsEnabled = false;
                ButtonD.IsEnabled = false;

            }
            else if ((ButtonA.IsEnabled == false) || (ButtonB.IsEnabled == false) || (ButtonC.IsEnabled == false) || (ButtonD.IsEnabled == false))
            {
                ButtonA.IsEnabled = true;
                ButtonB.IsEnabled = true;
                ButtonC.IsEnabled = true;
                ButtonD.IsEnabled = true;
            }
        }

        // NAME     :   AButton_Click()
        // PURPOSE  :   When Button "a" is pressed the client will send that user pressed "a"
        private void AButton_Click(object sender, RoutedEventArgs e)
        {      
            client.sendAnwser("a");
            disableEnable();
            
          
        }

        // NAME     :   BButton_Click()
        // PURPOSE  :   When Button "b" is pressed the client will send that user pressed "b"
        private void BButton_Click(object sender, RoutedEventArgs e)
        {     
            client.sendAnwser("b");
            disableEnable();
        }

        // NAME     :   CButton_Click()
        // PURPOSE  :   When Button "c" is pressed the client will send that user pressed "c"
        private void CButton_Click(object sender, RoutedEventArgs e)
        {  
            client.sendAnwser("c");
            disableEnable();
        }

        // NAME     :   DButton_Click()
        // PURPOSE  :   When Button "d" is pressed the client will send that user pressed "d"
        private void DButton_Click(object sender, RoutedEventArgs e)
        {
            client.sendAnwser("d");
            disableEnable();
        }

        // NAME     :   QuestionPlaceHolder_Loaded()
        // PURPOSE  :   Load Question into QuestionPlaceHolder TextBlock
        private void QuestionPlaceHolder_Loaded(object sender, RoutedEventArgs e)
        {
            //QuestionPlaceHolder.Text = "Wild mice only live for an average of? \n" +
            //"A) 2 and a half years \n" + "B) 10 years \n" + "C) 4 months \n" + "D) 3 and a half years ";
        }

        public void ResultMessage(string result)
        {
            ResultTB.Text = result;
        }

        public void ShowQuestion(string question)
        {
            QuestionPlaceHolder.Text = question;
        }

        private void NextGameBtn_Click(object sender, RoutedEventArgs e)
        {
            client.sendReady();
        }
    }
}
