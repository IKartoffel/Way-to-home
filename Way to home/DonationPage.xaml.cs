namespace Way_to_home;

public partial class DonationPage : ContentPage
{
    private string _selectedAmount = "500"; // Сумма по умолчанию

    // В конструктор мы передаем название нужды (например, "Корм")
    public DonationPage(string needItem)
    {
        InitializeComponent();

        // Меняем заголовок в зависимости от того, что выбрали
        GoalLabel.Text = $"Помочь: {needItem}";

        // Сразу подсвечиваем кнопку 500
        SetChipStyleActive(Chip500);
    }

    // Обработчик выбора суммы (чипы)
    private void OnAmountTapped(object sender, TappedEventArgs e)
    {
        if (sender is Border border && e.Parameter != null)
        {
            // Сбрасываем все чипы
            ResetChipStyle(Chip100); ResetChipStyle(Chip300);
            ResetChipStyle(Chip500); ResetChipStyle(Chip1000);

            // Зажигаем нажатый
            SetChipStyleActive(border);

            _selectedAmount = e.Parameter.ToString();
            CustomAmountEntry.Text = string.Empty; // Очищаем поле ручного ввода
            DonateButton.Text = $"Пожертвовать {_selectedAmount} ₽";
        }
    }

    // Если пользователь начал вводить свою сумму
    private void OnCustomAmountChanged(object sender, TextChangedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(e.NewTextValue))
        {
            // Сбрасываем выделение чипов
            ResetChipStyle(Chip100); ResetChipStyle(Chip300);
            ResetChipStyle(Chip500); ResetChipStyle(Chip1000);

            _selectedAmount = e.NewTextValue;
            DonateButton.Text = $"Пожертвовать {_selectedAmount} ₽";
        }
    }

    // Нажатие на кнопку пожертвования
    private async void OnDonateClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(_selectedAmount) || _selectedAmount == "0")
        {
            await DisplayAlert("Ошибка", "Пожалуйста, выберите или введите сумму.", "ОК");
            return;
        }

        await DisplayAlert("Спасибо!", $"Вы успешно пожертвовали {_selectedAmount} ₽. Ваша помощь бесценна!", "ОК");
        await Navigation.PopAsync(); // Возвращаемся назад
    }

    private async void OnBackClicked(object sender, TappedEventArgs e)
    {
        await Navigation.PopAsync();
    }

    // --- Вспомогательные методы для изменения цвета кнопок сумм ---

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