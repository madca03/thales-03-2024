using StudentEnrollmentWPF.Core;
using StudentEnrollmentWPF.MVVM.Model;

namespace StudentEnrollmentWPF.Services;

public interface INavigationService
{
    ViewModel CurrentView { get; }
    void NavigateTo<T>() where T: ViewModel;
    void NavigateTo<TViewModel>(Course course = null) where TViewModel : ViewModel;
}