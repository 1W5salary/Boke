using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Boke.Models
{
    public enum ArticleType { 生活 = 2, 编程 = 4,};
    public class Article
    {
        public int ID { get; set; }
        [Display(Name = "标题")]
        public string Tittle { get; set; }
        [Display(Name = "作者")]
        public User Author{ get; set; }
        [Display(Name = "类型")]
        public string Type { get; set; }
        [Display(Name = "内容")]
        public string Content { get; set; }
        [Display(Name = "发布时间")]
        [DataType(DataType.DateTime)]
        public DateTime CreateTime { get; set; }
    }
}
