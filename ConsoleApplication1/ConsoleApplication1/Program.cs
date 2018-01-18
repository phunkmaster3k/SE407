using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.ServiceModel.Syndication;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var driver = new PhantomJSDriver();
            driver.Url = "https://robertsspaceindustries.com/ship-matrix";
            driver.Navigate();
            //the driver can now provide you with what you need (it will execute the script)
            //get the source of the page
            var source = driver.PageSource;
            //fully navigate the dom
            //var el1 = driver.FindElementByXPath("//*[@id=\"shipscontainer\"]/div[1]/div[2]/div[1]/p");
            

            ReadOnlyCollection<IWebElement> names = driver.FindElementsByXPath("//*[@id=\"shipscontainer\"]/div");

            StringBuilder sb = new StringBuilder();

           /* foreach (IWebElement el in names)
            {
                Console.Write(el.Text);

           */ 

            Console.Write(names[2].Text);

            //driver.Close();

            //*[@id="shipscontainer"]/div[2]/div[2]/div[1]/p

            /*for (var i = 1; i < c; i++)
            {
                // var name = ele.FindElement(By.XPath("//p"));
                var pathElement = driver.FindElementByXPath("//*[@id=\"shipscontainer\"]/div[" + i + "]/div[2]/div[1]/p");
                Console.WriteLine(pathElement.Text);
            }*/


            Console.ReadLine();
         
        }
    }
}
