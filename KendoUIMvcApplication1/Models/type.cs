//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ScheduleOfFaculty.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class type
    {
        public type()
        {
            this.lessons = new HashSet<lesson>();
        }
    
        public int id { get; set; }
        public string type1 { get; set; }
    
        public virtual ICollection<lesson> lessons { get; set; }
    }
}
