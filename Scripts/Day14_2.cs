using System;

namespace ScriptTest
{

	public class RunClass
	{
		private double[] arrDouble = new double[3];
		public void Run()
		{

			string strTemp;

			Console.Write("是否使用默认图形长度?\nY/N: ");
			strTemp = Console.ReadLine();

			Console.Clear();
			Console.Write("1. 圆形\n2. 矩形\n3. 正方形\n输入类型: ");

			if (strTemp == "y" || strTemp == "Y")
			{
				int i = Convert.ToInt32(Console.ReadLine());
				arrDouble = GetShape(i);
			}
			else
			{
				arrDouble = PrintIn();
			}
			PrintOut();
		}

		private double[] GetShape(int i)
		{
			for (;;)
			{
				switch (i)
				{
					case 1:
						arrDouble[0] = 0;
						arrDouble[1] = 1;
						break;
					case 2:
						arrDouble[0] = 1;
						arrDouble[1] = 3;
						arrDouble[2] = 4;
						break;
					case 3:
						arrDouble[0] = 2;
						arrDouble[1] = 2;
						break;
					default:
						continue;
				}
				return new MathCalculation().Calculation(arrDouble);
			}
		}

		private void PrintOut()
		{
			Console.Clear();

			string strTemp;

			switch(arrDouble[0])
			{
				case 0:
					strTemp = "圆形";
					break;
				case 1:
					strTemp = "矩形";
					break;
				case 2:
					strTemp = "正方形";
					break;
				default:
					throw new Exception();
			}

			Console.WriteLine("类型: {0}\n面积: {1}\n周长: {2}", strTemp, arrDouble[1], arrDouble[2]);
		}

		private double[] PrintIn()
		{
			arrDouble[0] = Convert.ToInt32(Console.ReadLine()) -1;

			if(arrDouble[0] == 0)
			{
				Console.Write("输入半径: ");
			}
			else
			{
				Console.Write("输入边长: ");
			}
			arrDouble[1] = Convert.ToInt32(Console.ReadLine());

			if(arrDouble[0] == 1)
			{
				Console.Write("输入边宽: ");
				arrDouble[2] = Convert.ToInt32(Console.ReadLine());
			}

			return new MathCalculation().Calculation(arrDouble);
		}
	}

	abstract class Geometry
	{
		protected int typeInt;
		protected int num1;
	}

	class Circle : Geometry
	{
		public Circle(int r)
		{
			num1 = r;
			typeInt = 0;
		}
	}

	class Rect : Geometry
	{
		private int h;

		public Rect(int l, int h)
		{
			num1 = l;
			typeInt = 1;
		}
	}

	class Square : Geometry
	{
		public Square(int l)
		{
			num1 = l;
			typeInt = 2;
		}
	}

	class MathCalculation
	{
		public double[] Calculation(double[] inArrDouble)
		{
			for (;;)
			{
				switch (inArrDouble[0])
				{
					case 0:
						return new double[] { inArrDouble[0], Math.PI * inArrDouble[1] * inArrDouble[1], Math.PI * inArrDouble[1] * 2 };
					case 1:
						return new double[] { inArrDouble[0], inArrDouble[1] * inArrDouble[2], inArrDouble[1] * 2 + inArrDouble[2] * 2 };
					case 2:
						return new double[] { inArrDouble[0], inArrDouble[1] * inArrDouble[1], inArrDouble[1] * 4 };
					default:
						throw new Exception();
				}
			}
		}
	}
}
