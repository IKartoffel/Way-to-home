using Way_to_home.ViewModels;

namespace Way_to_home;

public partial class FiltersPage : ContentPage
{
    private AnimalsViewModel _viewModel;
    private string _selectedType = "Все";

    // Мы ожидаем, что ViewModel передадут из AnimalsPage
    public FiltersPage(AnimalsViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
    }

    // 1. Нажатие на стрелку "Назад"
    private async void OnBackClicked(object sender, TappedEventArgs e)
    {
        await Navigation.PopAsync();
    }

    // 2. Нажатие на чипы Вида (Собаки, Кошки, Все)
    private void OnTypeFilterTapped(object sender, TappedEventArgs e)
    {
        var border = sender as Border;
        if (border != null && e.Parameter != null)
        {
            _selectedType = e.Parameter.ToString();

            // Сбрасываем визуальное выделение у всех
            ResetChipStyle(ChipTypeAll);
            ResetChipStyle(ChipTypeDogs);
            ResetChipStyle(ChipTypeCats);

            // Выделяем нажатый
            SetChipStyleActive(border);
        }
    }

    // 3. Нажатие на "Показать анкеты"
    private async void OnApplyFiltersClicked(object sender, TappedEventArgs e)
    {
        // Передаем выбранные данные в нашу ViewModel
        _viewModel.CurrentTypeFilter = _selectedType;
        // Здесь также нужно будет передать возраст, размер и т.д.

        // Применяем фильтр
        _viewModel.ApplyFilters();

        // Возвращаемся на список
        await Navigation.PopAsync();
    }

    // 4. Нажатие на "Сбросить"
    private async void OnResetFiltersClicked(object sender, TappedEventArgs e)
    {
        _selectedType = "Все";

        ResetChipStyle(ChipTypeDogs);
        ResetChipStyle(ChipTypeCats);
        SetChipStyleActive(ChipTypeAll);

        _viewModel.ResetFilters(); // Сброс в ViewModel

        await Navigation.PopAsync();
    }

    // --- Вспомогательные методы для смены цвета чипов ---
    private void SetChipStyleActive(Border chip)
    {
        chip.BackgroundColor = Color.FromArgb("#B84A00");
        chip.Stroke = Colors.Transparent;
        if (chip.Content is Label label)
        {
            label.TextColor = Colors.White;
            label.FontAttributes = FontAttributes.Bold;
        }
    }

    private void ResetChipStyle(Border chip)
    {
        chip.BackgroundColor = Colors.Transparent;
        chip.Stroke = Color.FromArgb("#D1D1D1");
        if (chip.Content is Label label)
        {
            label.TextColor = Color.FromArgb("#2B2D42");
            label.FontAttributes = FontAttributes.None;
        }
    }
}