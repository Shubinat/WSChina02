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
using WSChina2020AppComp02.UserControls;

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
            var marks = AppData.Context.SavedMarks.ToList();
            foreach (var mark in marks)
            {
                Mark currMark = new Mark();
                currMark.DataContext = mark.Service;
                currMark.Margin = new Thickness(mark.PositionX, mark.PositionY, 0 , 0);
                currMark.MouseDown += Mark_Move;               
                Location.Children.Add(currMark);
            }
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            for (int i = Location.Children.Count - 1; i >= 0; i--)
                if(Location.Children[i] is Mark)
                    Location.Children.Remove(Location.Children[i]);
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            for (int i = AppData.Context.SavedMarks.Count()-1; i >= 0; i--)
                AppData.Context.SavedMarks.Remove(AppData.Context.SavedMarks.ToList()[i]);
            for (int i = 0; i < Location.Children.Count; i++) { 
                if (Location.Children[i] is Mark)
                {
                    AppData.Context.SavedMarks.Add(new SavedMark()
                    {
                        ServiceID = Convert.ToInt32((Location.Children[i] as Mark).TypeOfService.Text),
                        PositionX = (Location.Children[i] as Mark).Margin.Left,
                        PositionY = (Location.Children[i] as Mark).Margin.Top,
                    }
                    );
                }
            }
            AppData.Context.SaveChanges();
            MessageBox.Show("Changes was saved.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
        }


        private void Element_MouseDown(object sender, MouseButtonEventArgs e) => DragDrop.DoDragDrop((sender as Grid), (sender as Grid).DataContext, DragDropEffects.Copy);
        private void Location_Drop(object sender, DragEventArgs e)
        {
            var currService = e.Data.GetData(e.Data.GetFormats()[0]) as Service;
            Mark currMark = new Mark();
            currMark.DataContext = currService;
            currMark.Margin = new Thickness(e.GetPosition(Location).X , e.GetPosition(Location).Y, 0, 0);
            currMark.MouseDown += Mark_Move;
            Location.Children.Add(currMark);

        }

        
        private void Mark_Move(object sender, MouseButtonEventArgs e)
        {
            DragDrop.DoDragDrop((sender as Mark), (sender as Mark).DataContext, DragDropEffects.Move);
            ((sender as Mark).Parent as Canvas).Children.Remove(sender as Mark);
            
        }
    }
}
