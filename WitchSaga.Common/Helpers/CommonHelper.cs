using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WitchSaga.Common.Helpers
{
    public static class CommonHelper
    {
        public static int GetSubtraction(int a, int b)
        {
            return b - a;
        }

        public static decimal GetAverage(List<int> inputs)
        {
            return (inputs.Sum() / inputs.Count());
        }
    }
}
