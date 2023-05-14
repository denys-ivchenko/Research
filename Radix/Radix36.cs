using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;

namespace SoftInWay.Numerics
{
	public struct Radix36 : IComparable, IFormattable, IComparable<Radix36>, IEquatable<Radix36>
	{
		#region Private declarations

		private BigRadix _value;

		#endregion

		#region Constructors

		static Radix36()
		{
			Symbols = new ReadOnlyCollection<string>((from item in (RadixSymbols.DIGITS + RadixSymbols.ALPHABET) select $"{item}").ToArray<string>());
		}

		public Radix36(string value)
		{
			_value = new BigRadix(Symbols, value);
		}

		public Radix36(BigInteger value)
		{
			_value = new BigRadix(Symbols, value);
		}

		public Radix36(short value)
			: this(new BigInteger(value))
		{ }

		public Radix36(ushort value)
			: this(new BigInteger(value))
		{ }

		public Radix36(int value)
			: this(new BigInteger(value))
		{ }

		public Radix36(uint value)
			: this(new BigInteger(value))
		{ }

		public Radix36(long value)
			: this(new BigInteger(value))
		{ }

		public Radix36(ulong value)
			: this(new BigInteger(value))
		{ }

		#endregion

		#region Public properties

		//public ReadOnlyCollection<string> Symbols { get => _value.Symbols; }

		public BigInteger Value { get => _value.Value; }

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

		public int CompareTo(Radix36 other)
		{
			return _value.CompareTo(other);
		}

		public bool Equals(Radix36 other)
		{
			return _value.Equals(other);
		}

		#endregion
	}
}
