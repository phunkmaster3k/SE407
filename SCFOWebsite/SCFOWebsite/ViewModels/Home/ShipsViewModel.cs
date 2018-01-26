using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCFOWebsite.ViewModels.Home
{
    
    public class ShipsViewModel
    {

        public List<string> ships;
        
        public ShipsViewModel()
        {
            ships = new List<string>();
            ships.Add("Aurora MR");
            ships.Add("Constellation Aquila");
            ships.Add("Avenger Titan");
            ships.Add("Hurricane");
            ships.Add("Reclaimer");

        }




    }


}