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
    /// Логика взаимодействия для CompetitionEventPage.xaml
    /// </summary>
    public partial class CompetitionEventPage : Page
    {
        /// <summary>
        /// Список всех чемпионатов
        /// </summary>
        private List<Entities.Competition> _competitions = AppData.Context.Competitions.ToList();
        /// <summary>
        /// Выбранная строчка в таблице
        /// </summary>
        private Entities.Competition _selectedCompetition;
        public CompetitionEventPage()
        {
            InitializeComponent();
            EventsDataGrid.ItemsSource = _competitions;
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            EventsDataGrid.ItemsSource =  _competitions.Where(competition => competition.EventName.ToLower().Contains(SearchTxtBox.Text.ToLower()));
        }

        private void Button_Click(object sender, RoutedEventArgs e) => MessageBox.Show("Functionality in development.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);

        

        private void EventsDataGrid_Selected(object sender, RoutedEventArgs e)
        {
            _selectedCompetition = (sender as DataGrid).CurrentCell.Item as Entities.Competition;
        }

        private void ViewRegBtn_Click(object sender, RoutedEventArgs e)
        {
            if(_selectedCompetition != null) NavigationService.Navigate(new ViewRegistrationPage(_selectedCompetition));
            else MessageBox.Show("Please, select an event.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
