using Reviewing_the_CSharp.Tasks;
using Reviewing_the_CSharp.UI;

namespace Reviewing_the_CSharp {
  class Program {
    static void Main(string[] args) {
      var consoleManager = new ConsoleManager();
      var taskDensity = new TaskDensity();
      var taskPhoneBook = new TaskPhoneBook();

      Console.WriteLine("Выберите задачу для выполнения:" +
                        "\n1 - Задача 1: плотность детали" +
                        "\n2 - Задача 2: телефонный справочник");
      
      Console.Write("\nВаш выбор: ");
      string choice = Console.ReadLine();

      switch (choice) {
        case "1":
          var (a, b, h, m) = consoleManager.GetDensityInput();
          double density = taskDensity.CalculateDensity(a, b, h, m);
          consoleManager.PrintDensityResult(density);
          break;

        case "2":
          var subscribers = consoleManager.GetSubscribersInput();
          var filtered = taskPhoneBook.FilterSubscribers(subscribers);
          consoleManager.PrintSubscribers(filtered);
          break;

        default:
          Console.WriteLine("Неверный выбор");
          break;
      }

      Console.WriteLine("\nНажмите любую клавишу для выхода...");
      Console.ReadKey();
    }
  }
}