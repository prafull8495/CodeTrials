using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using Contracts;

namespace CalculatorOperations
{
    [Export(typeof(ICalculatorOperation))]
    [ExportMetadata("Symbol", '+')]
    public class Add : ICalculatorOperation
    {
        public int Operate(int left, int right)
        {
            return left + right;
        }
    }
    [Export(typeof(ICalculatorOperation))]
    [ExportMetadata("Symbol", '-')]
    public class Sub : ICalculatorOperation
    {
        public int Operate(int left, int right)
        {
            return left - right;
        }
    }
    [Export(typeof(ICalculatorOperation))]
    [ExportMetadata("Symbol", '*')]
    public class Mul : ICalculatorOperation
    {
        public int Operate(int left, int right)
        {
            return left * right;
        }
    }
}
