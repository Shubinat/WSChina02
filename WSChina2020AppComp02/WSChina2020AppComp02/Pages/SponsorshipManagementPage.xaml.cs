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
    /// Логика взаимодействия для SponsorshipManagementPage.xaml
    /// </summary>
    public partial class SponsorshipManagementPage : Page
    {
        public SponsorshipManagementPage()
        {
            InitializeComponent();
        }

        private void BtnSponsorStat_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SponsorStatPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Functionality in development.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
