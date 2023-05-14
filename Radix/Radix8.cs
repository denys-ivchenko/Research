using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace SoftInWay.Numerics
{
	public struct Radix8 : IComparable, IFormattable, IComparable<Radix8>, IEquatable<Radix8>
	{
		#region Private declarations

		private Radix _value;

		#endregion

		#region Constructors

		static Radix8()
		{
			Symbols = new ReadOnlyCollection<string>((from item in (RadixSymbols.DIGITS.Substring(0, 8)) select $"{item}").ToArray<string>());
		}

		public Radix8(string value)
		{
			_value = new Radix(Symbols, value);
		}

		public Radix8(long value)
		{
			_value = new Radix(Symbols, value);
		}

		public Radix8(short value)
			: this((long)value)
		{ }

		public Radix8(ushort value)
			: this((long)value)
		{ }

		public Radix8(int value)
			: this((long)value)
		{ }

		public Radix8(uint value)
			: this((long)value)
		{ }

		//public Radix8(long value)
		//	: this(new BigInteger(value))
		//{ }

		//public Radix8(ulong value)
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

		public int CompareTo(Radix8 other)
		{
			return _value.CompareTo(other);
		}

		public bool Equals(Radix8 other)
		{
			return _value.Equals(other);
		}

		#endregion
	}
}
