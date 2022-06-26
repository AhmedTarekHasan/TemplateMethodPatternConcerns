using System;

namespace TemplateMethodPattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Run());
            Console.ReadLine();
        }

        public static decimal Run()
        {
            decimal total = 0;

            TaxCalculator calculator = new TaxCalculator1();

            // Frequent calls to simulate performance hits
            for (var i = 0; i < 5_000_000; i++)
            {
                total += calculator.CalculateTaxes();
            }

            calculator = new TaxCalculator2();

            // Frequent calls to simulate performance hits
            for (var i = 0; i < 5_000_000; i++)
            {
                total += calculator.CalculateTaxes();
            }

            return total;
        }
    }

    public abstract class TaxCalculator
    {
        public decimal CalculateTaxes()
        {
            decimal total = 1436;

            // This call is useless in case of TaxCalculator1
            total += CalculateExpenses(1436);

            total += DoSomething1(124);

            // This call is useless in case of TaxCalculator2
            total += CalculateIncomeTax(452);

            total += DoSomething2(624);

            // This call is useless in case of TaxCalculator1 and TaxCalculator2
            total += CalculateVat(715);

            return total;
        }

        protected abstract decimal CalculateExpenses(decimal input);
        protected abstract decimal CalculateIncomeTax(decimal income);
        protected abstract decimal CalculateVat(decimal vat);

        private static decimal DoSomething1(decimal amount) => amount + 260;
        private static decimal DoSomething2(decimal amount) => amount + 472;
    }

    public class TaxCalculator1 : TaxCalculator
    {
        // No logic to apply. Therefore, just return 0.
        protected override decimal CalculateExpenses(decimal input)
        {
            return 0;
        }

        protected override decimal CalculateIncomeTax(decimal income)
        {
            return income + 100;
        }

        // No logic to apply. Therefore, just return 0.
        protected override decimal CalculateVat(decimal vat)
        {
            return 0;
        }
    }

    public class TaxCalculator2 : TaxCalculator
    {
        protected override decimal CalculateExpenses(decimal input)
        {
            return input + 120;
        }

        // No logic to apply. Therefore, just return 0.
        protected override decimal CalculateIncomeTax(decimal income)
        {
            return 0;
        }

        // No logic to apply. Therefore, just return 0.
        protected override decimal CalculateVat(decimal vat)
        {
            return 0;
        }
    }
}