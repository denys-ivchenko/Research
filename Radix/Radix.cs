using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;

namespace SoftInWay.Numerics
{
	[Serializable]
	[ComVisible(true)]
	public struct Radix : IComparable, IFormattable, IComparable<Radix>, IEquatable<Radix>
	{
		#region Constructors

		#region 0

		public Radix(int radix)
			: this(radix, null as string[], 0)
		{ }

		public Radix(string symbols)
			: this(0, (from item in symbols select item.ToString()).ToArray(), 0)
		{ }

		public Radix(string[] symbols)
			: this(0, symbols, 0)
		{ }

		public Radix(ReadOnlyCollection<string> symbols)
			: this(0, symbols, 0)
		{ }

		private Radix(int radix, ReadOnlyCollection<string> symbols)
		{
			ValueSymbols = null;

			Value = 0;

			SymbolLength = Magnitude = 1;

			Visual = null;//buildVisual(Symbols, value);

			CaseSensitive = false;

			if (radix == 0 && (symbols == null || symbols.Count < 2))
				throw new RadixDimensionException();

			if (radix != 0 && symbols != null && symbols.Count != radix)
				throw new RadixDimensionException();

			Base = radix == 0 ? symbols.Count : radix;

			if (symbols != null && symbols.Count != 0)
			{
				SymbolLength = symbols[0].Length;

				foreach (var symbol in symbols)
					if (symbol.Length != SymbolLength)
						throw new RadixSymbolLengthException();
			}
			else
			{
				symbols = buildSymbols(radix);

				SymbolLength = symbols[0].Length;
			}

			Symbols = new ReadOnlyCollection<string>((from item in symbols select item.ToString()).ToArray());
		}

		#endregion

		#region BigInteger

		public Radix(int radix, long value)
			: this(radix, null as string[], value)
		{ }

		public Radix(string symbols, long value)
			: this(0, symbols, value)
		{ }

		public Radix(string[] symbols, long value)
			: this(new ReadOnlyCollection<string>(symbols), value)
		{ }

		public Radix(ReadOnlyCollection<string> symbols, long value)
			: this(0, symbols, value)
		{ }

		private Radix(int radix, string symbols, long value)
			: this(radix, (from item in symbols select item.ToString()).ToArray(), value)
		{ }

		private Radix(int radix, string[] symbols, long value)
			: this(radix, new ReadOnlyCollection<string>(symbols), value)
		{ }

		private Radix(int radix, ReadOnlyCollection<string> symbols, long value)
			: this(radix, symbols)
		{
			Symbols = symbols;

			ValueSymbols = default(ReadOnlyCollection<string>);

			Magnitude = SymbolLength = 1;

			Value = value;

			Visual = buildVisual(Symbols, value);

			Magnitude = Visual.Length / Symbols[0].Length;
		}

		#endregion

		#region string

		public Radix(int radix, string value)
			: this(radix, null as string[], value)
		{ }

		public Radix(string symbols, string value)
			: this(0, symbols, value)
		{ }

		public Radix(string[] symbols, string value)
			: this(new ReadOnlyCollection<string>(symbols), value)
		{ }

		public Radix(ReadOnlyCollection<string> symbols, string value)
			: this(0, symbols, value)
		{ }

		private Radix(int radix, string symbols, string value)
			: this(radix, symbols == null ? null : (from item in symbols select item.ToString()).ToArray(), value)
		{ }

		private Radix(int radix, string[] symbols, string value)
			: this(radix, new ReadOnlyCollection<string>(symbols), value)
		{ }

		private Radix(int radix, ReadOnlyCollection<string> symbols, string value)
			: this(radix, symbols)
		{
			Value = parseValue(Symbols, value);

			Visual = CaseSensitive ? value : value.ToUpper();

			Magnitude = Visual.Length / 2;
		}

		#endregion

		#region short

		//public Radix(int radix, short value)
		//	: this(radix, null as string[], new BigInteger(value))
		//{ }

		//public Radix(string symbols, short value)
		//	: this(0, symbols, new BigInteger(value))
		//{ }

		//public Radix(string[] symbols, short value)
		//	: this(0, symbols, new BigInteger(value))
		//{ }

		//public Radix(int radix, string symbols, short value)
		//	: this(radix, symbols, new BigInteger(value))
		//{ }

		//public Radix(int radix, string[] symbols, short value)
		//	: this(radix, symbols, new BigInteger(value))
		//{ }

		#endregion

		#region ushort

		//public Radix(int radix, ushort value)
		//	: this(radix, null as string[], new BigInteger(value))
		//{ }

		//public Radix(string symbols, ushort value)
		//	: this(0, symbols, new BigInteger(value))
		//{ }

		//public Radix(string[] symbols, ushort value)
		//	: this(0, symbols, new BigInteger(value))
		//{ }

		//public Radix(int radix, string symbols, ushort value)
		//	: this(radix, symbols, new BigInteger(value))
		//{ }

		//public Radix(int radix, string[] symbols, ushort value)
		//	: this(radix, symbols, new BigInteger(value))
		//{ }

		#endregion

		#region int

		public Radix(int radix, int value)
			: this(radix, null as string[], value)
		{ }

		public Radix(string symbols, int value)
			: this(0, symbols, value)
		{ }

		public Radix(string[] symbols, int value)
			: this(0, symbols, value)
		{ }

		//public Radix(int radix, string symbols, int value)
		//	: this(radix, symbols, new BigInteger(value))
		//{ }

		//public Radix(int radix, string[] symbols, int value)
		//	: this(radix, symbols, new BigInteger(value))
		//{ }

		#endregion

		#region uint

		public Radix(int radix, uint value)
			: this(radix, null as string[], value)
		{ }

		public Radix(string symbols, uint value)
			: this(0, symbols, value)
		{ }

		public Radix(string[] symbols, uint value)
			: this(0, symbols, value)
		{ }

		//public Radix(int radix, string symbols, uint value)
		//	: this(radix, symbols, new BigInteger(value))
		//{ }

		//public Radix(int radix, string[] symbols, uint value)
		//	: this(radix, symbols, new BigInteger(value))
		//{ }

		#endregion

		#region long

		//public Radix(int radix, long value)
		//	: this(radix, null as string[], new BigInteger(value))
		//{ }

		//public Radix(string symbols, long value)
		//	: this(0, symbols, new BigInteger(value))
		//{ }

		//public Radix(string[] symbols, long value)
		//	: this(0, symbols, new BigInteger(value))
		//{ }

		//public Radix(int radix, string symbols, long value)
		//	: this(radix, symbols, new BigInteger(value))
		//{ }

		//public Radix(int radix, string[] symbols, long value)
		//	: this(radix, symbols, new BigInteger(value))
		//{ }

		#endregion

		#region ulong

		//public Radix(int radix, ulong value)
		//	: this(radix, null as string[], new BigInteger(value))
		//{ }

		//public Radix(string symbols, ulong value)
		//	: this(0, symbols, new BigInteger(value))
		//{ }

		//public Radix(string[] symbols, ulong value)
		//	: this(0, symbols, new BigInteger(value))
		//{ }

		//public Radix(int radix, string symbols, ulong value)
		//	: this(radix, symbols, new BigInteger(value))
		//{ }

		//public Radix(int radix, string[] symbols, ulong value)
		//	: this(radix, symbols, new BigInteger(value))
		//{ }

		#endregion

		#endregion

		#region Public properties

		public int Base { get; }

		public ReadOnlyCollection<string> Symbols { get; }

		public ReadOnlyCollection<string> ValueSymbols { get; }

		public long Value { get; }

		public string Visual { get; }

		public int SymbolLength { get; }

		public int Magnitude { get; private set; }

		public bool CaseSensitive { get; private set; }

		#endregion

		#region Public methods

		public int CompareTo(object? obj)
		{
			return Value.CompareTo(obj);
		}

		public string ToString(IFormatProvider format)
		{
			return Visual.ToString(format);
		}

		public string ToString(string? format, IFormatProvider? formatProvider)
		{
			return Value.ToString(format, formatProvider)?.Replace($"{Value}", Visual);
		}

		public TypeCode GetTypeCode()
		{
			return TypeCode.String;
		}

		public int CompareTo(Radix other)
		{
			return Value.CompareTo(other);
		}

		public bool Equals(Radix other)
		{
			return Value.Equals(other);
		}

		#endregion

		#region Overrided methods

		public override string ToString()
		{
			return Visual;
		}

		#endregion

		#region Private methods

		private static ReadOnlyCollection<string> buildSymbols(int radix)
		{
			if (radix < 11)
				return new ReadOnlyCollection<string>((from item in RadixSymbols.DIGITS.Substring(0, radix) select $"{item}").ToArray());

			if (radix < 26)
				return new ReadOnlyCollection<string>((from item in RadixSymbols.DIGITS + RadixSymbols.ALPHABET.Substring(0, radix - 10) select $"{item}").ToArray());

			if (radix == 26)
				return new ReadOnlyCollection<string>((from item in RadixSymbols.ALPHABET select $"{item}").ToArray());

			if (radix < 37)
				return new ReadOnlyCollection<string>((from item in RadixSymbols.DIGITS.Substring(0, radix - 26) + RadixSymbols.ALPHABET.Substring(0, radix - 10) select $"{item}").ToArray());

			return new ReadOnlyCollection<string>((from item in RadixSymbols.DIGITS + RadixSymbols.ALPHABET select $"{item}").ToArray());
		}

		private long parseValue(ReadOnlyCollection<string> symbols, string visual)
		{
			var symbolLength = symbols[0].Length;

			long value = 0;

			string symbol = null;

			for (var i = 0; i < visual.Length - symbolLength; i += symbolLength)
			{
				symbol = visual.Substring(i, symbolLength);

				var index = symbols.IndexOf(CaseSensitive ? symbol : symbol.ToUpper());

				if (index == -1)
					throw new RadixStringValueException();

				var pow = ((visual.Length - i) / symbolLength) - 1;

				value += (long)Math.Pow(symbols.Count, pow) * index;
			}

			symbol = visual.Substring(visual.Length - symbolLength, symbolLength);

			return value + symbols.IndexOf(CaseSensitive ? symbol : symbol.ToUpper());
		}

		private string buildVisual(ReadOnlyCollection<string> symbols, BigInteger value)
		{
			var magnitude = 1;
			var visual = "";

			while (value > (BigInteger.Pow(symbols.Count, magnitude) - 1))
				magnitude++;

			for (var i = magnitude; i > 1; i--)
			{
				int index = (int)(value / BigInteger.Pow(symbols.Count, i - 1));
				value = value % BigInteger.Pow(symbols.Count, i - 1);

				visual = $"{visual}{symbols[index]}";
			}

			visual = $"{visual}{symbols[(int)value]}";

			return CaseSensitive ? visual : visual.ToUpper();
		}

		#endregion

		#region Single

		//public struct RadixSingle
		//{
		//	internal RadixSingle(ReadOnlyCollection<string> symbols, int value)
		//	{
		//		if (value >= symbols.Count)
		//			throw new RadixDimensionException();

		//		Value = value;
		//		Visual = symbols[value];
		//	}

		//	internal RadixSingle(ReadOnlyCollection<string> symbols, string value)
		//	{
		//		if (value == null || value.Length != symbols[0].Length)
		//			throw new RadixDimensionException();

		//		Visual = value;
		//		Value = symbols.IndexOf(value);
		//	}

		//	public int Value { get; }

		//	public string Visual { get; }
		//}

		#endregion
	}
}
