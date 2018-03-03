using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Xml;

namespace SCFOWebsite.ViewModels.Home
{
    public class RSSViewModel
    {
        private string url;
        private XmlReader reader;
        //private SyndicationFeed feed;

        //public List<SyndicationItem> RSSList;
        public List<string> RSSList;

        public RSSViewModel(string url)
        {
            /*reader = XmlReader.Create(url);
            feed = SyndicationFeed.Load(reader);
            reader.Close();
            RSSList = feed.Items.ToList();*/
            List<string> feed = new List<string>();

            feed.Add("TEST");

            RSSList = feed;
        }
    }
}