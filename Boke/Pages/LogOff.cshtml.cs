using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Boke
{
    public class LogOffModel : PageModel
    {
        public ActionResult OnGet()
        {
            Response.Cookies.Delete("ID");
            Response.Cookies.Delete("UserName");
            return RedirectToPage("Index");
        }
    }
}