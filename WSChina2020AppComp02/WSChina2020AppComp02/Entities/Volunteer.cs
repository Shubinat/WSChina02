//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WSChina2020AppComp02.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Volunteer
    {
        public int VolunteerID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int GenderID { get; set; }
        public int OccupationCityID { get; set; }
        public int ProvinceCityID { get; set; }
        public int CompetenceID { get; set; }
        public System.DateTime DateOfBirth { get; set; }
    
        public virtual City City { get; set; }
        public virtual City City1 { get; set; }
        public virtual Competence Competence { get; set; }
        public virtual Gender Gender { get; set; }
    }
}
