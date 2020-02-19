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
    public class ArticleDetailsModel : AllModel
    {
        private readonly BokeContext _context;

        public ArticleDetailsModel(Boke.Data.BokeContext context):base(context)
        {
            _context = context;
        }

        public Article Article { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            base.GetCookie();
            if (id == null)
            {
                return NotFound();
            }

            Article = await _context.Article.Include(a => a.Author).FirstOrDefaultAsync(m => m.ID == id);

            if (Article == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
