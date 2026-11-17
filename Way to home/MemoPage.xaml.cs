namespace Way_to_home
{
    public partial class MemoPage : ContentPage
    {
        public MemoPage()
        {
            InitializeComponent();
        }

        private async void OnBackClicked(object sender, TappedEventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}