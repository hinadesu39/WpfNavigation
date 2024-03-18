using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfNavigation.ViewModel
{
    internal partial class ViewAViewModel : BaseViewModel
    {
        [ObservableProperty]
        string message = "Im A";

        public override void OnNavigationTo(Dictionary<string, object> parameters)
        {
            base.OnNavigationTo(parameters);

            if (parameters != null && parameters.ContainsKey("mes"))
            {
                Message = $"I am A and {parameters["mes"]}";
            }
        }
    }
}
