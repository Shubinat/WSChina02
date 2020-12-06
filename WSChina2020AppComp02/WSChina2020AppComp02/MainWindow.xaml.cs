using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;
using System.Windows.Threading;
using WSChina2020AppComp02.Pages;
using Microsoft.Win32;
using System.IO;

namespace WSChina2020AppComp02
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DateTime WS2021 = new DateTime(2021, 09, 22, 0, 0, 0);
        public MainWindow()
        {
            
            InitializeComponent();
            
            MainFrame.Navigate(new Pages.MainScreen());



            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += timer_tick;
            timer.Start();
            /*
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == true)
            {
                AppData.Context.Users.ToList().First(p => p.UserID == 16).Photo = File.ReadAllBytes(ofd.FileName);
                AppData.Context.SaveChanges();
            }*/
        }
        void timer_tick(object sender, EventArgs e)
        {
            TimeSpan TimeRemaining = WS2021 - DateTime.Now;
            if (TimeRemaining.Seconds > 0 || TimeRemaining.Minutes > 0 || TimeRemaining.Hours > 0 || TimeRemaining.Days > 0) {
            CountDownBlock.Text = TimeRemaining.Days + " days, " + TimeRemaining.Hours + " hours, " + TimeRemaining.Minutes + " minutes and " + TimeRemaining.Seconds + " seconds until the WorldSkills Shanghai 2021 starts.";
            } else { 
            CountDownBlock.Text = "The WorldSkills Shanghai 2021 has started.";
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
                if (MainFrame.CanGoBack)
                    MainFrame.GoBack();
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {



            if ((MainFrame.Content as Page).Title != null)
            {
                Title = "Skills Competetion Management System - " + (MainFrame.Content as Page).Title;
            }
            else
            {
                Title = "Skills Competetion Management System";
            }

            if (Properties.Settings.Default.UserID != -1 && MainFrame.Content as Page is Pages.MainScreen)
            {
                BtnLogout.Visibility = Visibility.Visible;
            }
            else
            {
                BtnLogout.Visibility = Visibility.Hidden;
            }
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

            if ((MainFrame.Content as Page) is MainScreen)
            {
                MainHeader.Visibility = Visibility.Visible;
                SecondHeader.Visibility = Visibility.Hidden;
                HeaderGrid.Height = new GridLength(100);
            }
            else
            {
                MainHeader.Visibility = Visibility.Hidden;
                SecondHeader.Visibility = Visibility.Visible;
                HeaderGrid.Height = new GridLength(50);
            }



        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.UserID = -1;
            Properties.Settings.Default.Save();
            BtnLogout.Visibility = Visibility.Hidden;
        }
    }
}
