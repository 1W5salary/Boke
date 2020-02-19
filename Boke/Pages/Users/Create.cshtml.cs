using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Boke.Data;
using Boke.Models;
using Boke.Pages.Shared;

namespace Boke
{
    public class UserCreateModel : AllModel
    {
        private readonly Boke.Data.BokeContext _context;

        public UserCreateModel(BokeContext context) : base(context)
        {
            _context = context;
        }

        public void OnGet()
        {
            base.GetCookie();
        }

        [BindProperty]
        public User user { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            base.GetCookie();
            if (user.UserName==null)
            {
                ModelState.AddModelError("User.UserName", "* 用户名是必填的");
                return Page();
            }
            if (user.Password == null)
            {
                ModelState.AddModelError("User.Password", "* 密码是必填的");
                return Page();
            }
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
