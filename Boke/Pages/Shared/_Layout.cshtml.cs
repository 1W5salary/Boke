using Boke.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boke.Pages.Shared
{
    public class AllModel : PageModel
    {
        private readonly BokeContext _context;

        public AllModel(BokeContext context)
        {
            _context = context;
        }

        public void GetCookie()
        {
            bool hasUserName = Request.Cookies.TryGetValue("UserName", out string CookeUserName);
            bool hasUserRole = Request.Cookies.TryGetValue("Role", out string CookeRole);
            bool hasUserID = Request.Cookies.TryGetValue("ID", out string CookeID);
            if (hasUserName)
            {
                ViewData["UserName"] = CookeUserName;
                ViewData["Role"] = Convert.ToInt32(CookeRole);
                ViewData["ID"] = Convert.ToInt32(CookeID);
            }

        }
    }
}
