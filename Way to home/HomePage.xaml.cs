namespace Way_to_home;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
    }

    // Переход на вкладку "Животные" (сработает при нажатии на кнопки "Смотреть животных" и "Найти питомца")
    private async void OnViewAnimalsClicked(object sender, TappedEventArgs e)
    {
        // Переключаемся на вкладку с животными
        await Shell.Current.GoToAsync("//AnimalsPage");
    }

    // Переход на вкладку "Памятки"
    private async void OnMemoClicked(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//MemoPage");
    }

    // Переход на вкладку "Как помочь"
    private async void OnHelpClicked(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//HelpPage");
    }
}