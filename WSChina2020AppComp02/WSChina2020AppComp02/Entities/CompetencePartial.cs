using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSChina2020AppComp02.Entities
{
    public partial class Competence
    {
        public string SkillOfService
        {
            get
            {
                return $"{CompenceID} - {Name}";
            }
        }

    }
}
