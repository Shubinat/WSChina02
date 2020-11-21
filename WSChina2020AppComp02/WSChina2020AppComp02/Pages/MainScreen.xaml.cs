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
    /// Логика взаимодействия для MainScreen.xaml
    /// </summary>
    public partial class MainScreen : Page
    {

        public MainScreen()
        {
            InitializeComponent();
        }

        private void BtnAboutWS_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AboutWorldskillsPage());
        }

        private void BtnAboutShangHai_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AboutShanghaiPage());
        }

        private void BtnAboutWSChina_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AboutWSChina());
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if(Properties.Settings.Default.UserID == -1) { 
                NavigationService.Navigate(new LoginScreen());
            }
            else
            {
                var currUser = AppData.Context.Users.ToList().First(p => p.UserID == Properties.Settings.Default.UserID);

                switch (currUser.RoleID)
                {
                    case 0:
                        NavigationService.Navigate(new CompetitorMenu(currUser));
                        break;
                    case 1:
                        NavigationService.Navigate(new CoordinatorMenu(currUser));
                        break;
                    case 2:
                        NavigationService.Navigate(new AdminMenu(currUser));
                        break;
                    case 3:
                        NavigationService.Navigate(new JudgerMenu(currUser));
                        break;  
                }    
            }
        }
    }
}
