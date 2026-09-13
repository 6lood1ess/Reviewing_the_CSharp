using Reviewing_the_CSharp.Models;

namespace Reviewing_the_CSharp.UI {
  public class ConsoleManager {
    // Универсальные помощники ввода данных для решения заданий
    // Запрашивает у пользователя положительное число с повторным вводом при ошибке
    private double ReadPositiveDouble(string prompt) {
      while (true) {
        Console.Write(prompt);
        string input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input)) {
          Console.WriteLine("\nВвод не может быть пустым. Попробуйте снова\n");
          continue;
        }

        // Заменяем запятую на точку — на случай, если пользователь вводит в русской раскладке
        input = input.Replace(',', '.');

        if (!double.TryParse(input, System.Globalization.NumberStyles.Float,
            System.Globalization.CultureInfo.InvariantCulture, out double value)) {

          Console.WriteLine("\nНекорректное число. Попробуйте снова\n");
          continue;
        }

        if (value <= 0) {
          Console.WriteLine("\nЗначение должно быть больше нуля. Попробуйте снова\n");
          continue;
        }

        return value;
      }
    }

    // Запрашивает непустую строку с повторным вводом при ошибке
    private string ReadNonEmptyString(string prompt) {
      while (true) {
        Console.Write(prompt);
        string input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input)) {
          Console.WriteLine("\nСтрока не может быть пустой. Попробуйте снова\n");
          continue;
        }

        return input.Trim();
      }
    }

    // Запрашивает строку из ровно N цифр
    private string ReadDigits(string prompt, int length) {
      while (true) {
        Console.Write(prompt);
        string input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input)) {
          Console.WriteLine("\nВвод не может быть пустым. Попробуйте снова\n");
          continue;
        }

        input = input.Trim();

        if (input.Length != length) {
          Console.WriteLine($"\nДолжно быть ровно {length} цифр. Попробуйте снова\n");
          continue;
        }

        bool allDigits = true;

        foreach (char c in input) {
          if (!char.IsDigit(c)) {
            allDigits = false;
            break;
          }
        }

        if (!allDigits) {
          Console.WriteLine("\nДопускаются только цифры. Попробуйте снова\n");
          continue;
        }

        return input;
      }
    }

    // Запрашивает целое число в заданном диапазоне
    private int ReadIntInRange(string prompt, int min, int max) {
      while (true) {
        Console.Write(prompt);
        string input = Console.ReadLine();

        if (!int.TryParse(input, out int value)) {
          Console.WriteLine("\nНекорректное целое число. Попробуйте снова\n");
          continue;
        }

        if (value < min || value > max) {
          Console.WriteLine($"\nВведите число от {min} до {max}. Попробуйте снова\n");
          continue;
        }

        return value;
      }
    }

    // Ввод данных для задачи с плотностью
    public (double a, double b, double h, double m) GetDensityInput() {
      Console.WriteLine("\n--- Ввод данных для детали (Задача 1: плотность) ---");

      double a = ReadPositiveDouble("Введите катет a (см): ");
      double b = ReadPositiveDouble("Введите катет b (см): ");
      double h = ReadPositiveDouble("Введите толщину h (см): ");
      double m = ReadPositiveDouble("Введите массу m (г): ");

      return (a, b, h, m);
    }

    // Вывод плотности
    public void PrintDensityResult(double density) {
      Console.WriteLine("\n--- Результат задачи ---" +
                        $"\nПлотность материала: {density:F4} г/см^3");
    }

    // Ввод данных для задачи с телефонным справочником
    public List<Subscriber> GetSubscribersInput() {
      Console.WriteLine("\n--- Ввод данных для справочника (Задача 2: телефонный справочник) ---");
      var list = new List<Subscriber>();

      int count = ReadIntInRange("Сколько абонентов вы хотите добавить? (1..100): ", 1, 100);

      for (int subscriberNumber = 0; subscriberNumber < count; ++subscriberNumber) {
        Console.WriteLine($"\nАбонент #{subscriberNumber + 1}");

        while (true) {
          try {
            string lastName = ReadNonEmptyString("Фамилия: ");
            string phoneNumber = ReadDigits("Номер телефона (ровно 4 цифры, формат xxуу): ", 4);
            string areaCode = ReadDigits("Код города (ровно 4 цифры, формат аабб): ", 4);

            list.Add(new Subscriber(lastName, phoneNumber, areaCode));
            break;

          } catch (ArgumentException exception) {
            Console.WriteLine($"\nОшибка: {exception.Message}. Повторите ввод абонента\n");
          }
        }
      }

      return list;
    }

    // Вывод абонентов с совпадением yy = бб
    public void PrintSubscribers(List<Subscriber> subscribers) {
      Console.WriteLine("\n--- Результат задачи ---");

      if (subscribers == null || subscribers.Count == 0) {
        Console.WriteLine("Абонентов с совпадением уу = бб не найдено");
        return;
      }

      Console.WriteLine($"{"Фамилия",-15} | {"Телефон",-10} | {"Город",-10}" +
                        $"\n{new string('-', 40)}");
      foreach (var sub in subscribers) {
        Console.WriteLine($"{sub.LastName,-15} | {sub.PhoneNumber,-10} | {sub.AreaCode,-10}");
      }
    }

    public void PrintTaskConditions() {
      Console.WriteLine("--------------------------------------------------\n" +
                        "УСЛОВИЯ ЗАДАЧ\n" +
                        "--------------------------------------------------");

      Console.WriteLine("\nЗадача 1. Плотность детали\n\n" +
                        "Какую плотность должен иметь материал, из которого\n" +
                        "изготовлена деталь в форме прямоугольного треугольника\n" +
                        "с катетами a и b, толщиной h, если масса детали m?");

      Console.WriteLine("\nЗадача 2. Телефонный справочник\n\n" +
                        "Телефонный справочник содержит данные об абонентах:\n" +
                        "фамилия, номер телефона (число формата xxуу),\n" +
                        "код установки телефона (формат аабб).\n" +
                        "Вывести данные об абонентах, у которых уу = бб.\n");

      Console.WriteLine("--------------------------------------------------");
    }
  }
}