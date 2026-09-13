using Reviewing_the_CSharp.Models;

namespace Reviewing_the_CSharp.Tasks {
  public class TaskPhoneBook {
    // Фильтрует список абонентов, у которых код города (бб) совпадает с кодом номера (уу)
    public List<Subscriber> FilterSubscribers(List<Subscriber> subscribers) {
      var result = new List<Subscriber>();

      if (subscribers == null) {
        return result;
      }

      foreach (var sub in subscribers) {
        // Извлечение последних 2 символов из номера телефона (уу)
        string phoneSuffix = sub.PhoneNumber.Substring(sub.PhoneNumber.Length - 2);

        // Извлечение последних 2 символов из кода города (бб)
        string areaSuffix = sub.AreaCode.Substring(sub.AreaCode.Length - 2);

        if (phoneSuffix == areaSuffix) {
          result.Add(sub);
        }
      }

      return result;
    }
  }
}