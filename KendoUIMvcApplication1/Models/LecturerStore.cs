using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScheduleOfFaculty.Models;

namespace ScheduleOfFaculty.Models
{
    public class LecturerStore
    {
        private ScheduleForFacultyEntities _db;

        public LecturerStore()
        {
            _db = new ScheduleForFacultyEntities();
            _db.Configuration.ProxyCreationEnabled = false;
        }
        public IEnumerable<Lecturer> Read()
        {
            var data = _db.Lecturers.Select(c => c);
            return data;
        }

        public void Create(Lecturer lect)
        {
            _db.Lecturers.Add(lect);
            _db.SaveChanges();
        }

        public void Update(Lecturer updatedlect)
        {

            Lecturer lect = _db.Lecturers.Find(updatedlect.Id);
            lect.Name = updatedlect.Name;
            lect.Qualification = updatedlect.Qualification;
            _db.SaveChanges();
        }

        public void Destroy(int id)
        {
            Lecturer lect = _db.Lecturers.Find(id);
            _db.Lecturers.Remove(lect);
            _db.SaveChanges();
        }
    }
}