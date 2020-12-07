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
    /// Логика взаимодействия для MyResultsPage.xaml
    /// </summary>
    public partial class MyResultsPage : Page
    {
        User currUser;
        public MyResultsPage(User currUser)
        {
            InitializeComponent();
            this.currUser = currUser;
            UserInformation.DataContext = currUser;
            CompetitionInfo.DataContext = AppData.Context.UserCompetitions.ToList().First(p => p.UserID == currUser.UserID);

            List<CompletedModule> list = AppData.Context.CompletedModules.ToList().Where(p => p.UserCompetition == AppData.Context.UserCompetitions.ToList().First(g => g.UserID == currUser.UserID)).ToList();
            foreach (var item in list)
            {
                TextBlock tbName = new TextBlock()
                {
                    FontSize = 16,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    Margin = new Thickness(5),
                    Text = "Module " + item.ModuleNumber + ":",
                    FontFamily = new FontFamily("Microsoft Sans Serif"),
                    Foreground = Brushes.Gray,
                };
                TextBlock tbValue = new TextBlock()
                {
                    FontSize = 16,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Margin = new Thickness(5),
                    Text = item.Note != null? item.Note.ToString() : "No result",
                    FontFamily = new FontFamily("Microsoft Sans Serif"),
                    Foreground = Brushes.DarkGray,
                };
                StckNames.Children.Add(tbName);
                StckValues.Children.Add(tbValue);
            }
            double? sum = 0;
            for (int i = 0; i < list.Count; i++)
            {
                sum += list[i].Note;
            }
            SumResult.Text = sum == null ? "No result" : sum.ToString();
        }
    }
}
