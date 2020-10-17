using Microsoft.Win32;
using System;
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
    /// Логика взаимодействия для AboutWSChina.xaml
    /// </summary>
    public partial class AboutWSChina : Page
    {
        public AboutWSChina()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        { 
            ///
        }



        private void AccessionWSBtn_Click(object sender, RoutedEventArgs e)
        {
            NameOfSavingFile.Text = "Host city Shanghai.txt";
            NameOfSavingFile.Visibility = Visibility.Visible;
            BtnSave.Visibility = Visibility.Visible;
        }

        private void CommitteeWSBtn_Click(object sender, RoutedEventArgs e)
        {
            NameOfSavingFile.Text = "Committee of Worldskills China.txt";
            NameOfSavingFile.Visibility = Visibility.Visible;
            BtnSave.Visibility = Visibility.Visible;
        }

        private void ResultsBtn_Click(object sender, RoutedEventArgs e)
        {
            NameOfSavingFile.Text = "Participation and results.txt";
            NameOfSavingFile.Visibility = Visibility.Visible;
            BtnSave.Visibility = Visibility.Visible;
        }
    }
}
