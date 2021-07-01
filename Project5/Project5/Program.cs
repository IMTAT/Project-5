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
                new Member("Meshal", "Electrical Engineer"),
                new Member("IBRA", "Computer Eng"),
                new Member("IBRA", "Computer Eng"),
            };
            CreateXMLFile(members);
        }
        public static void CreateXMLFile(List<Member> members)
        {
            XmlDocument xmldoc = new XmlDocument();
            XmlElement root = xmldoc.CreateElement("Members");
            xmldoc.AppendChild(root);
            foreach (var member in members)
            {
                root.AppendChild(createElement(xmldoc, member));
            }
            xmldoc.Save("C:/Users/Taghr/Documents/Test.xml");
            Console.WriteLine(xmldoc.InnerXml);
        }
        public static XmlElement createElement(XmlDocument xmldoc, Member member)
        {
            XmlElement memberTag = xmldoc.CreateElement("member");
            XmlElement nameTag = xmldoc.CreateElement("name");
            XmlText nameText = xmldoc.CreateTextNode(member.name);
            nameTag.AppendChild(nameText);
            XmlElement majorTag = xmldoc.CreateElement("major");
            XmlText majorText = xmldoc.CreateTextNode(member.major);
            majorTag.AppendChild(majorText);
            memberTag.AppendChild(nameTag);
            memberTag.AppendChild(majorTag);
            return memberTag;
        }
    }
}