using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionSimulator.Utilities.DeepCopy
{
  public interface IDeepCopyable<out T>
  {
    T DeepCopy();

    T CreateInstanceForBase();
  }
}
