using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;

namespace Way_to_home.ViewModels
{
    public class AnimalsViewModel : INotifyPropertyChanged
    {
        // 1. Список ВСЕХ животных
        private List<Pet> _allPets;

        // 2. Список, который видит пользователь
        private ObservableCollection<Pet> _filteredPets;
        public ObservableCollection<Pet> FilteredPets
        {
            get => _filteredPets;
            set
            {
                _filteredPets = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FilteredPetsCount)); // Обновляем счетчик вместе со списком
            }
        }

        // Счетчик анкет
        public int FilteredPetsCount => FilteredPets?.Count ?? 0;

        // Свойства для сохранения выбранных фильтров
        public string CurrentTypeFilter { get; set; } = "Все";
        public string CurrentAgeFilter { get; set; } = "Любой";
        public string CurrentSizeFilter { get; set; } = "Любой";

        public AnimalsViewModel()
        {
            // Берем данные из вашего PetData
            _allPets = PetData.Pets;

            // Изначально показываем всех (дублирующую строку я убрал)
            FilteredPets = new ObservableCollection<Pet>(_allPets);
        }

        // Метод, который применяет фильтры
        public void ApplyFilters()
        {
            var result = _allPets.AsEnumerable();

            // 1. Фильтр по виду
            if (CurrentTypeFilter != "Все" && !string.IsNullOrEmpty(CurrentTypeFilter))
            {
                string targetType = CurrentTypeFilter == "Собаки" ? "Пёс" : "Кот";
                result = result.Where(p => p.Type == targetType);
            }

            // 2. Фильтр по размеру
            if (CurrentSizeFilter != "Любой" && !string.IsNullOrEmpty(CurrentSizeFilter))
            {
                result = result.Where(p => p.Size == CurrentSizeFilter);
            }

            // 3. Фильтр по возрасту
            if (CurrentAgeFilter != "Любой" && !string.IsNullOrEmpty(CurrentAgeFilter))
            {
                result = result.Where(p =>
                {
                    string ageStr = p.Age.Split(' ')[0];
                    if (int.TryParse(ageStr, out int age))
                    {
                        if (CurrentAgeFilter == "До 1 года") return age < 1;
                        if (CurrentAgeFilter == "1–7 лет") return age >= 1 && age <= 7;
                        if (CurrentAgeFilter == "Старше 7") return age > 7;
                    }
                    return true;
                });
            }

            // Обновляем список (счетчик обновится автоматически через setter)
            FilteredPets = new ObservableCollection<Pet>(result);
        }

        // Метод для сброса всех фильтров
        public void ResetFilters()
        {
            CurrentTypeFilter = "Все";
            CurrentAgeFilter = "Любой";   // Добавил сброс возраста
            CurrentSizeFilter = "Любой";

            // Возвращаем в список всех животных
            FilteredPets = new ObservableCollection<Pet>(_allPets);
        }

        // --- РЕАЛИЗАЦИЯ INotifyPropertyChanged ---
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}