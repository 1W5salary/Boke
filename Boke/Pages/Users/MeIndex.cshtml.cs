using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Boke.Data;
using Boke.Models;
using Boke.Pages.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Boke
{
    public class MeIndexModel : AllModel
    {
        private readonly Boke.Data.BokeContext _context;

        public MeIndexModel(BokeContext context) : base(context)
        {
            _context = context;
        }
        [BindProperty]
        public User user { get; set; }
        [BindProperty]
        public List<Article> article{ get; set; }
        public void OnGet(int? id)
        {
            base.GetCookie();
            user = _context.User.Where(u => u.ID == id).FirstOrDefault();
            article = _context.Article.Include(a => a.Author).Where(a => a.Author == user).ToList();

        }
    }
}