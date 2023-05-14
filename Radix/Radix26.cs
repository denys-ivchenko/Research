using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace SoftInWay.Numerics
{
	public struct Radix26 : IComparable, IFormattable, IComparable<Radix26>, IEquatable<Radix26>
	{
		#region Private declarations

		private Radix _value;

		#endregion

		#region Constructors

		static Radix26()
		{
			Symbols = new ReadOnlyCollection<string>((from item in ("Z" + RadixSymbols.ALPHABET.Substring(0, 25)) select $"{item}").ToArray<string>());
		}

		public Radix26(string value)
		{
			_value = new Radix(Symbols, value);
		}

		public Radix26(long value)
		{
			_value = new Radix(Symbols, value);
		}

		public Radix26(short value)
			: this((long)value)
		{ }

		public Radix26(ushort value)
			: this((long)value)
		{ }

		public Radix26(int value)
			: this((long)value)
		{ }

		public Radix26(uint value)
			: this((long)value)
		{ }

		//public Radix24(long value)
		//	: this(new BigInteger(value))
		//{ }

		//public Radix24(ulong value)
		//	: this(new BigInteger(value))
		//{ }

		#endregion

		#region Public properties

		//public ReadOnlyCollection<string> Symbols { get => _value.Symbols; }

		public long Value { get => _value.Value; }

		public string Visual { get => _value.Visual; }

		#endregion

		#region Internal properties

		public static ReadOnlyCollection<string> Symbols { get; }

		#endregion

		#region Public methods

		public int CompareTo(object? obj)
		{
			return _value.CompareTo(obj);
		}

		public string ToString(string? format, IFormatProvider? formatProvider)
		{
			return _value.ToString(format, formatProvider);
		}

		public TypeCode GetTypeCode()
		{
			return TypeCode.String;
		}

		public int CompareTo(Radix26 other)
		{
			return _value.CompareTo(other._value);
		}

		public bool Equals(Radix26 other)
		{
			return _value.Equals(other._value);
		}

		#endregion
	}
}
