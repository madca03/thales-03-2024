using StudentEnrollmentWPF.Core;
using StudentEnrollmentWPF.Services;

namespace StudentEnrollmentWPF.MVVM.ViewModel.Course;

public class EditCourseViewModel : Core.ViewModel
{
    private INavigationService _navigation;
    public Model.Course Course { get; set; }
    
    public INavigationService Navigation
    {
        get => _navigation;
        set
        {
            _navigation = value;
            OnPropertyChanged();
        }
    }

    public RelayCommand NavigateToCourseDashboardCommand { get; set; }

    public EditCourseViewModel(INavigationService navService, Model.Course course)
    {
        Course = course;
        Navigation = navService;
        NavigateToCourseDashboardCommand = new RelayCommand(o => { Navigation.NavigateTo<HomeViewModel>(); }, o => true);
    }
}