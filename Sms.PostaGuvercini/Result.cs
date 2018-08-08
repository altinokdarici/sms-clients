using System.Collections.Generic;

namespace Sms.PostaGuvercini
{
	public class Result
	{
		public Result()
		{
			Items = new Dictionary<string, string>();
		}
		public int ErrorCode { get; set; }
		public string ErrorText { get; set; }
		public Dictionary<string, string> Items { get; set; }

	}
}
