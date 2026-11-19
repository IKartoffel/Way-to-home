namespace Way_to_home;

// Атрибут QueryProperty позволяет странице принимать данные из ссылки
[QueryProperty(nameof(FromPet), "fromPet")]
public partial class MemoPage : ContentPage
{
    // Свойство для хранения параметра
    public string FromPet { get; set; }

    public MemoPage()
    {
        InitializeComponent();
    }
    private async void OnChecklistClicked(object sender, EventArgs e)
    {
        // Открываем страницу чек-листа
        await Navigation.PushAsync(new ChecklistPage());
    }

    // Стрелочка "Назад" вверху страницы
    private async void OnBackClicked(object sender, TappedEventArgs e)
    {
        if (FromPet == "true")
        {
            // Если мы пришли из анкеты животного, возвращаемся на вкладку Животные
            await Shell.Current.GoToAsync("//AnimalsPage");

            // Очищаем параметр, чтобы при следующем нажатии на вкладку Памятки из меню
            // кнопка Назад вела уже на Главную
            FromPet = null;
        }
        else
        {
            // Если мы просто открыли Памятки из нижнего меню, идем на Главную
            await Shell.Current.GoToAsync("//HomePage");
        }
    }
}