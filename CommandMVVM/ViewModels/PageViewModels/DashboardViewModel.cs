using CommandMVVM.Commands;
using CommandMVVM.Models;
using CommandMVVM.Services;
using CommandMVVM.Views.Windows;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Channels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace CommandMVVM.ViewModels.PageViewModels;

public class DashboardViewModel : NotificationService
{
    private Car? car1;
    public Car? car { get => car1; set { car1 = value; OnPropertyChanged(); } }

    public ObservableCollection<Car> Cars { get; set; }

    #region All Commands

    public ICommand AddCommand{ get; set; }
    public ICommand GetAllCommand{ get; set; }
    public ICommand EditCommand{ get; set; }
    public ICommand SaveCommand { get; set; }
    public ICommand CancelCommand { get; set; }
    public ICommand RemoveCommand { get; set; }
    #endregion
    public DashboardViewModel()
    {
        Cars = new ObservableCollection<Car>()
        {
            new("Kia", "Optima", "2012"),
            new("Hyundai", "Elantra", "2014"),
            new("Audi", "Q7", "2023"),
        };

        car = new();


        AddCommand = new RelayCommand(AddCar, CanAddCar);
        GetAllCommand = new RelayCommand(GetAllCars, CanAllCars);
        EditCommand = new RelayCommand(Edit, CanEdit);
        SaveCommand = new RelayCommand(Save, CanSave);
        CancelCommand = new RelayCommand(Cancel);
        RemoveCommand = new RelayCommand(Remove,CanRemove);
    }

    #region Remove

    public void Remove(object? paramter)
    {
        Cars.RemoveAt((int)paramter);
    }

    public bool CanRemove(object? parameter)
    {
        return (int?)parameter != -1;
    }
    #endregion
    #region Cancel

    public void Cancel(object? paramter)
    {
        (paramter as Window)?.Close();
    }
    #endregion
    #region Save

    public void Save(object? paramter)
    {
        Cars.RemoveAt((int)paramter);
        Cars.Insert((int)paramter, car);

    }
    
    public bool CanSave(object? parameter)
    {
        return !string.IsNullOrEmpty(car?.Make) &&
           !string.IsNullOrEmpty(car?.Model) &&
           !string.IsNullOrEmpty(car?.Year);
    }
    #endregion
    #region GetAllCars

    public void GetAllCars(object? parameter)
    {
        var getAllView = new AllCarView();
        getAllView.DataContext = new GetAllCarViewModel(Cars);
        getAllView.ShowDialog();
    }
    public bool CanAllCars(object? parameter)
    {
        return Cars.Count >= 5;
    }
    #endregion
    #region Edit
    public void Edit(object? paramter)
    {
        car = Cars[(int)paramter];
        EditView? editView = new EditView();
        editView.btn_save.CommandParameter = paramter;
        editView!.DataContext = this;/*new EditViewModel(Cars,(int)paramter,ref editView);*/
        editView.ShowDialog();
    }
    public bool CanEdit(object? parameter)
    {
        var param = (int?)parameter;
        return param != -1;
    }

    #endregion
    #region Add
    public void AddCar(object? parameter)
    {
        Cars.Add(car!);
        car = new();

    }

    public bool CanAddCar(object? parameter)
    {
        return !string.IsNullOrEmpty(car?.Make) &&
               !string.IsNullOrEmpty(car?.Model) &&
               !string.IsNullOrEmpty(car?.Year);
    }
    #endregion
}
