using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfNavigation.ViewModel
{
    internal partial class ViewBViewModel : BaseViewModel
    {
        [ObservableProperty]
        string message = "Im B";
    }
}
