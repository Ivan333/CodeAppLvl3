﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogCodeApp.Models
{
    public class Blogger
    {
        [Key]
        public int BloggerID { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "ConfirmPassword is required")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }


        public virtual ICollection<Blog> Blogs { get; set; }

    }
}