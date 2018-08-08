using Sms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sms.IletiMerkezi
{
	public class SmsClient : ISmsClient
	{
		private readonly HttpClient client;
		private readonly string sender;
		private readonly Models.QueryRequest.Authentication authentication;

		public SmsClient(string username, string password, string sender)
		{
			client = new HttpClient()
			{
				BaseAddress = new Uri("http://api.iletimerkezi.com/v1/")
			};
			authentication = new Models.QueryRequest.Authentication()
			{
				Username = username,
				Password = password
			};
			this.sender = sender;
		}
		public async Task<string> SendAsync(string message, string phone)
		{
			Models.SendMessageRequest.Request request = new Models.SendMessageRequest.Request
			{
				Authentication = new Models.SendMessageRequest.Authentication()
				{
					Password = authentication.Password,
					Username = authentication.Username
				},
				Order = new Models.SendMessageRequest.Order()
				{
					Sender = this.sender,
					Message = new Models.SendMessageRequest.Message()
					{
						Receipents = new Models.SendMessageRequest.Receipents() { Number = new List<string>() { phone } },
						MessageText = message
					}
				}
			};

			Utility.XmlSerializer xmlSerializer = new Utility.XmlSerializer();
			string xml = xmlSerializer.Serialize(request);
			xml = xml.Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "");
			var response = await client.PostAsync("send-sms", new StringContent(xml, Encoding.UTF8, "application/xml"));

			string responseXml = await response.Content.ReadAsStringAsync();

			Models.SendMessageResponse.Response rsp = xmlSerializer.Deserialize<Models.SendMessageResponse.Response>(responseXml);

			if (!Utility.StatusResolver.IsSuccess(rsp.Status.Code))
			{
				throw new SmsException(Utility.StatusResolver.GetDescription(rsp.Status.Code));
			}


			return rsp.Order.Id.ToString();
		}
		public async Task<string> GetSmsStatusAsync(string messageId)
		{
			Models.QueryRequest.Request request = new Models.QueryRequest.Request()
			{
				Authentication = authentication,
				Order = new Models.QueryRequest.Order()
				{
					Id = messageId
				}
			};

			Utility.XmlSerializer xmlSerializer = new Utility.XmlSerializer();
			string xml = xmlSerializer.Serialize(request);
			xml = xml.Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "");

			var response = await client.PostAsync("get-report", new StringContent(xml, Encoding.UTF8, "application/xml"));

			string responseXml = await response.Content.ReadAsStringAsync();

			Models.QueryResponse.Response rsp = xmlSerializer.Deserialize<Models.QueryResponse.Response>(responseXml);
			return rsp.Status.Message;
		}
		public async Task<string> GetBalanceAsync()
		{
			Models.QueryRequest.BalanceRequest request = new Models.QueryRequest.BalanceRequest()
			{
				Authentication = authentication
			};

			Utility.XmlSerializer xmlSerializer = new Utility.XmlSerializer();
			string xml = xmlSerializer.Serialize(request);
			xml = xml.Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "");
			var response = await client.PostAsync("get-balance", new StringContent(xml, Encoding.UTF8, "application/xml"));

			string responseXml = await response.Content.ReadAsStringAsync();

			Models.QueryResponse.BalanceResponse rsp = xmlSerializer.Deserialize<Models.QueryResponse.BalanceResponse>(responseXml);

			if (!Utility.StatusResolver.IsSuccess(int.Parse(rsp.Status.Code)))
			{
				throw new SmsException(Utility.StatusResolver.GetDescription(int.Parse(rsp.Status.Code)));
			}

			return rsp.Balance.Sms.ToString();
		}
	}
}
