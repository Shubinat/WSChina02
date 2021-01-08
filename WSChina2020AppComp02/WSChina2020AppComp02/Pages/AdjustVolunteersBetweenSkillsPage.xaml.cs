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
    /// Логика взаимодействия для AdjustVolunteersBetweenSkillsPage.xaml
    /// </summary>
    public partial class AdjustVolunteersBetweenSkillsPage : Page
    {
        /// <summary>
        /// Лист для хранения выделеных волонтеров в первой таблице
        /// </summary>
        List<Entities.Volunteer> FirstTableSelectedVolunteers = new List<Entities.Volunteer>();

        /// <summary>
        /// Лист для хранения выделеных волонтеров во второй таблице
        /// </summary>
        List<Entities.Volunteer> SecondTableSelectedVolunteers = new List<Entities.Volunteer>();
        public AdjustVolunteersBetweenSkillsPage()
        {
            InitializeComponent();
            CBFirstTable.ItemsSource = AppData.Context.Competences.ToList();
            CBFirstTable.DisplayMemberPath = "SkillOfService";
            CBFirstTable.SelectedIndex = 0;
            TextBlockFirstTable.Text = "Total volunteers: " + AppData.Context.Volunteers.ToList().Where(p => p.CompetenceID == (CBFirstTable.SelectedIndex + 1)).ToList().Count;

            CBSecondTable.ItemsSource = AppData.Context.Competences.ToList();
            CBSecondTable.DisplayMemberPath = "SkillOfService";
            CBSecondTable.SelectedIndex = 0;
            TextBlockSecondTable.Text = "Total volunteers: " + AppData.Context.Volunteers.ToList().Where(p => p.CompetenceID == (CBSecondTable.SelectedIndex + 1)).ToList().Count;
        }

        private void BtnRigth_Click(object sender, RoutedEventArgs e)
        {
            if(CBFirstTable.SelectedIndex != CBSecondTable.SelectedIndex)
            {
                foreach (var item in FirstTableSelectedVolunteers)
                    AppData.Context.Volunteers.ToList().First(p => p.VolunteerID == item.VolunteerID).CompetenceID = (CBSecondTable.SelectedIndex + 1);
                BtnFirstTableSearch_Click(new object(), new RoutedEventArgs());
                BtnSecondTableSearch_Click(new object(), new RoutedEventArgs());
            }
            else
                MessageBox.Show("You can't transfer volunteers to the same competence.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void BtnLeft_Click(object sender, RoutedEventArgs e)
        {
            if (CBFirstTable.SelectedIndex != CBSecondTable.SelectedIndex)
            {
                foreach (var item in SecondTableSelectedVolunteers)
                    AppData.Context.Volunteers.ToList().First(p => p.VolunteerID == item.VolunteerID).CompetenceID = (CBFirstTable.SelectedIndex + 1);
                BtnFirstTableSearch_Click(new object(), new RoutedEventArgs());
                BtnSecondTableSearch_Click(new object(), new RoutedEventArgs());
            }
            else
                MessageBox.Show("You can't transfer volunteers to the same competence.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void BtnFirstTableSearch_Click(object sender, RoutedEventArgs e)
        {
            FirstTable.ItemsSource = AppData.Context.Volunteers.ToList().Where(p => p.CompetenceID == (CBFirstTable.SelectedIndex + 1)).ToList();
            TextBlockFirstTable.Text = "Total volunteers: " + AppData.Context.Volunteers.ToList().Where(p => p.CompetenceID == (CBFirstTable.SelectedIndex + 1)).ToList().Count;
            FirstTableSelectedVolunteers.Clear();
        }

        private void BtnSecondTableSearch_Click(object sender, RoutedEventArgs e)
        {
            SecondTable.ItemsSource = AppData.Context.Volunteers.ToList().Where(p => p.CompetenceID == (CBSecondTable.SelectedIndex + 1)).ToList();
            TextBlockSecondTable.Text = "Total volunteers: " + AppData.Context.Volunteers.ToList().Where(p => p.CompetenceID == (CBSecondTable.SelectedIndex + 1)).ToList().Count;
            SecondTableSelectedVolunteers.Clear();
        }

        private void FirstTableChecked(object sender, RoutedEventArgs e)
        {
            FirstTableSelectedVolunteers.Add(AppData.Context.Volunteers.ToList().First(p=> p.VolunteerID == Convert.ToInt32(((sender as CheckBox).Content as TextBlock).Text)));
        }

        private void FirstTableUnChecked(object sender, RoutedEventArgs e)
        {
            FirstTableSelectedVolunteers.Remove(AppData.Context.Volunteers.ToList().First(p => p.VolunteerID == Convert.ToInt32(((sender as CheckBox).Content as TextBlock).Text)));
        }

        private void SecondTableChecked(object sender, RoutedEventArgs e)
        {
            SecondTableSelectedVolunteers.Add(AppData.Context.Volunteers.ToList().First(p => p.VolunteerID == Convert.ToInt32(((sender as CheckBox).Content as TextBlock).Text)));
        }

        private void SecondTableUnChecked(object sender, RoutedEventArgs e)
        { 
            SecondTableSelectedVolunteers.Remove(AppData.Context.Volunteers.ToList().First(p => p.VolunteerID == Convert.ToInt32(((sender as CheckBox).Content as TextBlock).Text)));
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            AppData.Context.SaveChanges();
            MessageBox.Show("The changes was saved.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
