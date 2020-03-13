using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CarFinder
{
    static internal class InputDataValidator
    {
        public static CarSearchParams JsonDeserialize(string jsonFIlePath)
        {
            using (StreamReader reader = new StreamReader(jsonFIlePath))
            {
                string json = reader.ReadToEnd();
                CarSearchParams y = JsonSerializer.Deserialize<CarSearchParams>(json);
                return y;
            }
        }
            public static void ValidateInputData(string make, string model, int yearStart, int yearEnd)
        {
            if ((make is null) & !(model is null))
            {
                throw new Exception("Ошибка: марка автомобиля должна быть указана, если указана модель");
            }
            if (yearStart > yearEnd)
            {
                throw new Exception("Ошибка: год выпуска 'c' не должен превышать год выпуска 'по'");
            }
        }
    }
}
