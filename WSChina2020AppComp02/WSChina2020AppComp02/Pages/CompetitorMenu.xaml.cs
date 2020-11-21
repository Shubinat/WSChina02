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
    /// Логика взаимодействия для CompetitorMenu.xaml
    /// </summary>
    public partial class CompetitorMenu : Page
    {
        User currUser;
        public CompetitorMenu(User user)
        {
            InitializeComponent();
            currUser = user;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var time = DateTime.Now.Hour;

            string HelloString = "Good ";
            if (time >= 5 && time < 12) //Morning
            {
                HelloString += "Morning";
            }
            else if (time >= 12 && time < 18) // Afternoon
            {
                HelloString += "Afternoon";
            }
            else if (time >= 18 && time < 22) //Evening
            {
                HelloString += "Evening";
            }
            else if (time >= 22 || time < 5) //Night
            {
                HelloString += "Night";
            }
            else
            {
                HelloString += "Day";
            }
            HelloString += "!\n";

            if(currUser.GenderID == 1)
            {
                HelloString += "Mr. ";
            }
            else if (currUser.GenderID == 2)
            {
                HelloString += "Mrs. ";
            }

            HelloString += currUser.Username;

            TBHello.Text = HelloString;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Functionality in development.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
