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
    
    public partial class CompletedModule
    {
        public int ID { get; set; }
        public Nullable<int> UserCompetitionID { get; set; }
        public Nullable<int> ModuleNumber { get; set; }
        public Nullable<double> Note { get; set; }
    
        public virtual UserCompetition UserCompetition { get; set; }
    }
}
