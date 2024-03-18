using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfNavigation.ViewModel
{
    public class BaseViewModel : ObservableObject
    {
        public virtual void OnNavigationTo(Dictionary<string, object>? parameters)
        {

        }

        public virtual void OnNavigationFrom()
        {

        }
    }
}
