using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSChina2020AppComp02.Entities
{
    partial class Category
    {
        /// <summary>
        /// Возращает список спонсоров спонсирующих данную категорию в какой-то чемпионат
        /// </summary>
        /// <param name="CompetitionID">ID чемпионата</param>
        /// <returns></returns>
        private List<Sponsor> SponsorList(int CompetitionID)
        { 
                var sponsorList = new List<Sponsor>();
                var classNamesList = AppData.Context.SponsorClassNames.ToList().Where(c=>c.CompetitionID == CompetitionID).Where(p => p.CategoryID == CategoryID).ToList();
                foreach(var className in classNamesList)
                {
                    sponsorList.Add(className.Sponsor);
                }
                return sponsorList;
        }
        
        /// <summary>
        /// По-факту метод set у св-ва Sponsors. Просто чтобы высчитать всех спонсоров нужно знать ID чемпионата на котором эти спонсоры были.
        /// </summary>
        /// <param name="CompetitionID">ID чемпионата</param>
        public void CalculateSponsors(int CompetitionID) {
                var result = "";
                for (int i = 0; i < SponsorList(CompetitionID).Count; i++)
                {
                    if (i != SponsorList(CompetitionID).Count - 1) result += SponsorList(CompetitionID)[i].Name + "; ";
                    else result += SponsorList(CompetitionID)[i].Name;
                }
            Sponsors = result;


        }

        /// <summary>
        /// По-факту метод set у св-ва SummaryAmount. Просто чтобы высчитать сумму вложенных средств, нужно ID чемпионата на котором эти спонсоры вкладывали эти средства.
        /// </summary>
        /// <param name="CompetitionID">ID чемпионата</param>
        public void CalculateAmount(int CompetitionID) {

                decimal Sum = 0.00m;
                var classNamesList = AppData.Context.SponsorClassNames.ToList().Where(c=>c.CompetitionID == CompetitionID).Where(p => p.CategoryID == CategoryID).ToList();
                foreach (var className in classNamesList)
                {
                    Sum += (decimal)className.Amount;
                }
                SummaryAmount = Sum;
        }

        /// <summary>
        /// Текстовое представление спонсоров
        /// </summary>
        public string Sponsors { get; private set; }
        /// <summary>
        /// Суммарное количество денег вложеных в данную категорию всему спонсорами
        /// </summary>
        public decimal SummaryAmount { get; private set; }
    }
}
