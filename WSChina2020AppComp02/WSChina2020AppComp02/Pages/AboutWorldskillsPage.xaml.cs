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
    /// Логика взаимодействия для AboutWorldskillsPage.xaml
    /// </summary>
    public partial class AboutWorldskillsPage : Page
    {
        public AboutWorldskillsPage()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack) 
                NavigationService.GoBack();
;        }

        private void BtnHistory_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HistoryWSPage());
        }

        private void BtnCompetention_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CompetitionSkillsPage());
        }
    }
}
