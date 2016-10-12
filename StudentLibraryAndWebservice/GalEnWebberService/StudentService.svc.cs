using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GalEnWebberService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class StudentService : IStudentService
    {
        public DbModel db { get; set; } = new DbModel();

        public void InsertData(Raspberrypoop rasp)
        {
            db.Raspberrypoops.Add(rasp);
            db.SaveChanges();
        }

        public void AddStudent(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
        }

        public Student FindStudent(int id)
        {
            return db.Students.FirstOrDefault(x => x.Id == id);
        }

        public void RemoveStudent(int id)
        {
            try
            {
                db.Students.Remove(db.Students.FirstOrDefault(x => x.Id == id));
                db.SaveChanges();
            }
            catch (Exception)
            {
            }
        }

        public void EditStudent(int id, Student student)
        {
            try
            {
                if (db.Students.Remove(db.Students.FirstOrDefault(x => x.Id == id)) != null)
                {
                    db.Students.Add(student);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
            }
        }

        public List<Student> GetAllStudents()
        {
            return db.Students.ToList();
        }
    }
}
