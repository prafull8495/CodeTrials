using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

using Contracts;

namespace ManagedExtensibilityTrialConsole
{
    class Program
    {
        [Import(typeof(ICalculator))]
        public ICalculator Calculator;

        private CompositionContainer _container;
        private Program()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Program).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(ICalculator).Assembly));
            catalog.Catalogs.Add(new DirectoryCatalog(@"..\..\Extensions"));

            _container = new CompositionContainer(catalog);
            try
            {
                this._container.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.Message);
            }
        }
        static void Main(string[] args)
        {
            Program P = new Program();
            Console.WriteLine("Input an integer operation");
            while(true)
            {
                string input = Console.ReadLine();
                Console.WriteLine(P.Calculator.Calculate(input));
            }
        }
    }
}
