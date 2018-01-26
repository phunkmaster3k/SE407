using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace InClassWork.ViewModels.Home
{
    public class ShowLangsViewModel
    {

        public ShowLangsViewModel(CultureInfo[] cultures)
        {
            CulturesList = cultures.Select(c => new SelectListItem() { Text = c.EnglishName });
        }
        public IEnumerable<SelectListItem> CulturesList { get; private set; }
    
    }
}