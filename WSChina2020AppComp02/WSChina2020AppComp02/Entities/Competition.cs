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
    
    public partial class Competition
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Competition()
        {
            this.SponsorClassNames = new HashSet<SponsorClassName>();
            this.UserCompetitions = new HashSet<UserCompetition>();
        }
    
        public string OrdinalNo { get; set; }
        public Nullable<int> Year { get; set; }
        public Nullable<int> MemberNumber { get; set; }
        public int CompetitionID { get; set; }
        public Nullable<int> CityID { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
    
        public virtual City City { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SponsorClassName> SponsorClassNames { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserCompetition> UserCompetitions { get; set; }
    }
}
