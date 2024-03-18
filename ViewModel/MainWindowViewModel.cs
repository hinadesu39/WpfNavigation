using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace WpfNavigation.ViewModel
{
    public partial class MainWindowViewModel : BaseViewModel
    {
        private readonly NavigationService navigationService;

        public MainWindowViewModel() { }

        public MainWindowViewModel(NavigationService navigationService)
        {
            this.navigationService = navigationService;
            Views = new ObservableCollection<string> { "ViewA", "ViewB", "ViewC" };

            navigationService.CurrentViewModelChanged += () =>
            {
                CurrentViewModel = navigationService.CurrentViewModel;
            };
        }

        [ObservableProperty]
        BaseViewModel currentViewModel;

        [ObservableProperty]
        ObservableCollection<string> views;

        [RelayCommand]
        void GoBack()
        {
            if (navigationService.CanNavigateBack())
            {
                navigationService.NavigateBack();
            }
        }

        [RelayCommand]
        void GoForward()
        {
            if (navigationService.CanNavigateForward())
            {
                navigationService.NavigateForward();
            }
        }

        [RelayCommand]
        void NavigateToView(string view)
        {
            switch (view)
            {
                case "ViewA":
                    navigationService.NavigationTo<ViewAViewModel>(
                        new Dictionary<string, object> { ["mes"] = "hello parameter" }
                    );
                    break;
                case "ViewB":
                    navigationService.NavigationTo<ViewBViewModel>();
                    break;
                case "ViewC":
                    navigationService.NavigationTo<ViewCViewModel>();
                    break;
            }
        }
    }
}
