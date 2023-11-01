using CommandMVVM.ViewModels.PageViewModels;
using System.Windows.Controls;

namespace CommandMVVM.Views.Pages;

public partial class DashboardPage : Page
{
    public DashboardPage()
    {
        InitializeComponent();
        DataContext = new DashboardViewModel();
    }
}
