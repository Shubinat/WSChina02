﻿using System;
using System.Collections.Generic;
using System.Linq;
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

namespace WSChina2020AppComp02.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainScreen.xaml
    /// </summary>
    public partial class MainScreen : Page
    {

        public MainScreen()
        {
            InitializeComponent();
        }

        private void BtnAboutWS_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AboutWorldskillsPage());
        }

        private void BtnAboutShangHai_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AboutShanghaiPage());
        }

        private void BtnAboutWSChina_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AboutWSChina());
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginScreen());
        }
    }
}
