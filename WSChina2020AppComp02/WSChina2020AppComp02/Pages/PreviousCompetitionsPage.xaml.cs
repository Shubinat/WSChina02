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
    /// Логика взаимодействия для PreviosCompetitionsPage.xaml
    /// </summary>
    public partial class PreviosCompetitionsPage : Page
    {
        public PreviosCompetitionsPage()
        {
            InitializeComponent();
            CompetitionsGrid.ItemsSource = AppData.Context.Previos_Competitions.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
        }
    }
}
