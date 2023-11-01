using CommandMVVM.ViewModels.PageViewModels;
using System.Windows;

namespace CommandMVVM.Views.Windows;


public partial class AllCarView : Window
{
    public AllCarView()
    {
        InitializeComponent();
        //DataContext = new GetAllCarViewModel();
    }
}
