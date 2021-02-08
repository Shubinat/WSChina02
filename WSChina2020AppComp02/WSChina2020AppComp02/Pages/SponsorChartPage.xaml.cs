using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WSChina2020AppComp02.Pages
{
    /// <summary>
    /// Логика взаимодействия для SponsorChartPage.xaml
    /// </summary>
    public partial class SponsorChartPage : Page
    {
        List<int?> selectedYears = new List<int?>();
        List<Entities.SponsorClassName> sponsorClassNames;
        public SponsorChartPage()
        {
            InitializeComponent();
            var Years = new List<string>();
            AppData.Context.Competitions.ToList().ForEach(comp => Years.Add(comp.Year.ToString()));
            LVYears.ItemsSource = Years;

            sponsorClassNames = AppData.Context.SponsorClassNames.ToList();

            ChartSponsors.ChartAreas.Add(new ChartArea("Main"));
            var series = new Series("Sponsors")
            {
                IsValueShownAsLabel = true
            };
            ChartSponsors.Series.Add(series);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            selectedYears.Add(Int32.Parse((sender as CheckBox).Content.ToString()));
            UpdateChart();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            selectedYears.Remove(selectedYears.Find(unselected => unselected == Int32.Parse((sender as CheckBox).Content.ToString())));
            UpdateChart();
        }

        private void UpdateChart()
        {   
            Series currSeries = ChartSponsors.Series.FirstOrDefault();
            currSeries.ChartType = SeriesChartType.Column;
            currSeries.Points.Clear();
            var classNames = new List<Entities.SponsorClassName>();

            foreach (var year in selectedYears)
                foreach (var sponsorClassName in sponsorClassNames)
                    if (sponsorClassName.Competition.Year == year)
                        classNames.Add(sponsorClassName);
            foreach (var className in classNames)
                currSeries.Points.AddXY(className.Competition.Year, className.Amount);
        }
    }
}
