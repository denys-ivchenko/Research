using System;
using System.Collections.ObjectModel;

namespace SoftInWay.Numerics
{
	public struct RadixBinary : IComparable, IFormattable, IComparable<RadixBinary>, IEquatable<RadixBinary>
	{
		#region Private declarations

		private Radix _value;

		#endregion

		#region Constructors

		static RadixBinary()
		{
			Symbols = new ReadOnlyCollection<string>(new string[] { "0", "1" });
		}

		public RadixBinary(string value)
		{
			_value = new Radix(Symbols, value);
		}

		public RadixBinary(long value)
		{
			_value = new Radix(Symbols, value);
		}

		public RadixBinary(short value)
			: this((long)value)
		{ }

		public RadixBinary(ushort value)
			: this((long)value)
		{ }

		public RadixBinary(int value)
			: this((long)value)
		{ }

		public RadixBinary(uint value)
			: this((long)value)
		{ }

		//public Radix2(ulong value)
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

		public int CompareTo(RadixBinary other)
		{
			return _value.CompareTo(other);
		}

		public bool Equals(RadixBinary other)
		{
			return _value.Equals(other);
		}

		#endregion
	}
}
