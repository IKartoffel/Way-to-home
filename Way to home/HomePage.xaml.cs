namespace Way_to_home
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        // Переход на список животных
        private async void OnViewAnimalsClicked(object sender, TappedEventArgs e)
        {
            await Navigation.PushAsync(new AnimalsPage());
        }

        // Переход на страницу Памяток
        private async void OnMemoClicked(object sender, TappedEventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        // Переход на страницу "Как помочь"
        private async void OnHelpClicked(object sender, TappedEventArgs e)
        {
            await Navigation.PushAsync(new HelpPage());
        }
    }
}