using MauiApp1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    internal class ComputerComponentsService
    {
        List<ComputerComponentModel> componentList = new();

        // Метод GetFood() служит для извлечения и сруктурирования данных
        // в соответсвии с существующей моделью данных
        public async Task<IEnumerable<ComputerComponentModel>> GetComponents()
        {
            // Если список содержит какие-то элементы
            // то вернется последовательность с содержимым этого списка
            if (componentList?.Count > 0)
                return componentList;

            // В данном блоке кода осуществляется подключение, чтение
            // и дессериализация файла - источника данных
            using var stream = await FileSystem.OpenAppPackageFileAsync("ComputerComponents.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            componentList = JsonSerializer.Deserialize<List<ComputerComponentModel>>(contents);

            return componentList;
        }
    }
}
