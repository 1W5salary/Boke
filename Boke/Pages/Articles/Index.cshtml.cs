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
    public class ArticleIndexModel : AllModel
    {
        private readonly BokeContext _context;

        public ArticleIndexModel(BokeContext context):base(context)
        {
            _context = context;
        }

        public IList<Article> Article { get;set; }

        public void OnGet()
        {
            base.GetCookie();
            Article =  _context.Article.Include(a => a.Author).ToList();
        }
    }
}
