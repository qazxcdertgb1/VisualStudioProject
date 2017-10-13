using System;

namespace ScriptTest
{
	class CalculatorInside
	{
		public void Start()
		{
			double inputNum1;
			double inputNum2;
			char symbol;
			double result;

			for (;;)
			{
				try
				{
					try
					{
						Console.Write("\n数字1: ");
						inputNum1 = Convert.ToDouble(Console.ReadLine());

						Console.Clear();
						Console.Write("{0}\n支持的运算: 加(+),减(-),乘(x,X,×,*),除(/,\\)\n运算符号: ", inputNum1);
						symbol = Console.ReadKey(false).KeyChar;

						Console.Clear();
						Console.Write("{0}{1}\n数字2: ", inputNum1, symbol);
						inputNum2 = Convert.ToDouble(Console.ReadLine());

						Console.Clear();

						result = Calculator.StartCalculator(inputNum1, inputNum2, symbol);
					}
					catch (Exception)
					{
						Console.Clear();
						throw;
					}
				}
				catch (FormatException)
				{
					Console.WriteLine("输入错误");
					continue;

				}
				catch (DivideByZeroException)
				{
					Console.WriteLine("除数不能为0");
					continue;
				}
				catch (SymbolException)
				{
					Console.WriteLine("符号错误");
					continue;
				}
				catch (OverflowException)
				{
					Console.WriteLine("数字过大");
					continue;
				}
				catch (OutOfMemoryException)
				{
					Console.WriteLine("内存溢出");
					continue;
				}
				break;
			}
			Console.WriteLine("{0}{1}{2}={3}\n", inputNum1, symbol, inputNum2, result);
		}
	}

	static class Calculator
	{
		public static double StartCalculator(double num1, double num2, char symbol)
		{
			switch (symbol)
			{
				case '+':
					return Addition(num1, num2);
				case '-':
					return Subtraction(num1, num2);
				case 'X':
				case 'x':
				case '×':
				case '*':
					return Multiplication(num1, num2);
				case '/':
				case '\\':
					return Division(num1, num2);
				default:
					throw new SymbolException();
			}
		}

		private static double Addition(double num1, double num2)
		{
			return num1 + num2;
		}

		private static double Subtraction(double num1, double num2)
		{
			return num1 - num2;
		}

		private static double Multiplication(double num1, double num2)
		{
			return num1 * num2;
		}

		private static double Division(double num1, double num2)
		{
			if (num2 == 0)
				throw new DivideByZeroException();
			return num1 / num2;
		}
	}

	class SymbolException : ArithmeticException
	{
		public SymbolException() { }

		public SymbolException(string message) : base(message) { }

		public SymbolException(string message, Exception innerException) : base(message, innerException) { }

		[System.Security.SecuritySafeCritical]
		public SymbolException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
