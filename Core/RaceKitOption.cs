//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MaraphonSkills.Core
{
    using System;
    using System.Collections.Generic;
    
    public partial class RaceKitOption
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RaceKitOption()
        {
            this.Registration = new HashSet<Registration>();
        }
    
        public int RaceKitOptionId { get; set; }
        public string RaceKitOption1 { get; set; }
        public decimal Cost { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Registration> Registration { get; set; }
    }
}
