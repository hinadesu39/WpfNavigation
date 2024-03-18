using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfNavigation.ViewModel
{
    internal partial class ViewCViewModel : BaseViewModel
    {
        public ViewCViewModel(NavigationService navigationService) { }

        [ObservableProperty]
        string message = "Im C";
    }
}
