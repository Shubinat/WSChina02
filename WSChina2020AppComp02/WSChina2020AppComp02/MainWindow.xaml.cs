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

        }
        void timer_tick(object sender, EventArgs e)
        {
            if ((MainFrame.Content as Page).Title != null)
            {
                Title = "Skills Competetion Management System - " + (MainFrame.Content as Page).Title;
            }
            else
            {
                Title = "Skills Competetion Management System";
            }


            TimeSpan TimeRemaining = WS2021 - DateTime.Now;
            if (TimeRemaining.Seconds > 0 || TimeRemaining.Minutes > 0 || TimeRemaining.Hours > 0 || TimeRemaining.Days > 0) {
            CountDownBlock.Text = TimeRemaining.Days + " days, " + TimeRemaining.Hours + " hours, " + TimeRemaining.Minutes + " minutes and " + TimeRemaining.Seconds + " seconds until the WorldSkills Shanghai 2021 starts.";
            } else { 
            CountDownBlock.Text = "The WorldSkills Shanghai 2021 has started.";
            }
        }
    }
}
