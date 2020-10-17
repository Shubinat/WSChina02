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
    /// Логика взаимодействия для AboutShanghaiPage.xaml
    /// </summary>
    public partial class AboutShanghaiPage : Page
    {
        public AboutShanghaiPage()
        {
            InitializeComponent();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(TableGrid.Visibility == Visibility.Visible) { 
                selectedIMG.Source = (sender as Image).Source;
                selectedIMG.Visibility = Visibility.Visible;
                TableGrid.Visibility = Visibility.Hidden;
            }
        }

        private void selectedIMG_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(selectedIMG.Visibility == Visibility.Visible) { 
                selectedIMG.Visibility = Visibility.Hidden;
                TableGrid.Visibility = Visibility.Visible;
            }
        }
    }
}
