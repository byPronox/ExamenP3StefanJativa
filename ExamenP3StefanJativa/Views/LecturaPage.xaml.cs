using ExamenP3StefanJativa.ViewModels;

namespace ExamenP3StefanJativa.Views;

public partial class LecturaPage : ContentPage
{
    private LecturaViewModel _viewModel;

    public LecturaPage()
    {
        InitializeComponent();

        
        _viewModel = new LecturaViewModel();
        BindingContext = _viewModel;
    }


    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.ActualizarPeliculas();
    }
}