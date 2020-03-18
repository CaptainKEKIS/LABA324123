using System;

namespace Polimorfizm
{
  class EquasionA : Equasion
  {
    private readonly double _a;
    private readonly double _b;
    public EquasionA(double a, double b)
    {
      _a = a;
      _b = b;
    }
    public override double Value(double x)
    {
      return _a * x * x + _b * x * x;
    }
  }
}
