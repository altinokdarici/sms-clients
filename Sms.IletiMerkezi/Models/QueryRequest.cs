using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sms.IletiMerkezi.Models.QueryRequest
{

	[XmlRoot(ElementName = "authentication")]
	public class Authentication
	{
		[XmlElement(ElementName = "username")]
		public string Username { get; set; }
		[XmlElement(ElementName = "password")]
		public string Password { get; set; }
	}

	[XmlRoot(ElementName = "order")]
	public class Order
	{
		[XmlElement(ElementName = "id")]
		public string Id { get; set; }

	}

	[XmlRoot(ElementName = "request")]
	public class Request
	{
		[XmlElement(ElementName = "authentication")]
		public Authentication Authentication { get; set; }
		[XmlElement(ElementName = "order")]
		public Order Order { get; set; }
	}
	[XmlRoot(ElementName = "request")]
	public class BalanceRequest
	{
		[XmlElement(ElementName = "authentication")]
		public Authentication Authentication { get; set; }
	}
}
