namespace Reviewing_the_CSharp.Models {
  public class Subscriber {
    public string LastName { get; }
    public string PhoneNumber { get; } // Формат xxуу (например, 1234)
    public string AreaCode { get; } // Формат аабб (например, 5678)

    int permissibleLengthOfAPhoneNumber = 4;
    int permissibleLengthOfTheAreaCode = 4;

    public Subscriber(string lastName, string phoneNumber, string areaCode) {
      if (string.IsNullOrWhiteSpace(lastName)) {
        throw new ArgumentException("Фамилия не может быть пустой", nameof(lastName));
      }

      if (!IsDigitsOnly(phoneNumber) || phoneNumber.Length != permissibleLengthOfAPhoneNumber) {
        throw new ArgumentException("Номер телефона должен состоять ровно из 4 цифр (формат xxуу)", nameof(phoneNumber));
      }

      if (!IsDigitsOnly(areaCode) || areaCode.Length != permissibleLengthOfTheAreaCode) {
        throw new ArgumentException("Код города должен состоять ровно из 4 цифр (формат аабб)", nameof(areaCode));
      }

      LastName = lastName.Trim();
      PhoneNumber = phoneNumber;
      AreaCode = areaCode;
    }

    private bool IsDigitsOnly(string textToCheck) {
      if (string.IsNullOrEmpty(textToCheck)) {
        return false;
      }

      foreach (char currentCharacter in textToCheck) {
        if (!char.IsDigit(currentCharacter)) {
          return false;
        }
      }

      return true;
    }
  }
}