namespace Way_to_home
{
    public partial class HelpPage : ContentPage
    {
        public HelpPage()
        {
            InitializeComponent();
        }

        // Стрелочка "Назад" на Главный экран
        private async void OnBackClicked(object sender, TappedEventArgs e)
        {
            await Navigation.PopAsync();
        }

        // Кнопка "Животные" на нижней панели
        private async void OnAnimalsTabClicked(object sender, TappedEventArgs e)
        {
            await Navigation.PopToRootAsync();
            await Navigation.PushAsync(new AnimalsPage());
        }

        // Кнопка "Памятки" на нижней панели
        private async void OnMemoTabClicked(object sender, TappedEventArgs e)
        {
            await Navigation.PopToRootAsync();
            await Navigation.PushAsync(new MainPage());
        }
    }
}