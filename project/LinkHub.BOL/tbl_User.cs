//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LinkHub.BOL
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_User
    {
        public tbl_User()
        {
            this.tbl_Url = new HashSet<tbl_Url>();
        }
    
        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    
        public virtual ICollection<tbl_Url> tbl_Url { get; set; }
    }
}