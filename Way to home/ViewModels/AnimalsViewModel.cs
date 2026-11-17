using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;

namespace Way_to_home.ViewModels
{
    public class AnimalsViewModel : INotifyPropertyChanged
    {
        // Метод для сброса всех фильтров


        public void ResetFilters()
        {
            // Сбрасываем значения фильтров в исходное состояние
            CurrentTypeFilter = "Все";
            CurrentSizeFilter = "Любой";

            // Возвращаем в список всех животных
            FilteredPets = new ObservableCollection<Pet>(_allPets);
        }

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
            }
        }

        // Сюда мы будем сохранять выбранные фильтры
        public string CurrentTypeFilter { get; set; } = "Все";
        public string CurrentSizeFilter { get; set; } = "Любой";

        public AnimalsViewModel()
        {
            // Заполняем список тестовыми данными
            _allPets = new List<Pet>
            {
                new Pet { Name = "Рикки", Type = "Пёс", Age = "2 года", Size = "Средний", Character = "Спокойный", ImagePath = "ricky.png" },
                new Pet { Name = "Рыжий", Type = "Кот", Age = "4 года", Size = "Средний", Character = "Ласковый", ImagePath = "ryzhiy.png" },
                new Pet { Name = "Реджи", Type = "Пёс", Age = "3 года", Size = "Крупный", Character = "Спокойный", ImagePath = "redzhi.png" }
            };

            // Изначально показываем всех
            FilteredPets = new ObservableCollection<Pet>(_allPets);
        }

        // Метод, который применяет фильтры
        public void ApplyFilters()
        {
            var result = _allPets.AsEnumerable();

            // Фильтр по виду
            if (CurrentTypeFilter != "Все")
            {
                // В фильтре написано "Собаки", а в классе Pet.Type - "Пёс". Приводим к одному виду.
                string targetType = CurrentTypeFilter == "Собаки" ? "Пёс" : "Кот";
                result = result.Where(p => p.Type == targetType);
            }

            // Фильтр по размеру
            if (CurrentSizeFilter != "Любой")
            {
                result = result.Where(p => p.Size == CurrentSizeFilter);
            }

            // Обновляем список на экране
            FilteredPets = new ObservableCollection<Pet>(result);
        }

        // Реализация интерфейса для обновления UI
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}