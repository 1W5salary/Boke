using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Boke.Data;
using Boke.Models;
using Boke.Pages.Shared;

namespace Boke
{
    public class UserEditModel : AllModel
    {
        private readonly Boke.Data.BokeContext _context;

        public UserEditModel(Boke.Data.BokeContext context):base(context)
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

            if (User == null)
            {
                return ;
            }
            return ;
        }

        public async Task<IActionResult> OnPostAsync()
        {

            _context.Attach(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(user.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.ID == id);
        }
    }
}
