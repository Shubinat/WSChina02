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
    /// Логика взаимодействия для MySkillsPage.xaml
    /// </summary>
    public partial class MySkillsPage : Page
    {
        User currUser;
        public MySkillsPage(User user)
        {
            InitializeComponent();
            currUser = user;
            TxtMySkills.Text = AppData.Context.UserCompetitions.ToList().First(p => p.User == user).Competence.CompenceID + " - " + AppData.Context.UserCompetitions.ToList().First(p => p.User == user).Competence.Name;
          
            LVCompetitors.ItemsSource = Filter(0,currUser);
            LVJudgers.ItemsSource = Filter(3,currUser);
                
        }
        /// <summary>
        /// Фильтрует данные таблицы UserCompetitions по роли пользователя.
        /// </summary>
        /// <param name="Role">Role = 0 - Участник
        /// Role = 3 - Эксперт</param>
        /// <param name="user">Затычка т.к. при использовании currUser возникает ошибка.</param>
        /// <returns>Список UserCompetition в котором только участники, либо только эксперты.</returns>
        public static List<UserCompetition> Filter(int Role, User user)
        {
            var list = AppData.Context.UserCompetitions.ToList().Where(p => p.CompetenceID == AppData.Context.UserCompetitions.ToList().First(g => g.User == user).Competence.CompenceID).ToList();
            List<UserCompetition> _list = new List<UserCompetition>();
            foreach (UserCompetition _userCompetition in list)
            {
                foreach (User _user in AppData.Context.Users.ToList().Where(p => p.RoleID == Role).ToList())
                {
                    if (_user.UserID == _userCompetition.UserID)
                    {
                        _list.Add(_userCompetition);
                    }
                }
            }
            return _list;
        }

    }
}
