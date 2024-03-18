using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;
using WpfNavigation.ViewModel;

namespace WpfNavigation
{
    public class NavigationService
    {
        private Stack<BaseViewModel> history = new Stack<BaseViewModel>();
        private Stack<BaseViewModel> forwardHistory = new Stack<BaseViewModel>();

        private BaseViewModel currentViewModel;

        public BaseViewModel CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                currentViewModel?.OnNavigationFrom();
                currentViewModel = value;
                CurrentViewModelChanged.Invoke();
            }
        }

        public event Action CurrentViewModelChanged;

        public void NavigationTo<T>(Dictionary<string, object> parameters = default)
            where T : BaseViewModel
        {
            CurrentViewModel = App.Current.Services.GetService<T>();
            history.Push(CurrentViewModel);
            if (CurrentViewModel != null)
                CurrentViewModel!.OnNavigationTo(parameters);
            forwardHistory.Clear();
        }

        public bool CanNavigateBack() => history.Count > 0;

        public bool CanNavigateForward() => forwardHistory.Count > 0;

        public void NavigateBack()
        {
            if (history.Count > 1)
            {
                forwardHistory.Push(CurrentViewModel);
                history.Pop();
                CurrentViewModel = history.First();
            }
        }

        public void NavigateForward()
        {
            if (forwardHistory.Count > 0)
            {
                CurrentViewModel = forwardHistory.First();
                history.Push(CurrentViewModel);
                forwardHistory.Pop();
            }
        }
    }
}
