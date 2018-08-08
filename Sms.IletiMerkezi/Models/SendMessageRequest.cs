using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Sms.IletiMerkezi.Models.SendMessageRequest
{

    [XmlRoot(ElementName = "authentication")]
    public class Authentication
    {
        [XmlElement(ElementName = "username")]
        public string Username { get; set; }
        [XmlElement(ElementName = "password")]
        public string Password { get; set; }
    }

    [XmlRoot(ElementName = "receipents")]
    public class Receipents
    {
        [XmlElement(ElementName = "number")]
        public List<string> Number { get; set; }
    }

    [XmlRoot(ElementName = "message")]
    public class Message
    {

        [XmlIgnore]
        public string MessageText { get; set; }

        [XmlElement(ElementName = "text")]
        public XmlCDataSection Text
        {
            get
            {
                XmlDocument doc = new XmlDocument();
                return doc.CreateCDataSection(MessageText);
            }
            set
            {
                MessageText = value.Value;
            }
        }

        [XmlElement(ElementName = "receipents")]
        public Receipents Receipents { get; set; }
    }

    [XmlRoot(ElementName = "order")]
    public class Order
    {
        [XmlElement(ElementName = "sender")]
        public string Sender { get; set; }

        [XmlElement(ElementName = "message")]
        public Message Message { get; set; }
    }

    [XmlRoot(ElementName = "request")]
    public class Request
    {
        [XmlElement(ElementName = "authentication")]
        public Authentication Authentication { get; set; }

        [XmlElement(ElementName = "order")]
        public Order Order { get; set; }
    }
}
