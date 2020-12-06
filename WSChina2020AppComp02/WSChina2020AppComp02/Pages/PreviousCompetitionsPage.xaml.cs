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
using System.Windows.Interop;
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
            try
            {
                CompetitionsGrid.ItemsSource = AppData.Context.Competitions.ToList();
                int? sum = 0;
                foreach (var item in AppData.Context.Competitions.ToList())
                {
                    sum += item.MemberNumber;
                }
                TBTotalRec.Text = "Total Records: " + sum;
                sum = 0;
            }
            catch (Exception)
            {

                MessageBox.Show("The database cannot be found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }



        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TxtBoxOrdinal.Text != null && TxtBoxCity.Text != null)
            {
                var list = AppData.Context.Competitions.ToList().Where(p => p.CityAndCountry.ToLower().Trim().Contains(TxtBoxCity.Text.ToLower().Trim()) &&
                     p.OrdinalNo.ToLower().Trim().Contains(TxtBoxOrdinal.Text.ToLower().Trim())).ToList();
                CompetitionsGrid.ItemsSource = list;
                int? sum = 0;
                foreach (var item in list)
                {
                    sum += item.MemberNumber;
                }
                TBTotalRec.Text = "Total Records: " + sum;
                sum = 0;
            }
        }
    }
}
