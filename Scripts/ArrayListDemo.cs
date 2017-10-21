using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace Test_Project_Script.Scripts
{
	class ArrayListDemo
	{
		
		private ArrayList arrListClone;

		public void Run()
		{
			ArrayList arrList = ArrayCreate();

			ArrOutput(arrList);
		}

		private ArrayList ArrayCreate()
		{
			ArrayList arrList = new ArrayList(16)
			{
				new string[] { "name", "arrList" },
				"fklsadfjldksajfl",
				20,
				30,
				40,
				Math.PI,
				new ScriptTest.CalculatorInside(),
				new int[] { 1, 2, 3 }
			};
			arrList.Add('A');
			return arrList;
		}

		public void ArrOutput(ArrayList arrList)
		{
			int[] arrInt = new int[3];

			ArrShow(arrList, "arrList");

			Console.WriteLine("\narrList内的数组元素int[] {{1,2,3}}中的元素[1]输出: \n{0}\n",((int[])arrList[7])[1]);
			Console.WriteLine("\narrList的克隆arrListClone: ");

			arrListClone = (ArrayList)arrList.Clone();

			ArrShow(arrListClone, "arrListClone");

			Console.WriteLine("\n清空arrListClone: ");
			arrListClone.Clear();
			ArrShow(arrListClone, "arrListClone");

			Console.WriteLine("\n将2-4的元素复制到int数组arrInt中: ");

			arrList.CopyTo(2, arrInt, 0, 3);

			Console.WriteLine("int数组arrInt内的元素: \n");
			foreach (int output in arrInt)
			{
				Console.WriteLine(output);
			}

			Console.WriteLine("\n查找40所在的位置: ");
			Console.WriteLine("IndexOf:	角标: {0} ,位置: {1}",arrList.IndexOf(40), arrList.IndexOf(40)+1);
			Console.WriteLine("LastIndexOf:	角标: {0} ,位置: {1}", arrList.LastIndexOf(40), arrList.LastIndexOf(40)+1);
			Console.WriteLine("BinarySearch:	角标: {0} ,位置: {1}", arrList.BinarySearch(40), arrList.BinarySearch(40) + 1);

			Console.WriteLine("\n将\"123456\"插入到角标3: ");
			arrList.Insert(3, 123456);

			ArrShow(arrList,"arrList");

			Console.WriteLine("\n再将角标3的元素移除: ");
			arrList.RemoveAt(3);

			ArrShow(arrList, "arrList");

			Console.WriteLine("\n将arrList元素的位置反转: ");
			arrList.Reverse();

			ArrShow(arrList, "arrList");

			Console.WriteLine("比较arrList和arrListClone是否相等: {0}",arrList.Equals(arrListClone));

			arrListClone = (ArrayList)arrList.Clone();

			Console.WriteLine("\n将arrList复制给arrListClone再比较: {0}",arrList.Equals(arrListClone));

			Console.WriteLine("\n将arrList的最大元素数设置为实际的元素数");
			arrList.TrimToSize();

			ArrShow(arrList,"arrList");

			arrListClone.SetRange(0,arrList);

			Console.WriteLine("\n比较arrList和arrListClone是否相等: {0}\n", arrList.Equals(arrListClone));

			ArrShow(arrList,"arrList");
			Console.WriteLine();
			ArrShow(arrListClone, "arrListClone");

		}
		
		public void ArrShow(ArrayList arrListInside,string arrName)
		{
			Console.WriteLine("集合{0}内的元素数: {1}",arrName, arrListInside.Count);
			Console.WriteLine("集合{0}内最大的元素数: {1}", arrName, arrListInside.Capacity);
			Console.WriteLine("集合{0}内的元素: \n",arrName);
			foreach (object output in arrListInside)
			{
				Console.WriteLine(output);
			}
		}
	}
}
