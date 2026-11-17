namespace Way_to_home
{
    public partial class PetDetailsPage : ContentPage
    {
        // Конструктор теперь принимает объект Pet
        public PetDetailsPage(Pet pet)
        {
            InitializeComponent();

            // Это магия привязки: все {Binding ...} в XAML возьмут данные из этого объекта
            BindingContext = pet;
        }

        private async void OnBackClicked(object sender, TappedEventArgs e)
        {
            await Navigation.PopAsync();
        }
        private async void OnReadMemoClicked(object sender, TappedEventArgs e)
        {
            await Navigation.PushAsync(new MemoPage());
        }
    }
}