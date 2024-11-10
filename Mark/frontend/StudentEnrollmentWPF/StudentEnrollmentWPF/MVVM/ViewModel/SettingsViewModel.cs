﻿using StudentEnrollmentWPF.Core;
using StudentEnrollmentWPF.Services;

namespace StudentEnrollmentWPF.MVVM.ViewModel;

public class SettingsViewModel : Core.ViewModel
{
    private INavigationService _navigation;

    public INavigationService Navigation
    {
        get => _navigation;
        set
        {
            _navigation = value;
            OnPropertyChanged();
        }
    }

    public RelayCommand NavigateToHomeCommand { get; set; }

    public SettingsViewModel(INavigationService navService)
    {
        Navigation = navService;
        NavigateToHomeCommand = new RelayCommand(o => { Navigation.NavigateTo<HomeViewModel>(); }, o => true);
    }
}