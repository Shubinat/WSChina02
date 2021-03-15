using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSChina2020AppComp02.Entities
{
    public class SubTotalCompetence : Entities.Competence
    {

        public SubTotalCompetence(List<Entities.UserCompetition> users)
        {
            this.uCompetitions = users;
            CompetitorsCount = uCompetitions.Sum(p => p.Competence.CompetitorsCount);
            JudgersCount = uCompetitions.Sum(p => p.Competence.JudgersCount);
        }
        private List<Entities.UserCompetition> uCompetitions { get; set; }
        public override string SkillOfService { get => "Sub Total"; }
        public override int CompetitorsCount { get; }
        public override int JudgersCount { get; }
    }
}
