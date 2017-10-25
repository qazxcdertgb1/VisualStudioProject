using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace Test_Project_Script.Scripts
{
	class HashDemo
	{
		public void Run()
		{
			Hashtable ht = new Hashtable();
			ht.Add(1, "abc");
			ht.Add(2, "def");
			ht.Add(4, "ghi");
			ht.Add(5, "jkl");
			ht.Add(6, "mno");
			ht.Add(7, "pqr");

			foreach(DictionaryEntry dt in ht)
			{
				Console.WriteLine(dt.Key + ".." + dt.Value);
			}
			Console.WriteLine("-------------------");

			DictionaryEntry dt2 = new DictionaryEntry();

			for (int i=0;i<=ht.Count;i++)
			{
				Console.WriteLine(dt2 = (DictionaryEntry)ht[1]);
			}

		}
	}
}

/* 
 * 1/2	X2
 * 1/4	X4		3/4 + 1/4
 *				3/8 3/8 1/4
 * 1/8
 * 1/16
 * 1/32
 * 1/64
 * 
 */
