using CommandMVVM.Models;
using CommandMVVM.Services;
using System.Collections.ObjectModel;


namespace CommandMVVM.ViewModels.PageViewModels;

public class GetAllCarViewModel : NotificationService
{

    public ObservableCollection<Car> Cars { get; set; }

    public GetAllCarViewModel()
    {
        Cars = new();
    }

    public GetAllCarViewModel(ObservableCollection<Car> Cars)
    {
        this.Cars = Cars;
    }

}
