using System;

namespace Zenject;

public class PoolExceededFixedSizeException : Exception
{
	public PoolExceededFixedSizeException(string errorMessage)
		: base(errorMessage)
	{
	}
}
