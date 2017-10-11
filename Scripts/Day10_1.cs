using System;


namespace ScriptTest
{
	public class Day10_1
	{

		public void Run()
		{
			string m_str = "//aaa \nstatic void Main(string[] args)  //aaaa \n{\n  int a = 10 / 2;\n  /***aaa\n  aaa\n  ***/\n}";
			int stat = 0;
			for (int i = 0; i < m_str.Length; i++)
			{
				switch (stat)
				{
					case 0:
						if (m_str[i] == '/')
						{
							stat = 1;
						}
						else if (m_str[i] == ' ')
						{
							stat = 4;
							Console.Write(m_str[i]);
						}
						else
						{
							Console.Write(m_str[i]);
						}
						break;
					case 1:
						if (m_str[i] == '/')
						{
							stat = 2;
						}
						else if (m_str[i] == '*')
						{
							stat = 3;
						}
						else
						{
							stat = 0;
							i--;
							Console.Write('/');
						}
						break;
					case 2:
						if (m_str[i] == '\n')
						{
							stat = 0;
							Console.Write(m_str[i]);
						}
						break;
					case 3:
						if (m_str[i] == '*' && m_str[i + 1] == '/')
						{
							stat = 0;
							i++;
						}
						break;
					case 4:
						if (m_str[i] != ' ')
						{
							stat = 0;
							i--;
						}
						break;
					default:
						break;
				}
			}
			Console.WriteLine();
		}
	}
}

