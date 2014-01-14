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
    
    public partial class lecturer
    {
        public lecturer()
        {
            this.lecturerProfessions = new HashSet<lecturerProfession>();
            this.lessonForLecturers = new HashSet<lessonForLecturer>();
            this.logins = new HashSet<login>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public System.DateTime birthday { get; set; }
        public int qualificationId { get; set; }
        public int role { get; set; }
    
        public virtual ICollection<lecturerProfession> lecturerProfessions { get; set; }
        public virtual ICollection<lessonForLecturer> lessonForLecturers { get; set; }
        public virtual qualification qualification { get; set; }
        public virtual ICollection<login> logins { get; set; }
    }
}