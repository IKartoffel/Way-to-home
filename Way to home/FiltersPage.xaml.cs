using Way_to_home.ViewModels;

namespace Way_to_home;

public partial class FiltersPage : ContentPage
{
    private AnimalsViewModel _viewModel;

    public FiltersPage(AnimalsViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;

        RestoreFilterState(); // Восстанавливаем визуал при открытии
    }

    private void OnTypeFilterTapped(object sender, TappedEventArgs e)
    {
        if (sender is Border border && e.Parameter != null)
        {
            _viewModel.CurrentTypeFilter = e.Parameter.ToString();
            ResetAllTypeChips();
            SetChipStyleActive(border);
        }
    }

    private void OnAgeFilterTapped(object sender, TappedEventArgs e)
    {
        if (sender is Border border && e.Parameter != null)
        {
            _viewModel.CurrentAgeFilter = e.Parameter.ToString();
            ResetAllAgeChips();
            SetChipStyleActive(border);
        }
    }

    private void OnSizeFilterTapped(object sender, TappedEventArgs e)
    {
        if (sender is Border border && e.Parameter != null)
        {
            _viewModel.CurrentSizeFilter = e.Parameter.ToString();
            ResetAllSizeChips();
            SetChipStyleActive(border);
        }
    }

    private async void OnApplyFiltersClicked(object sender, TappedEventArgs e)
    {
        _viewModel.ApplyFilters();
        await Navigation.PopAsync();
    }

    private async void OnResetFiltersClicked(object sender, TappedEventArgs e)
    {
        _viewModel.CurrentTypeFilter = "Все";
        _viewModel.CurrentAgeFilter = "Любой";
        _viewModel.CurrentSizeFilter = "Любой";

        _viewModel.ResetFilters(); // Возвращаем всех животных
        RestoreFilterState();      // Красим дефолтные кнопки
        await Navigation.PopAsync();
    }

    private async void OnBackClicked(object sender, TappedEventArgs e)
    {
        await Navigation.PopAsync();
    }

    // --- ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ ---

    private void RestoreFilterState()
    {
        ResetAllTypeChips();
        ResetAllAgeChips();
        ResetAllSizeChips();

        // Вид
        if (_viewModel.CurrentTypeFilter == "Собаки") SetChipStyleActive(ChipTypeDogs);
        else if (_viewModel.CurrentTypeFilter == "Коты") SetChipStyleActive(ChipTypeCats);
        else SetChipStyleActive(ChipTypeAll);

        // Возраст
        if (_viewModel.CurrentAgeFilter == "До 1 года") SetChipStyleActive(ChipAgeUpTo1);
        else if (_viewModel.CurrentAgeFilter == "1–7 лет") SetChipStyleActive(ChipAge1To7);
        else if (_viewModel.CurrentAgeFilter == "Старше 7") SetChipStyleActive(ChipAgeOver7);
        else SetChipStyleActive(ChipAgeAny);

        // Размер
        if (_viewModel.CurrentSizeFilter == "Малый") SetChipStyleActive(ChipSizeSmall);
        else if (_viewModel.CurrentSizeFilter == "Средний") SetChipStyleActive(ChipSizeMedium);
        else if (_viewModel.CurrentSizeFilter == "Крупный") SetChipStyleActive(ChipSizeLarge);
        else SetChipStyleActive(ChipSizeAny);
    }

    private void ResetAllTypeChips()
    {
        ResetChipStyle(ChipTypeAll); ResetChipStyle(ChipTypeDogs); ResetChipStyle(ChipTypeCats);
    }
    private void ResetAllAgeChips()
    {
        ResetChipStyle(ChipAgeAny); ResetChipStyle(ChipAgeUpTo1); ResetChipStyle(ChipAge1To7); ResetChipStyle(ChipAgeOver7);
    }
    private void ResetAllSizeChips()
    {
        ResetChipStyle(ChipSizeAny); ResetChipStyle(ChipSizeSmall); ResetChipStyle(ChipSizeMedium); ResetChipStyle(ChipSizeLarge);
    }

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