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
    
    public partial class JoinLessonLecturer
    {
        public int Id { get; set; }
        public int lecturerId { get; set; }
        public int lessonId { get; set; }
        public int typeId { get; set; }
        public int Time { get; set; }
    
        public virtual Lecturer Lecturer { get; set; }
        public virtual Lesson Lesson { get; set; }
        public virtual Type Type { get; set; }
    }
}
