using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSChina2020AppComp02.Entities
{
    public partial class Competition
    {
        public string CityAndCountry {
            get
            {
                
                return $"{City.Name}, {City.Country.Name}";
            }
        }

        public string EventName {

            get
            {
                return $"{Year} - {City.Country.Name} {City.Name}";
            }
        }

        public string  DurationText {
            get
            {
                return $"{StartDate.Day:D2}.{StartDate.Month:D2}.{StartDate.Year:D4} - {EndDate.Day:D2}.{EndDate.Month:D2}.{EndDate.Year:D4}";
            }
        }

    }
}
