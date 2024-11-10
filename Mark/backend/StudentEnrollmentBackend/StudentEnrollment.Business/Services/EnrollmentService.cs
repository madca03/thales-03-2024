using StudentEnrollment.Business.Models.DTO;
using StudentEnrollment.Business.Models.SearchModels;
using StudentEnrollment.Business.Repository;
using StudentEnrollment.Business.Services.Interfaces;
using StudentEnrollment.Common.Constants;

namespace StudentEnrollment.Business.Services;

public class EnrollmentService : IEnrollmentService
{
    private readonly StudentEnrollmentContext _context;
    
    public EnrollmentService(StudentEnrollmentContext context)
    {
        _context = context;
    }
    
    /// <inheritdoc/>
    public List<EnrollmentDTO> GetEnrollments(EnrollmentSearchModel searchModel)
    {
        var query = from e in _context.Enrollments
            join s in _context.Students on e.StudentId equals s.Id
            join c in _context.Courses on e.CourseId equals c.Id
            select new
            {
                Id = e.Id,
                Student = s,
                Course = c,
                EnrollmentDate = e.EnrollmentDate,
                Status = e.Status,
                Comments = e.Comments
            };

        if (!string.IsNullOrEmpty(searchModel.CourseName))
            query = query.Where(x => x.Course.Name.Contains(searchModel.CourseName));

        if (!string.IsNullOrEmpty(searchModel.StudentName))
            query = query.Where(x => x.Student.Name.Contains(searchModel.StudentName));

        if (searchModel.EnrollmentDate.HasValue)
            query = query.Where(x => x.EnrollmentDate == searchModel.EnrollmentDate);

        if (searchModel.Limit.HasValue)
            query = query.Take(searchModel.Limit.Value);
        
        if (searchModel.Offset.HasValue)
            query = query.Skip(searchModel.Offset.Value);

        var res = query.Select(x => new EnrollmentDTO
        {
            Id = x.Id,
            CourseName = x.Course.Name,
            StudentName = x.Student.Name,
            EnrollmentDate = x.EnrollmentDate,
            Status = x.Status,
            Comments = x.Comments
        });

        return res.ToList();
    }

    /// <inheritdoc/>
    public bool UpdateEnrollmentStatus(int enrollmentId, string status)
    {
        var recordToUpdate = _context.Enrollments.FirstOrDefault(x => x.Id == enrollmentId);
        if (recordToUpdate == null) throw new Exception($"Enrollment record not found for id: ${enrollmentId}");

        recordToUpdate.Status = status;
        
        _context.SaveChanges();
        return true;
    }

    /// <inheritdoc/>
    public List<RegisterEnrollmentDTO> RegisterEnrollment(List<RegisterEnrollmentDTO> enrollments)
    {
        var studentIds = new HashSet<int>(enrollments.Select(x => x.StudentId));
        var courseIds = new HashSet<int>(enrollments.Select(x => x.CourseId));
        var students = _context.Students.Where(x => studentIds.Contains(x.Id)).ToList();
        var course = _context.Courses.Where(x => courseIds.Contains(x.Id)).ToList();

        List<Enrollment> newRecords = new List<Enrollment>();

        foreach (var enrollment in enrollments)
        {
            if (!students.Any(x => x.Id == enrollment.StudentId) ||
                !course.Any(x => x.Id == enrollment.CourseId)) continue;
            
            newRecords.Add(new Enrollment
            {
                StudentId = enrollment.StudentId,
                CourseId = enrollment.CourseId,
                EnrollmentDate = DateTime.Now,
                Status = EnrollmentStatus.PENDING,
                Comments = enrollment.Comments
            });
        }
        
        _context.Enrollments.AddRange(newRecords);
        _context.SaveChanges();
        return newRecords.Select(x => new RegisterEnrollmentDTO { CourseId = x.CourseId, StudentId = x.StudentId })
            .ToList();
    }
}