using StudentEnrollmentWPF.MVVM.Model;
using StudentEnrollmentWPF.MVVM.ViewModel.Course;

namespace StudentEnrollmentWPF.Factory;

public interface IEditCourseViewModelFactory
{
    EditCourseViewModel Create(Course course);
}