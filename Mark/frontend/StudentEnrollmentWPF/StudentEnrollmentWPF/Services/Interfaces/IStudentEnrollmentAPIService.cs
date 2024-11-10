using System.Collections.Generic;
using System.Threading.Tasks;
using StudentEnrollmentWPF.MVVM.Model;

namespace StudentEnrollmentWPF.Services;

public interface IStudentEnrollmentAPIService
{
    Task<List<Course>> GetCourses();
    Task<bool> DeleteCourse(int id);
}