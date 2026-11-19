namespace Way_to_home;

public partial class AdoptionPage : ContentPage
{
    public AdoptionPage(Pet pet)
    {
        InitializeComponent();
        BindingContext = pet;
    }

    private async void OnBackClicked(object sender, TappedEventArgs e)
    {
        await Navigation.PopAsync();
    }
}