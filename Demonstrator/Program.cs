using System;

namespace SoftInWay.Numerics
{
	class Program
	{
		static void Main(string[] args)
		{
			Radix24 radix24 = new(237143);
			
			Console.WriteLine($"r24\t{radix24.Value.ToString("### ### ### ### ###").Trim()} = {radix24.Visual}");

			//Console.ReadLine();

			var radix24Value = new Radix24("XXQCPW");
			
			Console.WriteLine($"r24\t{radix24Value} = {radix24Value.Value.ToString("### ### ### ### ###").Trim()}");

			//Console.ReadLine();

			var radix24Value2 = new Radix24("WKKSAGAE");
			
			Console.WriteLine($"r24\t{radix24Value2} = {radix24Value2.Value.ToString("### ### ### ### ###").Trim()}");

			Radix26 radix26 = new(237143);

			Console.WriteLine($"r26\t{radix26.Value.ToString("### ### ### ### ###").Trim()} = {radix26.Visual}");

			var radix26Value = new Radix26($"ZZZ{radix26.Visual}");
			
			Console.WriteLine($"r26\t{radix26Value} = {radix26Value.Value.ToString("### ### ### ### ###").Trim()}");

			//Console.ReadLine();

			var radix26Value2 = new Radix26("WKKSAGAE");
			
			Console.WriteLine($"r26\t{radix26Value2} = {radix26Value2.Value.ToString("### ### ### ### ###").Trim()}");

			Console.WriteLine();

			Console.WriteLine("WARNING! Don`t enter next numeric values: 7 694 480 and 4 031 315.");

			Console.WriteLine();

			//while(true)
			//{
			//	Console.Write($"Please enter radix24 numeric/text value for display reciprocal value: ");
				
			//	var input = Console.ReadLine();

			//	if (long.TryParse(input.Replace(" ", "").Trim(), out long value))
			//	{
			//		var radix = new Radix24(value);

			//		Console.WriteLine($"Radix24 value: {radix.Value.ToString("### ### ### ### ###").Trim()} = {radix.Visual}");
			//	}
			//	else
			//	{
			//		var radix = default(Radix24);

			//		bool failed = false;
					
			//		try { radix = new Radix24(input.Replace(" ", "").Trim()); }
			//		catch { failed = true; }

			//		Console.WriteLine(failed ? "Input string is failed Radix24 value!" : $"Radix24 string: {radix.Visual} = {radix.Value.ToString("### ### ### ### ###").Trim()}");
			//	}

			//	Console.WriteLine();
			//}

			while (true)
			{
				Console.Write($"Please enter radix26 numeric/text value for display reciprocal value: ");

				var input = Console.ReadLine();

				if (long.TryParse(input.Replace(" ", "").Trim(), out long value))
				{
					var radix = new Radix26(value);

					Console.WriteLine($"Radix26 value: {radix.Value.ToString("### ### ### ### ###").Trim()} = {radix.Visual}");
				}
				else
				{
					var radix = default(Radix26);

					bool failed = false;

					try { radix = new Radix26(input.Replace(" ", "").Trim()); }
					catch { failed = true; }

					Console.WriteLine(failed ? "Input string is failed Radix26 value!" : $"Radix26 string: {radix.Visual} = {radix.Value.ToString("### ### ### ### ###").Trim()}");
				}

				Console.WriteLine();
			}
		}
	}
}
