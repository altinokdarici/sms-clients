namespace Sms.PostaGuvercini
{
	public class SmsSettings
	{
		public string Url { get; set; }

		public string UserName { get; set; }
		public string Password { get; set; }

		public SmsSettings()
		{
			Url = "http://www.postaguvercini.com";
		}
	}
}
