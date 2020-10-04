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
    /// Логика взаимодействия для CompetitionSkillsPage.xaml
    /// </summary>
    public partial class CompetitionSkillsPage : Page
    {
        

        public CompetitionSkillsPage()
        {
            InitializeComponent();
            List<Entities.Block> blocks = AppData.Context.Blocks.ToList();
            foreach (var block in blocks)
            {
                TreeViewItem item = new TreeViewItem() { Name = "Block_" + block.BlockID.ToString(), Header = block.Name};
                Tree.Items.Add(item);

                foreach (var competition in block.Competitions.ToList())
                {
                    TreeViewItem child = new TreeViewItem()
                    {
                        Name = "Competition_" + competition.CompetitionId.ToString(),
                        Header = competition.CompetitionId + ". " + competition.Name
                    };
                    child.Selected += Competition_Selected;
                    item.Items.Add(child);

                    void Competition_Selected(object sender, RoutedEventArgs e)
                    {
                        TreeViewItem element = (TreeViewItem)sender;
                        CompetitionNameBlock.Text = competition.CompetitionId + " - " + competition.Name;
                        InformationBlock.Text = competition.Description;
                    }
                }

            }

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if(NavigationService.CanGoBack)
                NavigationService.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            

        }



    }
}
