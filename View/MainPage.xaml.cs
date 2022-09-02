using MauiApp1.ViewModel;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new СomputerСomponentViewModel();
    }

}

