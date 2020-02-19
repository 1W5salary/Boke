using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Boke.Data;
using Boke.Models;
using Boke.Pages.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Boke
{
    public class LogOnModel : AllModel
    {


        private readonly BokeContext _context;

        public LogOnModel(BokeContext context) : base(context)
        {
            _context = context;
        }

        public bool Success { get; set; }
        [BindProperty]
        public User inputUser { get; set; }
        public void OnGet()
        {
            base.GetCookie();
        }

        public ActionResult OnPost()
        {
            if (inputUser.UserName==null)
            {
                ModelState.AddModelError("User.UserName", "* 请输入用户名");
            }
            if (inputUser.Password == null)
            {
                ModelState.AddModelError("User.UserName", "* 请输入密码");
                return Page();
            }
            User user = _context.User
                .Where(u => u.UserName == inputUser.UserName).SingleOrDefault();
            if (user == null)
            {
                ModelState.AddModelError("User.UserName", "* 用户名不存在");
                return Page();
            }
            if (user.Password != inputUser.Password)
            {
                ModelState.AddModelError("User.Password", "* 用户名或密码错误");
                return Page();
            }
            CookieOptions options = new CookieOptions { Expires = DateTime.Now.AddDays(1)};
            Response.Cookies.Append("ID", user.ID.ToString(), options);
            Response.Cookies.Append("UserName", user.UserName, options);
            Response.Cookies.Append("Role", user.Role.ToString(), options);

            ViewData["UserName"] = user.UserName;
            return RedirectToPage("Index");
        }
    }
}