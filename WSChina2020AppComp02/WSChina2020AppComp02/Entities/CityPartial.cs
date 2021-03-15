using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSChina2020AppComp02.Entities
{
    public partial class City
    {
        public List<User> CompetitorsByCity { get; private set; }
        public virtual int CompetitorsCount { get => CompetitorsByCity.Count; }
        public List<User> JudgersByCity { get; private set; }

        public virtual int JudgersCount { get => JudgersByCity.Count; }

        public void GetInfoByEvent(Competition competition)
        {
            var _list = AppData.Context.UserCompetitions.Where(p => p.CompetitionID == competition.CompetitionID).Where(g => g.User.CityID == CityID).ToList();
            var judgersList = new List<User>();
            var competitorsList = new List<User>();
            foreach (var item in _list) if (item.User.RoleID == 0) competitorsList.Add(item.User);
            foreach (var item in _list) if (item.User.RoleID == 3) judgersList.Add(item.User);
            CompetitorsByCity = competitorsList;
            JudgersByCity = judgersList;
        }
        public string CompetitorsSkills
        {
            get
            {
                if (CompetitorsByCity != null)
                {
                    var competences = CompetitorsByCity.GroupBy(p => p.UserCompetitions.First().Competence.Name).Select(g => g.First()).ToList();
                    string str = "";
                    for (int i = 0; i < competences.Count; i++)
                    {
                        if (i < competences.Count - 1) str += competences[i].UserCompetitions.First(p=>p.UserID == competences[i].UserID).Competence.SkillOfService + ", ";
                        else str += competences[i].UserCompetitions.First(p => p.UserID == competences[i].UserID).Competence.SkillOfService;
                    }
                    return str;
                }
                return "";
            }
        }

        public string JudgersSkills
        {
            get
            {
                if (CompetitorsByCity != null)
                {
                    var competences = JudgersByCity.GroupBy(p => p.UserCompetitions.First().Competence.Name).Select(g => g.First()).ToList();
                    string str = "";
                    for (int i = 0; i < competences.Count; i++)
                    {
                        if (i < competences.Count - 1) str += competences[i].UserCompetitions.First(p => p.UserID == competences[i].UserID).Competence.SkillOfService + ", ";
                        else str += competences[i].UserCompetitions.First(p => p.UserID == competences[i].UserID).Competence.SkillOfService;
                    }
                    return str;
                }
                return "";
            }
        }
        public virtual bool IsTotal { get => false;}
        public string TableView
        {
            get
            {
                if (IsTotal) return "Sub Total";
                return Name;
            }
        }

    }
}
