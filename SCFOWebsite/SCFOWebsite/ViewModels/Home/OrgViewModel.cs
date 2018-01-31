using SCFOWebsite.Models;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCFOWebsite.ViewModels.Home
{
    public class OrgViewModel
    {
        public IEnumerable<Org> OrgsList { get; set; }

        public OrgViewModel(IEnumerable<Org> orgs)
        {
            OrgsList = orgs;
            
        }
    }
}