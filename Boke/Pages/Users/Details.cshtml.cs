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
    public class UserDetailsModel : AllModel
    {
        private readonly BokeContext _context;

        public UserDetailsModel(BokeContext context) : base(context)
        {
            _context = context;
        }

        public User user { get; set; }

        public void OnGet(int? id)
        {
            base.GetCookie();
            if (id == null)
            {
                return;
            }

            user = _context.User.FirstOrDefault(m => m.ID == id);

            if (user == null)
            {
                return ;
            }
            return;
        }
    }
}
