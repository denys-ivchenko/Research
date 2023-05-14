using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Numerics;

namespace SoftInWay.Numerics
{
	public struct RadixByte : IComparable, IFormattable, IComparable<RadixByte>, IEquatable<RadixByte>
	{
		#region Private declarations

		private BigRadix _value;

		#endregion

		#region Constructors

		static RadixByte()
		{
			var symbols = new List<string>();

			for (var i = 0; i < RadixSymbols.ALPHABET.Length; i++)
				for (var j = 0; j < (i == RadixSymbols.ALPHABET.Length - 1 ? 6 : 10); j++)
					symbols.Add($"{RadixSymbols.ALPHABET[i]}{j}");

			Symbols = new ReadOnlyCollection<string>(symbols);
		}

		public RadixByte(string value)
		{
			_value = new BigRadix(Symbols, value);
		}

		public RadixByte(BigInteger value)
		{
			_value = new BigRadix(Symbols, value);
		}

		public RadixByte(byte value)
			: this(new BigInteger(value))
		{ }

		public RadixByte(sbyte value)
			: this(new BigInteger(value))
		{ }

		public RadixByte(short value)
			: this(new BigInteger(value))
		{ }

		public RadixByte(ushort value)
			: this(new BigInteger(value))
		{ }

		public RadixByte(int value)
			: this(new BigInteger(value))
		{ }

		public RadixByte(uint value)
			: this(new BigInteger(value))
		{ }

		public RadixByte(long value)
			: this(new BigInteger(value))
		{ }

		public RadixByte(ulong value)
			: this(new BigInteger(value))
		{ }

		public RadixByte(byte[] value)
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

		public int CompareTo(RadixByte other)
		{
			return _value.CompareTo(other);
		}

		public bool Equals(RadixByte other)
		{
			return _value.Equals(other);
		}

		#endregion
	}
}
