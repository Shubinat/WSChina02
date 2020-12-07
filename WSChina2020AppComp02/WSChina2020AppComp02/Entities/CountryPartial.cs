using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSChina2020AppComp02.Entities
{
    public partial class Country
    {
        public string NameAndCode {

            get {
                return $"{Name} ({CountryCode})";
                }
        }
    }
}
