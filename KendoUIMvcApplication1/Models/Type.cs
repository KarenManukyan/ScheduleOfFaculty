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
    
    public partial class Type
    {
        public Type()
        {
            this.JoinLessonTypes = new HashSet<JoinLessonType>();
        }
    
        public int Id { get; set; }
        public string Type1 { get; set; }
    
        public virtual ICollection<JoinLessonType> JoinLessonTypes { get; set; }
    }
}
