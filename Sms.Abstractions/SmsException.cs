using System;

namespace Sms
{
	public class SmsException : Exception
	{
		public SmsException(string message)
			: base(message)
		{

		}
		public SmsException(string message, Exception innerException)
			: base(message, innerException)
		{

		}
	}
}
