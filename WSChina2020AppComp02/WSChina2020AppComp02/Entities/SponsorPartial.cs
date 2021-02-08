using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSChina2020AppComp02.Entities
{
    partial class Sponsor
    {
        /// <summary>
        /// Возращает список категорий спонсируемых спонсором
        /// </summary>
        /// <param name="CompetitionID">ID чемпионата</param>
        /// <returns></returns>
        private List<Category> CategoryList(int CompetitionID)
        {
            var categoryList = new List<Category>();
            var classNamesList = AppData.Context.SponsorClassNames.ToList().Where(c => c.CompetitionID == CompetitionID).Where(p => p.SponsorID == SponsorID).ToList();
            foreach (var className in classNamesList)
            {
                categoryList.Add(className.Category);
            }
            return categoryList;
        }

        /// <summary>
        /// По-факту метод set у св-ва Categories. Просто чтобы высчитать все категории нужно знать ID чемпионата на котором эти категории были спонсированы.
        /// </summary>
        /// <param name="CompetitionID">ID чемпионата</param>
        public void CalculateCategories(int CompetitionID)
        {
            var result = "";
            for (int i = 0; i < CategoryList(CompetitionID).Count; i++)
            {
                if (i != CategoryList(CompetitionID).Count - 1) result += CategoryList(CompetitionID)[i].Name + "; ";
                else result += CategoryList(CompetitionID)[i].Name;
            }
            Categories = result;
        }

        /// <summary>
        /// По-факту метод set у св-ва SummaryAmount. Просто чтобы высчитать сумму вложенных средств, нужно ID чемпионата на котором эти средства были вложены в какие-то категории
        /// </summary>
        /// <param name="CompetitionID">ID чемпионата</param>
        public void CalculateAmount(int CompetitionID)
        {

            decimal Sum = 0.00m;
            var classNamesList = AppData.Context.SponsorClassNames.ToList().Where(c => c.CompetitionID == CompetitionID).Where(p => p.SponsorID == SponsorID).ToList();
            foreach (var className in classNamesList)
            {
                Sum += (decimal)className.Amount;
            }
            SummaryAmount = Sum;
        }

        /// <summary>
        /// Текстовое представление категорий
        /// </summary>
        public string Categories { get; private set; }
        /// <summary>
        /// Суммарное количество денег вложеных спонсором в набор категорий
        /// </summary>
        public decimal SummaryAmount { get; private set; }

    }
}
