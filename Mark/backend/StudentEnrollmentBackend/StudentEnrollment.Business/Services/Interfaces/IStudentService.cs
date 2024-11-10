using StudentEnrollment.Business.Models.SearchModels;
using StudentEnrollment.Business.Repository;

namespace StudentEnrollment.Business.Services.Interfaces;

public interface IStudentService
{
    /// <summary>
    /// Gets list of students.
    /// </summary>
    /// <returns>List of students.</returns>
    List<Student> GetStudents(StudentSearchModel searchModel);
}