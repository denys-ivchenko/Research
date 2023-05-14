using System;

namespace SoftInWay.Numerics
{
	public class RadixDimensionException : ApplicationException
	{
		#region Constructors

		internal RadixDimensionException()
		{

		}

		#endregion

		#region Public properties

		public override string Message => "Radix dimension error!";

		#endregion
	}

	public class RadixSymbolLengthException : ApplicationException
	{
		#region Constructors

		internal RadixSymbolLengthException()
		{

		}

		#endregion

		#region Public properties

		public override string Message => "The input string cannot be converted as a Radix value!";

		#endregion
	}

	public class RadixStringValueException : FormatException
	{
		#region Constructors

		internal RadixStringValueException()
		{

		}

		#endregion

		#region Public properties

		public override string Message => "The input string is not a valid Radix value!";

		#endregion
	}
}
