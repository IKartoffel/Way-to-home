namespace Way_to_home
{
    public partial class PetDetailsPage : ContentPage
    {
        // Сохраняем животное, чтобы передать его дальше
        private Pet _currentPet;

        public PetDetailsPage(Pet pet)
        {
            InitializeComponent();
            _currentPet = pet;
            BindingContext = pet; // Привязываем данные для отображения
        }

        // Стрелочка "Назад"
        private async void OnBackClicked(object sender, TappedEventArgs e)
        {
            await Navigation.PopAsync();
        }

        // Нажатие на "Хочу познакомиться"
        private async void OnAdoptClicked(object sender, EventArgs e)
        {
            try
            {
                // Переходим на страницу знакомства, передавая объект Pet
                await Navigation.PushAsync(new AdoptionPage(_currentPet));
            }
            catch (Exception ex)
            {
                // Если страница AdoptionPage не создана, выскочит ошибка
                await DisplayAlert("Ошибка", "Страница AdoptionPage не найдена: " + ex.Message, "ОК");
            }
        }

        // Нажатие на "Сначала прочитать памятку"
        private async void OnMemoClicked(object sender, EventArgs e)
        {
            // Переключаемся на вкладку Памятки и передаем параметр fromPet=true
            await Shell.Current.GoToAsync("//MemoPage?fromPet=true");
        }
    }
}