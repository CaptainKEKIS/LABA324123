using System;

namespace Polimorfizm
{
  class EquasionB : Equasion
  {
    private readonly double a;

    public EquasionB(double a)
    {
      this.a = a;
    }

    public override double Value(double x)
    {
      return Math.Sin(a * x) / x;
    }
  }
}
