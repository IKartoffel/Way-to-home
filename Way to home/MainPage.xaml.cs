namespace Way_to_home
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnBackClicked(object sender, TappedEventArgs e)
        {
            await Navigation.PopAsync(); // Возврат на Главный экран
        }

        // Кнопка "Животные" на нижней панели
        private async void OnAnimalsTabClicked(object sender, TappedEventArgs e)
        {
            await Navigation.PopToRootAsync();
            await Navigation.PushAsync(new AnimalsPage());
        }

        // Кнопка "Как помочь" на нижней панели
        private async void OnHelpTabClicked(object sender, TappedEventArgs e)
        {
            await Navigation.PopToRootAsync();
            await Navigation.PushAsync(new HelpPage());
        }
    }
}