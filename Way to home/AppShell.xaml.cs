namespace Way_to_home;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(FiltersPage), typeof(FiltersPage));
    }
}