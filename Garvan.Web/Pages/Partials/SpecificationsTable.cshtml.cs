using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Garvan.Web.Pages.Partials
{
    public class SpecificationsTableModel : PageModel
    {
        public bool IncludeAllSpecifications { get; set; } = false;

        public void OnGet()
        {

        }
    }
}