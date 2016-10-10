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
        public DbSet<Student> Students { get; set; }
        public DbSet<Raspberrypoop> Raspberrypoops { get; set; }
        public DBModel db { get; set; } = new DBModel();
        public StudentService()
        {
            Students = db.Student;
            Raspberrypoops = db.Raspberrypoop;
        }

        public void InsertData(int lyss, int temps)
        {
            Raspberrypoops.Add(new Raspberrypoop() {lys = lyss, temp = temps});
            db.SaveChanges();
        }

        public void AddStudent(Student student)
        {
            Students.Add(student);
            db.SaveChanges();
        }

        public Student FindStudent(int id)
        {
            return Students.FirstOrDefault(x => x.Id == id);
        }

        public void RemoveStudent(int id)
        {
            try
            {
                Students.Remove(Students.FirstOrDefault(x => x.Id == id));
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
                if (Students.Remove(Students.FirstOrDefault(x => x.Id == id)) != null)
                {
                    Students.Add(student);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
            }
        }

        public List<Student> GetAllStudents()
        {
            return Students.ToList();
        }
    }
}
