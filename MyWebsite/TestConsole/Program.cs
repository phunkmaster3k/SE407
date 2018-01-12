using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var html = @"https://robertsspaceindustries.com/ship-matrix";

            //HtmlDocument doc = new HtmlDocument();
            //doc.LoadHtml(html);
            //var nodes = doc.DocumentNode.SelectNodes("//*[@id=\"shipscontainer\"]");
            

            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(html);
            var node = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"shipscontainer\"]");
            //var node = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"shipscontainer\"]/div[1]/div[2]/div[1]/p");

            //var node2 = node.SelectSingleNode("//*[@id=\"shipscontainer\"]");

            var options = new PhantomJSOptions();
            options.AddAdditionalCapability("IsJavaScriptEnabled", true);
            IWebDriver driver = new PhantomJSDriver("phantomjs Folder Path", options);
            driver.Navigate().GoToUrl("https://www.yourwebsite.com/");

            try
            {
                string pagesource = driver.PageSource;
                driver.FindElement(By.Id("yourelement"));
                Console.Write("yourelement founded");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }



            Console.WriteLine();
        }
    }
}
