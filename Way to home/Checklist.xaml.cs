namespace Way_to_home;

public partial class ChecklistPage : ContentPage
{
    public ChecklistPage()
    {
        InitializeComponent();
    }

    // Возврат на страницу Памятки
    private async void OnBackClicked(object sender, TappedEventArgs e)
    {
        await Navigation.PopAsync();
    }

    // Нажатие на кнопку "Завершить"
    private async void OnFinishClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Отлично!", "Вы готовы стать заботливым хозяином!", "ОК");
        // После завершения возвращаемся назад
        await Navigation.PopAsync();
    }
}