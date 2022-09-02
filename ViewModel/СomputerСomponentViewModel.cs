using MauiApp1.Model;
using MauiApp1.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModel
{
    internal class СomputerСomponentViewModel : BindableObject
    {
        // Переменная для хранения состояния
        // выбранного элемента коллекции
        private ComputerComponentModel _selectedItem;
        // Объект с логикой по извлечению данных
        // из источника
        ComputerComponentsService computerComponentService = new();

        // Коллекция извлекаемых объектов
        public ObservableCollection<ComputerComponentModel> Components { get; } = new();

        // Конструктор с вызовом метода
        // получения данных
        public СomputerСomponentViewModel()
        {
            GetFoodsAsync();
        }

        // Публичное свойство для представления
        // описания выбранного элемента из коллекции
        public string Desc { get; set; }

        // Свойство для представления и изменения
        // состояния выбранного объекта
        public ComputerComponentModel SelectedItem
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
                var components = await computerComponentService.GetComponents();

                if (Components.Count != 0)
                    Components.Clear();

                foreach (var component in components)
                {
                    Components.Add(component);
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
