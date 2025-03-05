﻿using InfoManager.ViewModel;
using InfoManager.Service;
using InfoManager.Interface;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using InfoManager.Services;
using InfoManager.Models;
using InfoManager.View;


namespace InfoManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Services = ConfigureServices();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = Current.Services.GetService<MainWindow>();
            mainWindow?.Show();
        }
        public new static App Current => (App)Application.Current;
        public IServiceProvider Services { get; }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            //view principal
            services.AddSingleton<MainWindow>();


            //view viewModels
            services.AddSingleton<MainViewModel>();
            services.AddTransient<DashboardViewModel>();
            services.AddTransient<LoginViewModel>();
            services.AddTransient<RegistroViewModel>();
            services.AddTransient<ViewModelBase>();
      


            //Services
            services.AddSingleton<LoginDTO>();   
            services.AddSingleton<IProyectoServiceToApi, ProyectoServiceToApi>();
            services.AddSingleton(typeof(IHttpJsonProvider<>), typeof(HttpJsonService<>));
            return services.BuildServiceProvider();
        }
    }
}


