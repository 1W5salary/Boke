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
    public class UserIndexModel : AllModel
    {
        private readonly BokeContext _context;

        public UserIndexModel(BokeContext context):base(context)
        {
            _context = context;
        }

        public IList<User> userList { get;set; }

        public void OnGet() 
        {
            base.GetCookie();
                userList = _context.User.ToList();
        }
        //public async Task OnGetAsync()
        //{
        //    base.GetCookie();
        //    userList = await _context.User.ToListAsync();
        //}
    }
}
