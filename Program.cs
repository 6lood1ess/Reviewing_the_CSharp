using Reviewing_the_CSharp.Tasks;
using Reviewing_the_CSharp.UI;

namespace Reviewing_the_CSharp {
  class Program {
    static void Main(string[] args) {
      var consoleManager = new ConsoleManager();
      var taskDensity = new TaskDensity();
      var taskPhoneBook = new TaskPhoneBook();

      bool isRunning = true;

      while (isRunning) {
        Console.Clear();
        Console.WriteLine("Выберите задачу для выполнения:" +
                        "\n1 - Задача 1: плотность детали" +
                        "\n2 - Задача 2: телефонный справочник" +
                        "\n3 - Ознакомиться с условиями задач" +
                        "\n4 - Выйти из программы");

        Console.Write("\nВаш выбор: ");
        string choice = Console.ReadLine();

        switch (choice) {

          case "1":
            var (a, b, h, m) = consoleManager.GetDensityInput();
            double density = taskDensity.CalculateDensity(a, b, h, m);
            consoleManager.PrintDensityResult(density);

            Console.WriteLine("\nНажмите любую клавишу для выхода в меню...");
            Console.ReadKey();
            break;

          case "2":
            var subscribers = consoleManager.GetSubscribersInput();
            var filtered = taskPhoneBook.FilterSubscribers(subscribers);
            consoleManager.PrintSubscribers(filtered);

            Console.WriteLine("\nНажмите любую клавишу для выхода в меню...");
            Console.ReadKey();
            break;

          case "3":
            consoleManager.PrintTaskConditions();

            Console.WriteLine("\nНажмите любую клавишу для выхода в меню...");
            Console.ReadKey();
            break;

          case "4":
            isRunning = false;
            break;

          default:
            Console.WriteLine("\nНеверный выбор");

            Console.WriteLine("\nНажмите любую клавишу для выхода в меню...");
            Console.ReadKey();
            break;
        }
      }
    }
  }
}