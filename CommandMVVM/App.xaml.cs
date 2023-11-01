using CommandMVVM.ViewModels.WindowViewModels;
using CommandMVVM.Views.Windows;
using System.Windows;

namespace CommandMVVM;


public partial class App : Application
{
    private void Main(object sender, StartupEventArgs e)
    {

        // Do WORK
       
        var mainView = new MainView();
        //mainView.DataContext = new MainViewModel();
        mainView.ShowDialog();

    }
}
