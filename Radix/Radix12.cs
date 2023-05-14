using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace SoftInWay.Numerics
{
	public struct Radix12 : IComparable, IFormattable, IComparable<Radix12>, IEquatable<Radix12>
	{
		#region Private declarations

		private Radix _value;

		#endregion

		#region Constructors

		static Radix12()
		{
			Symbols = new ReadOnlyCollection<string>((from item in (RadixSymbols.DIGITS + "AB") select $"{item}").ToArray());
		}

		public Radix12(string value)
		{
			_value = new Radix(Symbols, value);
		}

		public Radix12(long value)
		{
			_value = new Radix(Symbols, value);
		}

		public Radix12(short value)
			: this((long)value)
		{ }

		public Radix12(ushort value)
			: this((long)value)
		{ }

		public Radix12(int value)
			: this((long)value)
		{ }

		public Radix12(uint value)
			: this((long)value)
		{ }

		//public Radix12(long value)
		//	: this(new BigInteger(value))
		//{ }

		//public Radix12(ulong value)
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

		public int CompareTo(Radix12 other)
		{
			return _value.CompareTo(other);
		}

		public bool Equals(Radix12 other)
		{
			return _value.Equals(other);
		}

		#endregion
	}
}
