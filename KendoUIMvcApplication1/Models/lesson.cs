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
    
    public partial class Lesson
    {
        public Lesson()
        {
            this.JoinLessonLecturers = new HashSet<JoinLessonLecturer>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public int time { get; set; }
        public string type { get; set; }
    
        public virtual ICollection<JoinLessonLecturer> JoinLessonLecturers { get; set; }
    }
}
