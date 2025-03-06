using CommunityToolkit.Mvvm.Input;


namespace InfoManager.ViewModel;

public partial class MainViewModel : ViewModelBase 
{
       private ViewModelBase? _selectedViewModel;

        public MainViewModel(DashboardViewModel dashboardViewModel, LoginViewModel loginViewModel, RegistroViewModel registroViewModel)
        {
            DashboardViewModel = dashboardViewModel;
            LoginViewModel = loginViewModel;
            RegistroViewModel = registroViewModel;
            _selectedViewModel = loginViewModel;
        }

        public ViewModelBase? SelectedViewModel
        {
            get => _selectedViewModel;
            set => SetProperty(ref _selectedViewModel, value);
        }

        public DashboardViewModel DashboardViewModel { get; }
        public LoginViewModel LoginViewModel { get; }
        public RegistroViewModel RegistroViewModel { get; }
 

        public override async Task LoadAsync()
        {
            if (SelectedViewModel is not null)
            {
                await SelectedViewModel.LoadAsync();
            }
        }

        [RelayCommand]
        private async Task SelectViewModelAsync(object? parameter)
        {
            if (parameter is ViewModelBase viewModel)
            {
                SelectedViewModel = viewModel;
                await LoadAsync();
            }
        }
}
 

   

