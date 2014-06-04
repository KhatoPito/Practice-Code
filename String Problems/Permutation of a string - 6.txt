using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample_Code
{

	/// <summary>
	///  find FindPermutation  of a string
	/// </summary>
	class samplePracticeFindPermutation
	{
		static int length;

		public void FindPermutation(char[] array, int index)
		{

			if (index == length)
			{
				Console.Write(array);
				Console.WriteLine(" ");
			}
			else
			{
				for (int i = index; i <= length; i++)
				{
					swap(ref array[i], ref array[index]);
					FindPermutation(array, index+1);
					swap(ref array[i], ref array[index]);
				}		
			}
		}

		public void swap(ref char a, ref char b)
		{
			if (a == b) return;
			a ^= b;
			b ^= a;
			a ^= b;
		}

		static void Main(string[] args)
		{
			samplePracticeFindPermutation obj = new samplePracticeFindPermutation();
			string temp = "ABC";
			length = temp.Length -1;
			char[] array = temp.ToCharArray();

			obj.FindPermutation(array, 0);
			Console.ReadLine();
		}
	}          

}
