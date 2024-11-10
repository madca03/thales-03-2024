using StudentEnrollment.Business.Models.DTO;
using StudentEnrollment.Business.Models.SearchModels;

namespace StudentEnrollment.Business.Services.Interfaces;

public interface IEnrollmentService
{
    /// <summary>
    /// Gets list of enrollments.
    /// </summary>
    /// <param name="searchModel">Search parameters.</param>
    /// <returns></returns>
    List<EnrollmentDTO> GetEnrollments(EnrollmentSearchModel searchModel);
    
    /// <summary>
    /// Updates enrollment status.
    /// </summary>
    /// <param name="enrollmentId">Enrollment Id.</param>
    /// <param name="status">Status.</param>
    /// <returns>Success status.</returns>
    bool UpdateEnrollmentStatus(int enrollmentId, string status);

    /// <summary>
    /// Register enrollment.
    /// </summary>
    /// <returns></returns>
    List<RegisterEnrollmentDTO> RegisterEnrollment(List<RegisterEnrollmentDTO> enrollments);
}