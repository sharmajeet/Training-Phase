using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Shared.Models;

namespace Blazor.Shared.Services
{
    public interface IStudentServices
    {
        public IEnumerable<StudentEntity> AllStudent { get; }

        public void AddStudent(StudentEntity student);
        public void UpdateStudent(StudentEntity student);
        public void DeleteStudent(int? StudentID);
    }
}
