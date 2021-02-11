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
    /// Логика взаимодействия для CompSerPage.xaml
    /// </summary>
    public partial class CompSerPage : Page
    {
        public CompSerPage()
        {
            InitializeComponent();
            LVServicesList.ItemsSource = AppData.Context.Services.ToList();

        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

        }



        private void Location_Drop(object sender, DragEventArgs e)
        {

        }

        private void Element_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragDrop.DoDragDrop((sender as Grid), (sender as Grid).DataContext, DragDropEffects.Copy);
        }
    }
}
