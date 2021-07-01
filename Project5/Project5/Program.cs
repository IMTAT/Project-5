using System;
using System.Collections.Generic;
using System.Threading;
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
                new Member("MESHAL", "Electrical Engineer"),
                new Member("AMAL", "Computer Science"),
                new Member("TAIF", "IT"),
            };

            Thread thread1 = new Thread(() =>
            {
                CreateXMLFile(members);
            });
            Thread thread2 = new Thread(()=>ReadXMLFile());
            thread1.Start();
            thread1.Join();
            thread2.Start();
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
            xmldoc.Save("../../../../../Test.xml");
            Console.WriteLine(xmldoc.InnerXml);
        }
        public static XmlElement CreateElement(XmlDocument xmldoc, Member member)
        {
            XmlElement memberTag = xmldoc.CreateElement("member");

            memberTag.AppendChild(CreateChiledElements(xmldoc, "name", member.name));
            memberTag.AppendChild(CreateChiledElements(xmldoc, "major", member.major));

            return memberTag;
        }

        static XmlElement CreateChiledElements(XmlDocument xmldoc, string Tag, string Text)
        {
            XmlElement TagElement = xmldoc.CreateElement(Tag);
            XmlText TagText = xmldoc.CreateTextNode(Text);
            TagElement.AppendChild(TagText);

            return TagElement;
        }
        static void ReadXMLFile()
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(@"../../../../../Test.xml");
           
            Console.WriteLine();
            
            foreach (XmlNode node in xmldoc.DocumentElement.ChildNodes)
            {
                string elem = node.Name;
                Console.Write(elem + ": ");

                XmlNodeList list = node.ChildNodes;
                string name = list[0].InnerText;
                string major = list[1].InnerText;
                
                Console.WriteLine(name + " -- " + major);
            }
        }
    }

}