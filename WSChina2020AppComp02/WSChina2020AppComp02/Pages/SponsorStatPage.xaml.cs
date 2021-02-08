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
using WSChina2020AppComp02.Entities;

namespace WSChina2020AppComp02.Pages
{
    /// <summary>
    /// Логика взаимодействия для SponsorStatPage.xaml
    /// </summary>
    public partial class SponsorStatPage : Page
    {
        public SponsorStatPage()
        {
            InitializeComponent();
            CBEvent.ItemsSource = AppData.Context.Competitions.ToList();
            CBEvent.DisplayMemberPath = "EventName";
            CBEvent.SelectedIndex = 46;

        }

        private void BtnShowStat_Click(object sender, RoutedEventArgs e)
        {
            if(CBClass.SelectedIndex == 0) { 
            var list = AppData.Context.SponsorClassNames.ToList().Where(p => p.CompetitionID == (CBEvent.SelectedIndex + 1)).GroupBy(g => g.CategoryID).Select(k => k.First());
            decimal TotalAmount = 0.00m;
            foreach (var item in list)
            {
                item.Category.CalculateAmount(CBEvent.SelectedIndex + 1);
                item.Category.CalculateSponsors(CBEvent.SelectedIndex + 1);
                TotalAmount += item.Category.SummaryAmount;
            }
            TBTotal.Text = "Total Amount (¥): " + TotalAmount;
            DataGrdCategories.ItemsSource = list;
                DataGrdCategories.Visibility = Visibility.Visible;
                DataGrdSponsors.Visibility = Visibility.Hidden;
            }
            else
            {
                var list = AppData.Context.SponsorClassNames.ToList().Where(p => p.CompetitionID == (CBEvent.SelectedIndex + 1)).GroupBy(g => g.SponsorID).Select(k => k.First());
                decimal TotalAmount = 0.00m;
                foreach (var item in list)
                {
                    item.Sponsor.CalculateAmount(CBEvent.SelectedIndex + 1);
                    item.Sponsor.CalculateCategories(CBEvent.SelectedIndex + 1);
                    TotalAmount += item.Sponsor.SummaryAmount;
                }
                TBTotal.Text = "Total Amount (¥): " + TotalAmount;
                DataGrdSponsors.ItemsSource = list;
                DataGrdCategories.Visibility = Visibility.Hidden;
                DataGrdSponsors.Visibility = Visibility.Visible;
            }
        }
    }
}
