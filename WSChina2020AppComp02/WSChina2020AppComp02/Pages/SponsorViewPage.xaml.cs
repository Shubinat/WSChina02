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
    /// Логика взаимодействия для SponsorViewPage.xaml
    /// </summary>
    public partial class SponsorViewPage : Page
    {
        public SponsorViewPage()
        {
            InitializeComponent();

            var Events = new List<string>();
            AppData.Context.Competitions.ToList().ForEach(p => Events.Add(p.EventName));
            Events.Insert(0, "All Events");
            CBEvents.ItemsSource = Events;

            var Sponsors = new List<string>();
            AppData.Context.Sponsors.ToList().ForEach(p => Sponsors.Add(p.Name));
            Sponsors.Insert(0, "All Sponsors");
            CBSponsors.ItemsSource = Sponsors;

            var Skills = new List<string>();
            AppData.Context.Competences.ToList().ForEach(p => Skills.Add(p.SkillOfService));
            Skills.Insert(0, "All Skills");
            CBSkills.ItemsSource = Skills;

            Search();
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e) => Search();

        private void Search()
        {
            var TableContent = AppData.Context.SponsorClassNames.ToList();
            TableContent = CBEvents.SelectedIndex != 0 ? TableContent.Where(p => p.CompetitionID == CBEvents.SelectedIndex).ToList() : TableContent;
            TableContent = CBSkills.SelectedIndex != 0 ? TableContent.Where(p => p.CompetenceID == CBSkills.SelectedIndex).ToList() : TableContent;
            TableContent = CBSponsors.SelectedIndex != 0 ? TableContent.Where(p => p.SponsorID == CBSponsors.SelectedIndex).ToList() : TableContent;
            SponsorsTable.ItemsSource = TableContent;
            TBInfo.Text = $"Total Records: {TableContent.Count}. Total Amount ($): {TableContent.Sum(p => p.Amount)}";
        }
    }
}
