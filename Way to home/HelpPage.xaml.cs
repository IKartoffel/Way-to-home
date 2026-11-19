namespace Way_to_home;

public partial class HelpPage : ContentPage
{
    public HelpPage()
    {
        InitializeComponent();
    }

    // Переход на страницу пожертвования
    private async void OnNeedClicked(object sender, TappedEventArgs e)
    {
        if (e.Parameter != null)
        {
            string needItem = e.Parameter.ToString();
            // Передаем название нужды (Корм, Лекарства и т.д.) на страницу DonationPage
            await Navigation.PushAsync(new DonationPage(needItem));
        }
    }

    // Возврат назад (на Главную)
    private async void OnBackClicked(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//HomePage");
    }
}