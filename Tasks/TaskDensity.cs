using System;

namespace Reviewing_the_CSharp.Tasks {
  public static class TaskDensity {

    // Вычисляет плотность материала детали
    public static double CalculateDensity(double a, double b, double h, double m) {
      // Первый катет a (см) должен быть > 0
      if (a <= 0) throw new ArgumentException("Катет a должен быть положительным", nameof(a));

      // Второй катет b (см) должен быть > 0
      if (b <= 0) throw new ArgumentException("Катет b должен быть положительным", nameof(b));

      // Толщина h (см) должна быть > 0
      if (h <= 0) throw new ArgumentException("Толщина h должна быть положительной", nameof(h));

      // Масса m (г) должна быть > 0
      if (m <= 0) throw new ArgumentException("Масса m должна быть положительной", nameof(m));

      // Площадь прямоугольного треугольника = (a * b) / 2
      double area = (a * b) / 2.0;

      // Объем детали = площадь * толщина
      double volume = area * h;

      // Плотность (г/см^3) = масса / объем
      return m / volume;
    }
  }
}