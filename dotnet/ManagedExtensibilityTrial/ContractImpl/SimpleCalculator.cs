using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;

namespace ContractImpl
{
    [Export(typeof(ICalculator))]
    public class SimpleCalculator : ICalculator
    {
        [ImportMany]
        IEnumerable<Lazy<ICalculatorOperation,IOperationData>> operations;
        public string Calculate(string input)
        {
            int left;
            int right;
            Char operation;
            int fn = FindFirstNonDigit(input); //finds the operator
            if (fn < 0) return "Could not parse command.";

            try
            {
                //separate out the operands
                left = int.Parse(input.Substring(0, fn));
                right = int.Parse(input.Substring(fn + 1));
            }
            catch
            {
                return "Could not parse command.";
            }

            operation = input[fn];

            foreach (Lazy<ICalculatorOperation, IOperationData> i in operations)
            {
                if (i.Metadata.Symbol.Equals(operation)) return i.Value.Operate(left, right).ToString();
            }
            return "Operation Not Found!";
        }

        private int FindFirstNonDigit(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (!(Char.IsDigit(input[i]))) return i;
            }
            return -1;
        }
    }
}
