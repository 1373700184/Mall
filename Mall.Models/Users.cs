//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mall.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Users
    {
        public int PKID { get; set; }
        public Nullable<int> OutPKID { get; set; }
        public string UserNo { get; set; }
        public string UserName { get; set; }
        public string RealName { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public int Sex { get; set; }
        public string RoleIDs { get; set; }
        public int Status { get; set; }
        public int Out { get; set; }
        public System.DateTime DateCreate { get; set; }
        public System.DateTime DateUpdate { get; set; }
        public Nullable<System.DateTime> DateDelete { get; set; }
        public int BS { get; set; }
    }
}
