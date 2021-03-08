using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSChina2020AppComp02.Entities
{
    public partial class Competence
    {

        /// <summary>
        /// Полное название компетенции
        /// </summary>
        public virtual string SkillOfService
        {
            get
            {
                return $"{CompenceID} - {Name}";
            }
        }
        public List<User> CompetitorsBySkill { get; private set; }
        public virtual int CompetitorsCount { get => CompetitorsBySkill.Count; }
        public List<User> JudgersBySkill { get; private set; }

        public virtual int JudgersCount { get => JudgersBySkill.Count; }

        public void GetInfoByEvent(Competition competition)
        {
            var _list = AppData.Context.UserCompetitions.Where(p => p.CompetitionID == competition.CompetitionID).Where(p=>p.Competence.CompenceID == CompenceID).ToList();
            var judgersList = new List<User>();
            var competitorsList = new List<User>();
            foreach (var item in _list) if (item.User.RoleID == 0) competitorsList.Add(item.User);
            foreach (var item in _list) if (item.User.RoleID == 3) judgersList.Add(item.User);
            CompetitorsBySkill = competitorsList;
            JudgersBySkill = judgersList;
        }
        public string CompetitorsProvinces
        {
            get
            {
                if (CompetitorsBySkill != null) { 
                    string str = "";
                    for (int i = 0; i < CompetitorsBySkill.Count; i++)
                    {
                        if(i < CompetitorsBySkill.Count - 1) str += CompetitorsBySkill[i].City.Name + ", ";
                        else str += CompetitorsBySkill[i].City.Name;
                    }
                    return str;
                }
                return "";
            }
        }
        public string JudgersProvinces
        {
            get
            {
                if (JudgersBySkill != null) { 
                    string str = "";
                    for (int i = 0; i < JudgersBySkill.Count; i++)
                    {
                        if (i < JudgersBySkill.Count - 1) str += JudgersBySkill[i].City.Name + ", ";
                        else str += JudgersBySkill[i].City.Name;
                    }
                    return str;
                }
                return "";
            }
        }
    }
}
