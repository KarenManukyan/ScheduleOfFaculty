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
    
    public partial class login
    {
        public int id { get; set; }
        public string login1 { get; set; }
        public string password { get; set; }
        public int lecturerId { get; set; }
    
        public virtual lecturer lecturer { get; set; }
    }
}
