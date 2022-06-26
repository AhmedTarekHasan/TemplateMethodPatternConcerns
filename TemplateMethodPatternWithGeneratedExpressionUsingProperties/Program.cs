using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using AgileObjects.ReadableExpressions;

namespace TemplateMethodPatternWithGeneratedExpressionUsingProperties
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
            // Now, there are no extra un-needed calls inside the loop even the
            // if condition checks.
            for (var i = 0; i < 5_000_000; i++)
            {
                total += calculator.CalculateTaxes();
            }

            calculator = new TaxCalculator2();

            // Frequent calls to simulate performance hits
            // Now, there are no extra un-needed calls inside the loop even the
            // if condition checks.
            for (var i = 0; i < 5_000_000; i++)
            {
                total += calculator.CalculateTaxes();
            }

            return total;
        }
    }

    public abstract class TaxCalculator
    {
        private readonly Func<TaxCalculator, decimal> _calculateDelegate;

        protected TaxCalculator()
        {
            // Generate the function only once and then call it many times.
            _calculateDelegate = BuildExpression(this).Compile();
        }

        protected abstract bool CanCalculateExpenses { get; }
        protected abstract bool CanCalculateIncomeTax { get; }
        protected abstract bool CanCalculateVat { get; }


        public decimal CalculateTaxes()
        {
            return _calculateDelegate(this);
        }

        protected abstract decimal CalculateExpenses(decimal input);
        protected abstract decimal CalculateIncomeTax(decimal income);
        protected abstract decimal CalculateVat(decimal vat);

        private static decimal DoSomething1(decimal amount) => amount + 260;
        private static decimal DoSomething2(decimal amount) => amount + 472;

        private static Expression<Func<TaxCalculator, decimal>> BuildExpression(TaxCalculator taxCalculator)
        {
            // Define a list to contain all the possible statements to be added the whole code block.
            // The capacity is initialized with 7 as this is the maximum number of statements to be added
            // as per the logic below. A TrimExcess() call would be performed at the end to trim any possible
            // excess capacity.
            var statementsExpressions = new List<Expression>(7);

            #region Define constants

            var constantExpression1436 = Expression.Constant((decimal)1436, typeof(decimal));
            var constantExpression124 = Expression.Constant((decimal)124, typeof(decimal));
            var constantExpression452 = Expression.Constant((decimal)452, typeof(decimal));
            var constantExpression624 = Expression.Constant((decimal)624, typeof(decimal));
            var constantExpression715 = Expression.Constant((decimal)715, typeof(decimal));

            #endregion

            #region Define parameters

            var calculatorParameterExpressions = Expression.Parameter(typeof(TaxCalculator), "taxCalculator");

            #endregion

            #region Define "total" variable

            // decimal total
            var variableTotalExpression = Expression.Variable(typeof(decimal), "total");

            #endregion

            #region Assign "total" variable the constant value 1436

            statementsExpressions.Add(Expression.Assign(variableTotalExpression,
                constantExpression1436)); // var total = 1436

            #endregion

            #region Add taxCalculator.CalculateExpenses(1436) if CanCalculateExpenses is true

            // Only add taxCalculator.CalculateExpenses(1436) if CanCalculateExpenses is true
            // Otherwise, don't add anything
            if (taxCalculator.CanCalculateExpenses)
            {
                var calculateExpensesMethodInfo = typeof(TaxCalculator).GetMethod(
                    nameof(taxCalculator.CalculateExpenses), BindingFlags.NonPublic | BindingFlags.Instance);
                var calculateExpensesMethodCallExpression =
                    Expression.Call(
                        calculatorParameterExpressions,
                        calculateExpensesMethodInfo,
                        constantExpression1436); // taxCalculator.CalculateExpenses(1436)

                statementsExpressions.Add(
                    Expression.Assign(
                        variableTotalExpression,
                        Expression.Add(variableTotalExpression, calculateExpensesMethodCallExpression)));
            }

            #endregion

            #region Call MemoryBenchmarker.DoSomething1(124)

            var doSomething1MethodInfo =
                typeof(TaxCalculator).GetMethod(nameof(DoSomething1), BindingFlags.NonPublic | BindingFlags.Static);
            var doSomething1MethodCallExpression =
                Expression.Call(
                    doSomething1MethodInfo,
                    constantExpression124); // TaxCalculator.DoSomething1(124)

            statementsExpressions.Add(
                Expression.Assign(
                    variableTotalExpression,
                    Expression.Add(variableTotalExpression, doSomething1MethodCallExpression)));

            #endregion

            #region Add taxCalculator.CalculateIncomeTax(452) if CanCalculateIncomeTax is true

            // Only add taxCalculator.CalculateIncomeTax(452) if CanCalculateIncomeTax is true
            // Otherwise, don't add anything
            if (taxCalculator.CanCalculateIncomeTax)
            {
                var calculateIncomeTaxMethodInfo = typeof(TaxCalculator).GetMethod(
                    nameof(taxCalculator.CalculateIncomeTax), BindingFlags.NonPublic | BindingFlags.Instance);
                var calculateIncomeTaxMethodCallExpression =
                    Expression.Call(
                        calculatorParameterExpressions,
                        calculateIncomeTaxMethodInfo,
                        constantExpression452); // taxCalculator.CalculateIncomeTax(452)

                statementsExpressions.Add(
                    Expression.Assign(
                        variableTotalExpression,
                        Expression.Add(variableTotalExpression, calculateIncomeTaxMethodCallExpression)));
            }

            #endregion

            #region Call MemoryBenchmarker.DoSomething2(624)

            var doSomething2MethodInfo =
                typeof(TaxCalculator).GetMethod(nameof(DoSomething2), BindingFlags.NonPublic | BindingFlags.Static);
            var doSomething2MethodCallExpression =
                Expression.Call(
                    doSomething2MethodInfo,
                    constantExpression624); // TaxCalculator.DoSomething2(624)

            statementsExpressions.Add(
                Expression.Assign(
                    variableTotalExpression,
                    Expression.Add(variableTotalExpression, doSomething2MethodCallExpression)));

            #endregion

            #region Add taxCalculator.CalculateVat(715) if CanCalculateVat is true

            // Only add taxCalculator.CalculateVat(715) if CanCalculateVat is true
            // Otherwise, don't add anything
            if (taxCalculator.CanCalculateVat)
            {
                var calculateVatMethodInfo = typeof(TaxCalculator).GetMethod(nameof(taxCalculator.CalculateVat),
                    BindingFlags.NonPublic | BindingFlags.Instance);
                var calculateVatMethodCallExpression =
                    Expression.Call(
                        calculatorParameterExpressions,
                        calculateVatMethodInfo,
                        constantExpression715); // taxCalculator.CalculateVat(715)

                statementsExpressions.Add(
                    Expression.Assign(
                        variableTotalExpression,
                        Expression.Add(variableTotalExpression, calculateVatMethodCallExpression)));
            }

            #endregion

            #region Add the variable "total" to be evaluated and returned as he final result

            statementsExpressions.Add(variableTotalExpression);

            #endregion

            // Trim any possible excess capacity.
            statementsExpressions.TrimExcess();

            #region Build the whole statements block

            // Don't forget to add "new ParameterExpression[] { variableTotalExpression }" as the first parameter.
            // Otherwise, you would get an error because the "total" variable is not defined inside the right scope
            // at all.
            var finalExpression = Expression.Block(
                new ParameterExpression[] { variableTotalExpression },
                statementsExpressions);

            #endregion

            // Writing the generated code only for visual validation
            // Console.WriteLine(finalExpression.ToReadableString());

            // Return the final generated Lambda expression
            return Expression.Lambda<Func<TaxCalculator, decimal>>(finalExpression, calculatorParameterExpressions);
        }
    }

    public class TaxCalculator1 : TaxCalculator
    {
        protected override bool CanCalculateExpenses => false;
        protected override bool CanCalculateIncomeTax => true;
        protected override bool CanCalculateVat => false;


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
        protected override bool CanCalculateExpenses => true;
        protected override bool CanCalculateIncomeTax => false;
        protected override bool CanCalculateVat => false;


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