using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace SoftInWay.Numerics
{
	public struct Radix24 : IComparable, IFormattable, IComparable<Radix24>, IEquatable<Radix24>
	{
		#region Private declarations

		private Radix _value;

		#endregion

		#region Constructors

		static Radix24()
		{
			Symbols = new ReadOnlyCollection<string>((from item in ("X" + RadixSymbols.ALPHABET.Substring(0, 23)) select $"{item}").ToArray<string>());
		}

		public Radix24(string value)
		{
			_value = new Radix(Symbols, value);
		}

		public Radix24(long value)
		{
			_value = new Radix(Symbols, value);
		}

		public Radix24(short value)
			: this((long)value)
		{ }

		public Radix24(ushort value)
			: this((long)value)
		{ }

		public Radix24(int value)
			: this((long)value)
		{ }

		public Radix24(uint value)
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

		public int CompareTo(Radix24 other)
		{
			return _value.CompareTo(other._value);
		}

		public bool Equals(Radix24 other)
		{
			return _value.Equals(other._value);
		}

		#endregion
	}
}
