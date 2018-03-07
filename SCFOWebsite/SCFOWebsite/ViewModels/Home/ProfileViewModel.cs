using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SCFOWebsite.Models;

namespace SCFOWebsite.ViewModels.Home
{
    public class ProfileViewModel
    {
        public Org org { get; set; }
        public User user { get; set; }
        public List<Ship> ships { get; set; }
    }
}