using StudentEnrollment.Business.Models.SearchModels;
using StudentEnrollment.Business.Repository;
using StudentEnrollment.Business.Services.Interfaces;

namespace StudentEnrollment.Business.Services;

public class StudentService : IStudentService
{
    private readonly StudentEnrollmentContext _context;
    
    public StudentService(StudentEnrollmentContext context)
    {
        _context = context;
    }

    /// <inheritdoc/>
    public List<Student> GetStudents(StudentSearchModel searchModel)
    {
        var query = from s in _context.Students
            select s;

        if (searchModel.Limit.HasValue)
            query = query.Take(searchModel.Limit.Value);

        if (searchModel.Offset.HasValue)
            query = query.Skip(searchModel.Offset.Value);
        
        return query.ToList();
    }
}