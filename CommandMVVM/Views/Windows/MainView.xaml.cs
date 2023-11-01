using CommandMVVM.ViewModels.WindowViewModels;
using System.Windows.Navigation;

namespace CommandMVVM.Views.Windows;

public partial class MainView : NavigationWindow
{
    public MainView()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }
}
