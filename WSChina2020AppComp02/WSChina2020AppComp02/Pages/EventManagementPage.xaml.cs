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
    /// Логика взаимодействия для EventManagementPage.xaml
    /// </summary>
    public partial class EventManagementPage : Page
    {
        public EventManagementPage()
        {
            InitializeComponent();
        }

        private void CompetitionEventBtn_Click(object sender, RoutedEventArgs e) => NavigationService.Navigate(new CompetitionEventPage());
    }
}
