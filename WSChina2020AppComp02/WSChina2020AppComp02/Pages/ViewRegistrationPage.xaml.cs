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
        private List<Entities.UserCompetition> userCompetitions =  AppData.Context.UserCompetitions.ToList();
        public ViewRegistrationPage()
        {
            InitializeComponent();
        }

        public ViewRegistrationPage(Entities.Competition currCompetition)
        {
            InitializeComponent();
            List<Entities.UserCompetition> UsersBySkill = userCompetitions.GroupBy(uc => uc.Competence).Select(g => g.First()).ToList();
            foreach (var uc in UsersBySkill)
            {
                uc.Competence.GetInfoByEvent(currCompetition); 
            }
            var subTotal = new Entities.UserCompetition() { Competence = new Entities.SubTotalCompetence(UsersBySkill) };
            
            UsersBySkill.Add(subTotal);
            DataGridBySkills.ItemsSource = UsersBySkill;

            List<Entities.UserCompetition> UsersByProvince = userCompetitions.GroupBy(uc => uc.User.City.Name).Select(g => g.First()).ToList();
            foreach (var uc in UsersByProvince)
            {
                uc.User.City.GetInfoByEvent(currCompetition);
            }
            var _subTotal = new Entities.UserCompetition() { User = new Entities.User() { City = new Entities.SubTotalCity(UsersByProvince) } };
            UsersByProvince.Add(_subTotal);
            DataGridByProvince.ItemsSource = UsersByProvince;

        }
    }


}
