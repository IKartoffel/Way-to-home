using Way_to_home.ViewModels; // Добавляем пространство имен для ViewModel

namespace Way_to_home
{
    public partial class AnimalsPage : ContentPage
    {
        public AnimalsViewModel ViewModel { get; set; }

        public AnimalsPage()
        {
            InitializeComponent();

            // 1. Убираем строку: PetsCollectionView.ItemsSource = PetData.Pets;

            ViewModel = new AnimalsViewModel();
            BindingContext = ViewModel;
        }

        // Переход на фильтры
        private async void OnFiltersClicked(object sender, TappedEventArgs e)
        {
            // Передаем нашу ViewModel на страницу фильтров!
            await Navigation.PushAsync(new FiltersPage(ViewModel));
        }

        // Переход в анкету животного (оставляем без изменений)
        private async void OnPetTapped(object sender, TappedEventArgs e)
        {
            var border = sender as Border;
            var selectedPet = border?.BindingContext as Pet;

            if (selectedPet != null)
            {
                await Navigation.PushAsync(new PetDetailsPage(selectedPet));
            }
        }

        // Стрелочка "Назад"
        private async void OnBackClicked(object sender, TappedEventArgs e)
        {
            await Navigation.PopAsync();
        }

        // Нижняя кнопка "Памятки"
        private async void OnMemoTabClicked(object sender, TappedEventArgs e)
        {
            await Navigation.PopToRootAsync();
            await Navigation.PushAsync(new MainPage());
        }

        // Нижняя кнопка "Как помочь"
        private async void OnHelpTabClicked(object sender, TappedEventArgs e)
        {
            await Navigation.PopToRootAsync();
            await Navigation.PushAsync(new HelpPage());
        }
    }
}