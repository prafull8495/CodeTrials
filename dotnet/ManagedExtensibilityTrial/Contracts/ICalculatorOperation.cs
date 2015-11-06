using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICalculatorOperation
    {
        int Operate(int left, int right);
    }
    public interface IOperationData
    {
        Char Symbol { get; }
    }
}
