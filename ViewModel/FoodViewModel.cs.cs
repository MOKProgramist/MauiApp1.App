using MauiApp1.Model;
using MauiApp1.Services;
using System.Windows;
using System.Collections.ObjectModel;

namespace MauiApp1.ViewModel
{
    internal class FoodViewModel: BindableObject
    {
        // Переменная для хранения состояния
        // выбранного элемента коллекции
        private Food _selectedItem;
        // Объект с логикой по извлечению данных
        // из источника
        FoodService foodService = new();

        // Коллекция извлекаемых объектов
        public ObservableCollection<Food> Foods { get; } = new();

        // Конструктор с вызовом метода
        // получения данных
        public FoodViewModel()
        {
            GetFoodsAsync();
        }

        // Публичное свойство для представления
        // описания выбранного элемента из коллекции
        public string Desc { get; set; }

        // Свойство для представления и изменения
        // состояния выбранного объекта
        public Food SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                Desc = value?.Description;
                // Метод отвечает за обновление данных
                // в реальном времени
                OnPropertyChanged(nameof(Desc));
            }
        }

        // Метод получения коллекции объектов
        async Task GetFoodsAsync()
        {
            try
            {
                var foods = await foodService.GetFood();

                if (Foods.Count != 0)
                    Foods.Clear();

                foreach (var food in foods)
                {
                    Foods.Add(food);
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Ошибка!",
                    $"Что-то пошло не так: {ex.Message}", "OK");
            }
        }

    }
}
