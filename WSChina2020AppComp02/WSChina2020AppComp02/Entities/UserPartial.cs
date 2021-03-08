using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSChina2020AppComp02.Entities
{
    public partial class User
    {

        public string Username {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public string UserText
        {
            get
            {
                return $"{Username} ({City.Country.Name})";
            }
        }

    }
}
