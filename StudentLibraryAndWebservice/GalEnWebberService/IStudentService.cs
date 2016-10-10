using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GalEnWebberService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IStudentService
    {
        [OperationContract]
        void InsertData(int lyss, int temps);



        [OperationContract]
        void AddStudent(Student student);
        [OperationContract]
        Student FindStudent(int id);
        [OperationContract]
        void RemoveStudent(int id);
        [OperationContract]
        void EditStudent(int id, Student student);
        [OperationContract]
        List<Student> GetAllStudents();
    }
    
}
