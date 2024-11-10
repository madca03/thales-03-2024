using StudentEnrollment.Business.Models.DTO;
using StudentEnrollment.Business.Models.SearchModels;
using StudentEnrollment.Business.Repository;

namespace StudentEnrollment.Business.Services.Interfaces;

public interface ICourseService
{
    /// <summary>
    /// Gets a list of courses based on search parameters.
    /// </summary>
    /// <param name="searchModel">Search parameters.</param>
    /// <returns>List of courses.</returns>
    List<Course> GetCourses(CourseSearchModel searchModel);
    
    /// <summary>
    /// Adds a course.
    /// </summary>
    /// <param name="newCourse">Course record to add.</param>
    /// <returns>Inserted course record.</returns>
    Course AddCourse(CourseDTO newCourse);

    /// <summary>
    /// Deletes a course by id.
    /// </summary>
    /// <param name="courseId">Course Id.</param>
    /// <returns>Success status.</returns>
    bool DeleteCourse(int courseId);

    /// <summary>
    /// Updates a course record.
    /// </summary>
    /// <param name="course">Updated details for a course record.</param>
    /// <returns>Update course record.</returns>
    Course EditCourse(CourseDTO course);
}