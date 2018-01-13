using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.ServiceModel.Syndication;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://robertsspaceindustries.com/comm-link/rss";
            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();

            foreach (SyndicationItem item in feed.Items)
            {
                Console.WriteLine( item.Title.Text );
                Console.WriteLine( item.Summary.Text);
                Console.WriteLine(item.Links[0].Uri);
                if ( item.Categories.Count > 0)
                {
                    Console.WriteLine(item.Categories[0].Name);
                }

                


            }
            Console.ReadLine();
        }
    }
}
