using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Boke.Data;
using Boke.Models;
using Boke.Pages.Shared;

namespace Boke
{
    public class UserDeleteModel : AllModel
    {
        private readonly Boke.Data.BokeContext _context;

        public UserDeleteModel(Boke.Data.BokeContext context) : base(context)
        {
            _context = context;
        }

        [BindProperty]
        public User user { get; set; }

        public void OnGet(int? id)
        {
            base.GetCookie();
            if (id == null)
            {
                return ;
            }

            user = _context.User.FirstOrDefault(m => m.ID == id);

            if (user == null)
            {
                return ;
            }
            return ;
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            base.GetCookie();
            if (id == null)
            {
                return NotFound();
            }

            user = await _context.User.FindAsync(id);

            if (User != null)
            {
                _context.User.Remove(user);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
