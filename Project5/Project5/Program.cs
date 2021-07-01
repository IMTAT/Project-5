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
                new Member("Amal Almutairi", "Computer Science"),
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
                root.AppendChild(CreateElement(xmldoc, member));
            }
            xmldoc.Save("C:/Users/amalf/OneDrive/Desktop/Test.xml");
            Console.WriteLine(xmldoc.InnerXml);
        }
        public static XmlElement CreateElement(XmlDocument xmldoc, Member member)
        {
            XmlElement memberTag = xmldoc.CreateElement("member");

            memberTag.AppendChild(CreateChiledElements(xmldoc, "name",member.name));
            memberTag.AppendChild(CreateChiledElements(xmldoc, "magor", member.major));

            return memberTag;
        }

        static XmlElement CreateChiledElements(XmlDocument xmldoc, string Tag, string Text)
        {
            XmlElement TagElement = xmldoc.CreateElement(Tag);
            XmlText TagText = xmldoc.CreateTextNode(Text);
            TagElement.AppendChild(TagText);

            return TagElement;
        }
        }
}