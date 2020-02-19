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
    public class ArtileCreateModel : AllModel
    {
        private readonly BokeContext _context;
        
        public User user { get; set; }
        [BindProperty]
        public Article Article { get; set; }

        public ArtileCreateModel(BokeContext context):base(context)
        {
            _context = context;
        }

        public void OnGet()
        {
            base.GetCookie();
        }



        public async Task<IActionResult> OnPostAsync()
        {

            base.GetCookie();
            bool hasUserRole = Request.Cookies.TryGetValue("ID", out string CookeID);
            user = _context.User.Single(u => u.ID == Convert.ToInt32(CookeID));
            if (Article.Tittle == null)
            {
                ModelState.AddModelError("Article.Tittle", "* 必须有一个标题");
                return Page();
            }
            if (Article.Content == null)
            {
                ModelState.AddModelError("Article.Content", "* 必须有内容");
                return Page();
            }
            Article.Author = user;
            Article.CreateTime = DateTime.Now;
            _context.Article.Add(Article);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Index");
        }
    }
}
