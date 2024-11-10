using System;
using StudentEnrollmentWPF.Core;
using StudentEnrollmentWPF.Factory;
using StudentEnrollmentWPF.MVVM.Model;

namespace StudentEnrollmentWPF.Services;

public class NavigationService : ObservableObject, INavigationService
{
    private readonly Func<Type, ViewModel> _viewModelFactory;
    private ViewModel _currentView;

    public ViewModel CurrentView
    {
        get => _currentView;
        private set
        {
            _currentView = value;
            OnPropertyChanged();
        }
    }

    public NavigationService(Func<Type, ViewModel> viewModelFactory)
    {
        _viewModelFactory = viewModelFactory;
    }
    
    public void NavigateTo<TViewModel>() where TViewModel : ViewModel
    {
        ViewModel viewModel = _viewModelFactory.Invoke(typeof(TViewModel));
        CurrentView = viewModel;
    }

    public void NavigateTo<TViewModel>(Course course = null) where TViewModel : ViewModel
    {
        // Example: Pass the course data to the target ViewModel
        ViewModel viewModel = Activator.CreateInstance(typeof(TViewModel), course) as TViewModel;
        CurrentView = viewModel;
    }
    
    /*
    public void NavigateToEditCourse(Course course = null)
    {
        ViewModel viewModel = _editCourseViewModelFactory.Create(course);
        CurrentView = viewModel;
    }
    */
}