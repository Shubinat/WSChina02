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
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.UserCompetitions = new HashSet<UserCompetition>();
        }
    
        public string FirstName { get; set; }
        public int UserID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }
        public Nullable<int> GenderID { get; set; }
        public byte[] Photo { get; set; }
        public string LastName { get; set; }
        public Nullable<int> CountryID { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public Nullable<long> PhoneNumber { get; set; }
        public string Email { get; set; }
    
        public virtual Country Country { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Role Role { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserCompetition> UserCompetitions { get; set; }
    }
}
