using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;



namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            //SyndicationFeed feed = new SyndicationFeed();
            string url = "https://robertsspaceindustries.com/comm-link/rss";

    

            XmlDocument myXmlDoc = new XmlDocument();


            myXmlDoc.Load(url);

           

            XmlNodeReader xmlRed = new XmlNodeReader(myXmlDoc.SelectSingleNode("rss/channel"));


            

            while (xmlRed.Read())
            {

                Console.WriteLine("VAL: " + xmlRed.Value);
               /* string title = xmlRed.Name;
                if (xmlRed.Name == "title")
                {
                    Console.WriteLine("TITLE: " + xmlRed.ReadString());
                    
                }
                if (xmlRed.Name == "description")
                {
                    Console.WriteLine("DESC: " + xmlRed.ReadString());
                }

                if (xmlRed.Name == "link")
                {
                    Console.WriteLine("LINK: " + xmlRed.ReadString());
                }

                if (xmlRed.Name == "item")
                {
                    Console.WriteLine("ITEM: " + xmlRed.ReadString());
                }

                Console.WriteLine(title);*/
            }

                // XmlNode node = nav.SelectSingleNode("//contnet/rss");


                Console.WriteLine();
        }
    }
}
