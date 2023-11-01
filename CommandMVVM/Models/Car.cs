using CommandMVVM.Services;
using System.Collections.Specialized;
using System.ComponentModel;

namespace CommandMVVM.Models;

public class Car : NotificationService
{
    private string? make;
    private string? model;
    private string? year;

    public string? Make { get => make; set { make = value; OnPropertyChanged(); } }
    public string? Model { get => model; set { model = value; OnPropertyChanged(); } }
    public string? Year { get => year; set { year = value; OnPropertyChanged(); } }

    public Car()
    {
        Make = "";
        Model = "";
        Year = "";
    }
    public Car(string? make, string? model, string? year)
    {
        Make = make;
        Model = model;
        Year = year;
    }

    public override string ToString() => $"{Make} - {Model} - {Year}";
    
}
