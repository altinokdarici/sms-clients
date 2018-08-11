using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sms.PostaGuvercini
{
	public class SmsClient : ISmsClient
	{
		private readonly HttpClient httpClient;
		private readonly SmsSettings smsSettings;
		private string Credentials => $"user={smsSettings.UserName}&password={smsSettings.Password}";

		public SmsClient(SmsSettings smsSettings)
		{
			httpClient = new HttpClient()
			{
				BaseAddress = new Uri(smsSettings.Url+ "/api_http/")
			};
			this.smsSettings = smsSettings;
		}

		public async Task<string> SendAsync(string message, string phone)
		{
			var response = await httpClient.GetStringAsync($"sendsms.asp?{Credentials}&gsm={phone}&text={message}");
			var result = GetResult(response);
			EnsureSuccess(result);

			return result.Items["message_id"];
		}

		public async Task<string> GetSmsStatusAsync(string messageId)
		{
			var response = await httpClient.GetStringAsync($"querysms.asp?{Credentials}&message_id={messageId}");
			var result = GetResult(response);
			EnsureSuccess(result);

			return result.Items["status"];
		}

		public async Task<string> GetBalanceAsync()
		{
			var response = await httpClient.GetStringAsync($"querycredit.asp?{Credentials}");
			var result = GetResult(response);
			EnsureSuccess(result);

			return result.Items["credit"];
		}

		private Result GetResult(string response)
		{
			var splitted = response.Split('&').ToDictionary(x => x.Split('=').First(), x => x.Split('=').Last());

			return new Result()
			{
				ErrorCode = int.Parse(splitted["errno"]),
				ErrorText = splitted["errtext"],
				Items = splitted
			};
		}
		private void EnsureSuccess(Result result)
		{
			if (result.ErrorCode != 0)
			{
				throw new SmsException($"{result.ErrorCode}-{result.ErrorText}");
			}
		}

	}
}
