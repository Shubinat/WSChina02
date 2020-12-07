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


    }
}
