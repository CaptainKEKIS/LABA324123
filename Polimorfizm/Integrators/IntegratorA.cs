using System;

namespace Polimorfizm
{
  class IntegratorA : Integrator
  {
    public override string ToString()
    {
      return "Метод прямоугольников";
    }

    public override double Integrate(double x1, double x2, Equasion equasion, int N)
    {
      if (equasion == null || N == 0)
      {
        throw new ArgumentNullException();
      }
      else if (x1 >= x2)
      {
        throw new ArgumentException("Pravaya graniza integrirovaniya doljna bit bolshe levoy!");
      }
      double h = (x2 - x1) / N;
      double sum = 0;
      for (int i = 0; i < N; i++)
      {
        sum = sum + equasion.Value(x1 + i * h) * h;
      }
      return sum;
    }
  }
}
