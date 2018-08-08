using System;
using System.Threading.Tasks;

namespace Sms
{
	public interface ISmsClient
	{
		Task<string> SendAsync(string message, string phone);
		Task<string> GetSmsStatusAsync(string messageId);
		Task<string> GetBalanceAsync();
	}
}
