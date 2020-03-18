using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polimorfizm
{
  public abstract class Integrator
  {
    public abstract override string ToString();
    public abstract double Integrate(double x1, double x2, Equasion equasion, int N);
  }
}
