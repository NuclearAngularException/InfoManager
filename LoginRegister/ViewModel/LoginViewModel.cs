﻿using CommunityToolkit.Mvvm.Input;
using InfoManager.Interface;
using InfoManager.Models;
using InfoManager.Helpers;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection.Metadata;

namespace InfoManager.ViewModel
{
    public partial class LoginViewModel : ViewModelBase
    {
        private readonly IHttpJsonProvider<UserDTO> _httpJsonProvider;
        private readonly IProyectoServiceToApi _proyectoServiceToApi;

       

        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private string _passwordView;

        public LoginViewModel(IHttpJsonProvider<UserDTO> httpJsonProvider, IProyectoServiceToApi proyectoServiceToApi)
        {
            _httpJsonProvider = httpJsonProvider;
            _proyectoServiceToApi = proyectoServiceToApi;
       
        }

        [RelayCommand]
        public async Task Login()
        {

            App.Current.Services.GetService<LoginDTO>().Email = Name;
            App.Current.Services.GetService<LoginDTO>().Password = PasswordView;
            

            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(PasswordView))
            {
                MessageBox.Show("Por favor, rellene ambos campos.", "Error de Inicio de Sesión", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
               
                UserDTO user = await _httpJsonProvider.LoginPostAsync(Constants.LOGIN_PATH, App.Current.Services.GetService<LoginDTO>());

                if (user != null && user.IsSuccess)
                {
                    App.Current.Services.GetService<MainViewModel>().SelectedViewModel = App.Current.Services.GetService<MainViewModel>().DashboardViewModel;
                    App.Current.Services.GetService<MainViewModel>().LoadAsync();
                    Name = string.Empty;
                    PasswordView = String.Empty;
                 
                }
                else
                {
                  
                    MessageBox.Show("Credenciales incorrectas. Intente de nuevo.", "Error de Inicio de Sesión", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show($"Ocurrió un error durante el inicio de sesión: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        [RelayCommand]
        private async void Register()
        {

            var mainWindow = App.Current.Services.GetService<MainViewModel>();
            mainWindow.SelectedViewModel = App.Current.Services.GetService<MainViewModel>().RegistroViewModel;
        }
    }
}

