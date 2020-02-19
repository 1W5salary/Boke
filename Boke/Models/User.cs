using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Boke.Models
{
    [Flags]
    public enum Power {AdminPower=1, DataPower=2 ,UserPower = 4, };
    public class User
    {
        public int ID { get; set; }
        
        [Display(Name ="用户名")]
        public string UserName { get; set; }
        [MinLength(6,ErrorMessage ="*长度不能小于6")]
        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "昵称")]
        public string Name { get; set; }
        [Display(Name = "角色")]
        public int Role { get; set; }
        [Display(Name = "金币")]
        public int Moneys { get; set; }
        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
