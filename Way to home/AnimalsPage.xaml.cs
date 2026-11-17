namespace Way_to_home
{
    public partial class AnimalsPage : ContentPage
    {
        public AnimalsPage()
        {
            InitializeComponent();
            PetsCollectionView.ItemsSource = PetData.Pets;
        }

        // Переход на фильтры
        private async void OnFiltersClicked(object sender, TappedEventArgs e)
        {
            await Navigation.PushAsync(new FiltersPage());
        }

        // Переход в анкету животного
        private async void OnPetTapped(object sender, TappedEventArgs e)
        {
            var border = sender as Border;
            var selectedPet = border?.BindingContext as Pet;

            if (selectedPet != null)
            {
                await Navigation.PushAsync(new PetDetailsPage(selectedPet));
            }
        }

        // Стрелочка "Назад" (возвращает на Главный экран)
        private async void OnBackClicked(object sender, TappedEventArgs e)
        {
            await Navigation.PopAsync();
        }

        // Нижняя кнопка "Памятки"
        private async void OnMemoTabClicked(object sender, TappedEventArgs e)
        {
            // 1. Возвращаемся в самый корень (на Главный экран)
            await Navigation.PopToRootAsync();
            // 2. Сразу же открываем Памятки
            await Navigation.PushAsync(new MainPage());
        }

        // Нижняя кнопка "Как помочь"
        private async void OnHelpTabClicked(object sender, TappedEventArgs e)
        {
            // 1. Возвращаемся в самый корень (на Главный экран)
            await Navigation.PopToRootAsync();
            // 2. Открываем Как помочь
            await Navigation.PushAsync(new HelpPage());
        }
    }
}