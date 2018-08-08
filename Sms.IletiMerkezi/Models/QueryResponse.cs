using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sms.IletiMerkezi.Models.QueryResponse
{

	[XmlRoot(ElementName = "status")]
	public class Status
	{
		[XmlElement(ElementName = "code")]
		public string Code { get; set; }
		[XmlElement(ElementName = "message")]
		public string Message { get; set; }
	}

	[XmlRoot(ElementName = "message")]
	public class Message
	{
		[XmlElement(ElementName = "number")]
		public string Number { get; set; }
		[XmlElement(ElementName = "status")]
		public string Status { get; set; }
	}

	[XmlRoot(ElementName = "order")]
	public class Order
	{
		[XmlElement(ElementName = "message")]
		public Message Message { get; set; }
	}

	[XmlRoot(ElementName = "response")]
	public class Response
	{
		[XmlElement(ElementName = "status")]
		public Status Status { get; set; }
		[XmlElement(ElementName = "order")]
		public Order Order { get; set; }
	}
	[XmlRoot(ElementName = "response")]
	public class BalanceResponse
	{
		[XmlElement(ElementName = "status")]
		public Status Status { get; set; }
		[XmlElement(ElementName = "balance")]
		public Balance Balance { get; set; }
	}
	public class Balance
	{
		[XmlElement(ElementName = "sms")]
		public int Sms { get; set; }
	}
}
