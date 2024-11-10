using StudentEnrollmentWPF.MVVM.Model;
using StudentEnrollmentWPF.MVVM.ViewModel.Course;
using StudentEnrollmentWPF.Services;

namespace StudentEnrollmentWPF.Factory;

public class EditCourseViewModelFactory : IEditCourseViewModelFactory
{
    private readonly INavigationService _navigationService;

    public EditCourseViewModelFactory(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    public EditCourseViewModel Create(Course course)
    {
        return new EditCourseViewModel(_navigationService, course);
    }
}