using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using StudentEnrollmentWPF.MVVM.Model;
using StudentEnrollmentWPF.MVVM.ViewModel;

namespace StudentEnrollmentWPF.MVVM.View;

public partial class HomeView : UserControl
{
    public HomeView()
    {
        InitializeComponent();
        this.Loaded += HomeView_Loaded;
    }

    private async void HomeView_Loaded(object sender, RoutedEventArgs e)
    {
        if (this.DataContext is HomeViewModel viewModel)
        {
            await viewModel.GetCourses();
        }
    }
}