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
    /// Логика взаимодействия для ViewRegistrationPage.xaml
    /// </summary>
    public partial class ViewRegistrationPage : Page
    {
        
        public ViewRegistrationPage()
        {
            InitializeComponent();
        }

        private class SubTotalCompetence : Entities.Competence {

            public SubTotalCompetence(List<Entities.UserCompetition> users)
            {
                this.uCompetitions = users;
            }
            public List<Entities.UserCompetition> uCompetitions { get; set; }
            public override string SkillOfService { get => "Sub Total"; }
            public override int CompetitorsCount { get => uCompetitions.Sum(p => p.Competence.CompetitorsCount); }
            public override int JudgersCount { get => uCompetitions.Sum(p => p.Competence.JudgersCount); }
        }
        public ViewRegistrationPage(Entities.Competition currCompetition)
        {
            InitializeComponent();
            List<Entities.UserCompetition> userCompetitions = AppData.Context.UserCompetitions.ToList().GroupBy(uc => uc.Competence).Select(g => g.First()).ToList();
            foreach (var uc in userCompetitions)
            {
                uc.Competence.GetInfoByEvent(currCompetition); 
            }
            var subTotal = new Entities.UserCompetition() { Competence = new SubTotalCompetence(userCompetitions) };
            
            userCompetitions.Add(subTotal);
            DataGridBySkills.ItemsSource = userCompetitions;

        }
    }
}
