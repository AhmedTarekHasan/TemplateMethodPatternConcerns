using System;

namespace TemplateMethodPatternWithInterfaces
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

    public interface ICalculateExpenses
    {
        decimal CalculateExpenses(decimal input);
    }

    public interface ICalculateIncomeTax
    {
        decimal CalculateIncomeTax(decimal income);
    }

    public interface ICalculateVat
    {
        decimal CalculateVat(decimal vat);
    }

    public abstract class TaxCalculator
    {
        public decimal CalculateTaxes()
        {
            decimal total = 1436;

            if (this is ICalculateExpenses expensesCalculator)
            {
                // This call would be skipped in case of TaxCalculator1
                total += expensesCalculator.CalculateExpenses(1436);
            }

            total += DoSomething1(124);

            if (this is ICalculateIncomeTax incomeTaxCalculator)
            {
                // This call would be skipped in case of TaxCalculator2
                total += incomeTaxCalculator.CalculateIncomeTax(452);
            }

            total += DoSomething2(624);

            if (this is ICalculateVat vatCalculator)
            {
                // This call would be skipped in case of TaxCalculator1 and TaxCalculator2
                total += vatCalculator.CalculateVat(715);
            }

            return total;
        }

        private static decimal DoSomething1(decimal amount) => amount + 260;
        private static decimal DoSomething2(decimal amount) => amount + 472;
    }

    public class TaxCalculator1 : TaxCalculator, ICalculateIncomeTax
    {
        public decimal CalculateIncomeTax(decimal income)
        {
            return income + 100;
        }
    }

    public class TaxCalculator2 : TaxCalculator, ICalculateExpenses
    {
        public decimal CalculateExpenses(decimal input)
        {
            return input + 120;
        }
    }
}