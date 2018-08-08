using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sms.IletiMerkezi.Utility
{
	internal class XmlSerializer
	{
		public string Serialize<T>(T obj)
		{
			System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(obj.GetType());

			using (StringWriter textWriter = new StringWriter())
			{
				xmlSerializer.Serialize(textWriter, obj);
				return textWriter.ToString();
			}
		}
		public T Deserialize<T>(string xml)
		{
			var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
			using (var reader = new StringReader(xml))
			{
				var messageResult = (T)serializer.Deserialize(reader);
				return messageResult;
			}
		}
	}
}
