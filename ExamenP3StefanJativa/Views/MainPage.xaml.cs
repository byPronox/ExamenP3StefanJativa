using ExamenP3StefanJativa.ViewModels;

namespace ExamenP3StefanJativa.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new BuscadorViewModel();
        }
    }

}
