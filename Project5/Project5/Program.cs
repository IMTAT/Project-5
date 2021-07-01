using System;
using System.Collections.Generic;
using System.Xml;

namespace Project5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Member> members = new List<Member>()
            {
                new Member("IBRA", "Computer Eng"),
                new Member("TAGHREED", "Computer Science"),
                new Member("TAIF", "IT"),
                new Member("IBRA", "Computer Eng"),
                new Member("IBRA", "Computer Eng"),
            };
            CreateXMLFile();
        }

        public static void CreateXMLFile()
        {
            XmlDocument xmldoc = new XmlDocument();
            XmlElement root = xmldoc.CreateElement("email");
            xmldoc.AppendChild(root);


            root.AppendChild(createElement(xmldoc, "from", "taghreed"));


            xmldoc.Save("C:/Users/Taghr/Documents/Test.xml");
            Console.WriteLine(xmldoc.InnerXml);
        }
        public static XmlElement createElement(XmlDocument xmldoc, string element, string content)
        {
            XmlElement fromTag = xmldoc.CreateElement(element);
            XmlText text1 = xmldoc.CreateTextNode(content);
            fromTag.AppendChild(text1);
            return fromTag;
        }
    }
}
