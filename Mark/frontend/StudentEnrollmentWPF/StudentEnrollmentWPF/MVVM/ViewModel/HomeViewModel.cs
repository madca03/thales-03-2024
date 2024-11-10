using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using StudentEnrollmentWPF.Core;
using StudentEnrollmentWPF.MVVM.ViewModel.Course;
using StudentEnrollmentWPF.Services;

namespace StudentEnrollmentWPF.MVVM.ViewModel;

public class HomeViewModel : Core.ViewModel
{
    private readonly IStudentEnrollmentAPIService _studentEnrollmentAPIService;
    private INavigationService _navigation;
    public ObservableCollection<Model.Course> Courses { get; set; }

    public INavigationService Navigation
    {
        get => _navigation;
        set
        {
            _navigation = value;
            OnPropertyChanged();
        }
    }

    public RelayCommand NavigateToSettingsViewCommand { get; set; }
    //public RelayCommand<Model.Course> NavigateToEditCourseViewCommand { get; set; }
    public RelayCommand EditCommand { get; set; }
    public RelayCommand DeleteCommand { get; set; }

    public HomeViewModel(INavigationService navService,
        IStudentEnrollmentAPIService studentEnrollmentApiService)
    {
        Courses = new ObservableCollection<Model.Course>();
        Navigation = navService;
        NavigateToSettingsViewCommand = new RelayCommand(o => { Navigation.NavigateTo<SettingsViewModel>(); }, o => true);
        //NavigateToEditCourseViewCommand = new RelayCommand<Model.Course>(course => { Navigation.NavigateTo<EditCourseViewModel>(course); }, o => true);
        EditCommand = new RelayCommand(ExecuteEdit);
        DeleteCommand = new RelayCommand(ExecuteDelete);
        _studentEnrollmentAPIService = studentEnrollmentApiService;
    }

    public async Task GetCourses()
    {
        var courses = await _studentEnrollmentAPIService.GetCourses();
        Courses.Clear();
        foreach (var course in courses)
        {
            Courses.Add(course);
        }
    }

    private void ExecuteEdit(object parameter)
    {
        var item = parameter as Model.Course;
    }

    private async void ExecuteDelete(object parameter)
    {
        var item = parameter as Model.Course;
        if (item == null) throw new Exception("Invalid course record for deletion.");
        bool deleted = await _studentEnrollmentAPIService.DeleteCourse(item.Id);

        if (deleted)
        {
            var courseToRemove = Courses.FirstOrDefault(x => x.Id == item.Id);
            Courses.Remove(courseToRemove);
        }
    }
}