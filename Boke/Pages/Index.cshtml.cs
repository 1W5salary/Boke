using System.Collections.Generic;
using Boke.Data;
using Boke.Pages.Shared;
using Boke.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Boke.Pages
{
    public class IndexModel : AllModel
    {
        public BokeContext _context;
        public User cookieUser;

        public IndexModel(BokeContext context) : base(context)
        {
            _context = context;
        }

        public IList<Article> Article { get; set; }

        public void OnGet()
        {
            base.GetCookie();
            Article = _context.Article.Include(a=>a.Author).ToList();
        }
    }
}
