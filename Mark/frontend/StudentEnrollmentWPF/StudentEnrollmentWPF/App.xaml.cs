using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using StudentEnrollmentWPF.Core;
using StudentEnrollmentWPF.Factory;
using StudentEnrollmentWPF.MVVM.View;
using StudentEnrollmentWPF.MVVM.ViewModel;
using StudentEnrollmentWPF.MVVM.ViewModel.Course;
using StudentEnrollmentWPF.Services;

namespace StudentEnrollmentWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<MainWindow>(provider => new MainWindow
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            });

            services.AddSingleton<MainViewModel>();
            services.AddSingleton<HomeViewModel>();
            services.AddSingleton<SettingsViewModel>();
            services.AddSingleton<EditCourseViewModel>();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<IStudentEnrollmentAPIService, StudentEnrollmentAPIService>();

            services.AddSingleton<Func<Type, ViewModel>>(serviceProvider =>
                viewModelType => (ViewModel)serviceProvider.GetRequiredService(viewModelType));

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }
    }
}