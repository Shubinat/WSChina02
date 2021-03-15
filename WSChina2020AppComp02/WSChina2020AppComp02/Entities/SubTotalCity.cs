using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSChina2020AppComp02.Entities
{
    public class SubTotalCity : Entities.City
    {
        public override bool IsTotal { get => true; }
        public SubTotalCity(List<Entities.UserCompetition> users)
        {
            this.uCompetitions = users;
            CompetitorsCount = uCompetitions.Sum(p => p.User.City.CompetitorsCount);
            JudgersCount = uCompetitions.Sum(p => p.User.City.JudgersCount);
        }
        private List<Entities.UserCompetition> uCompetitions { get; set; }
        public override int CompetitorsCount { get; }
        public override int JudgersCount { get; }
    }
}
