using SCFOWebsite.Models;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCFOWebsite.ViewModels.Home
{
    
    public class ShipsViewModel
    {
        public IEnumerable<SelectListItem> ShipsList { get; private set; }

        public ShipsViewModel(IEnumerable<Ship> ships)
        {
            ShipsList = ships.Select(c => new SelectListItem() { Text = c.Name });
            
        }
    }
}