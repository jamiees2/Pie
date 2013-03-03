using System;

namespace Pie.Units
{
    public interface Temperature
    {
        string ToString(bool unit);

        string ToString(bool unit, Func<double, string> result);
    }
}
