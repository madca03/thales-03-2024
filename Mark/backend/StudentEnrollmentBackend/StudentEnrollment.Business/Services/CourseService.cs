using StudentEnrollment.Business.Models.DTO;
using StudentEnrollment.Business.Models.SearchModels;
using StudentEnrollment.Business.Repository;
using StudentEnrollment.Business.Services.Interfaces;

namespace StudentEnrollment.Business.Services;

public class CourseService : ICourseService
{
    private readonly StudentEnrollmentContext _context;
    
    public CourseService(StudentEnrollmentContext context)
    {
        _context = context;
    }

    /// <inheritdoc/>
    public List<Course> GetCourses(CourseSearchModel searchModel)
    {
        var query = from c in _context.Courses
            select c;

        if (!string.IsNullOrEmpty(searchModel.Name))
            query = query.Where(c => c.Name.Contains(searchModel.Name));

        if (searchModel.StartDate.HasValue)
            query = query.Where(c => c.StartDate == searchModel.StartDate);

        if (searchModel.EndDate.HasValue)
            query = query.Where(c => c.EndDate == searchModel.EndDate);

        if (searchModel.Limit.HasValue)
            query = query.Take(searchModel.Limit.Value);

        if (searchModel.Offset.HasValue)
            query = query.Skip(searchModel.Offset.Value);
        
        return query.ToList();
    }

    /// <inheritdoc/>
    public Course AddCourse(CourseDTO newCourse)
    {
        var courseToAdd = new Course
        {
            Name = newCourse.Name,
            Description = newCourse.Description,
            StartDate = newCourse.StartDate.Value,
            EndDate = newCourse.EndDate.Value,
            Fees = newCourse.Fees.Value,
            LocationAddress = newCourse.LocationAddress,
            ContactPerson = newCourse.ContactPerson,
            Subjects = new List<Subject>()
        };
        
        _context.Courses.Add(courseToAdd);
        _context.SaveChanges();
        return courseToAdd;
    }

    /// <inheritdoc/>
    public bool DeleteCourse(int courseId)
    {
        var course = _context.Courses.FirstOrDefault(x => x.Id == courseId);
        if (course == null) return false;

        _context.Courses.Remove(course);
        _context.SaveChanges();
        return true;
    }

    /// <inheritdoc/>
    public Course EditCourse(CourseDTO course)
    {
        var courseToUpdate = _context.Courses.FirstOrDefault(x => x.Id == course.Id);
        if (courseToUpdate == null) throw new Exception($"Course with Id: {course.Id} not found");

        if (!string.IsNullOrEmpty(course.Name))
            courseToUpdate.Name = course.Name;

        if (!string.IsNullOrEmpty(course.Description))
            courseToUpdate.Description = course.Description;

        if (course.StartDate.HasValue)
            courseToUpdate.StartDate = course.StartDate.Value;

        if (course.EndDate.HasValue)
            courseToUpdate.EndDate = course.EndDate.Value;

        if (course.Fees.HasValue)
            courseToUpdate.Fees = course.Fees.Value;

        if (!string.IsNullOrEmpty(course.LocationAddress))
            courseToUpdate.LocationAddress = course.LocationAddress;

        if (!string.IsNullOrEmpty(course.ContactPerson))
            courseToUpdate.ContactPerson = course.ContactPerson;

        _context.SaveChanges();
        return courseToUpdate;
    }
}