using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mall.Models
{
    public class LoginPost
    {

        [Display(Name = "用户名")]
        public string user { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string pwd { get; set; }
    }
}