using System;

namespace Polimorfizm
{
  class IntegratorB : Integrator
  {
    public override string ToString()
    {
      return "Метод трапеций";
    }

    public override double Integrate(double x1, double x2, Equasion equasion, int N)
    {
      if (equasion == null || N == 0)
      {
        throw new ArgumentNullException();
      }
      double h = (x2 - x1) / N;
      double sum = 0;
      for (int i = 1; i < N; i++)
      {
        sum += equasion.Value(x1 + i * h);
      }
      double result = h * ((equasion.Value(x1) + equasion.Value(x2)) / 2.0 + sum);
      return result;
    }
  }
}
