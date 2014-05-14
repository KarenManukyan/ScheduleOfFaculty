using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScheduleOfFaculty.Models
{
    public class TypeStore
    {
        private ScheduleForFacultyEntities _db;

        public TypeStore()
        {
            _db = new ScheduleForFacultyEntities();
            _db.Configuration.ProxyCreationEnabled = false;
        }
        public IEnumerable<Type> Read()
        {
            var data = _db.Types.Select(c => c);
            return data;
        }

        public void Create(Type type)
        {
            _db.Types.Add(type);
            _db.SaveChanges();
        }

        public void Update(Type type)
        {

            Type lessonType = _db.Types.Find(type.Id);
            lessonType.Type1 = type.Type1;
            _db.SaveChanges();
        }

        public void Destroy(int id)
        {
            Type type = _db.Types.Find(id);
            _db.Types.Remove(type);
            _db.SaveChanges();
        }

    }
}