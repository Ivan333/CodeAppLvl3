using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogCodeApp.Models
{
    public class Blog
    {
        public int BlogID { get; set; }
        public int BloggerID { get; set; }
        public string Title { get; set; }

        public string Text { get; set; }

        public virtual Blogger Blogger { get; set; }

    }
}