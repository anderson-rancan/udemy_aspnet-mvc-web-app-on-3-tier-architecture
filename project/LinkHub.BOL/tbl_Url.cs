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
    
    public partial class tbl_Url
    {
        public int UrlId { get; set; }
        public string UrlTitle { get; set; }
        public string Url { get; set; }
        public string UrlDesc { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<int> UserId { get; set; }
        public string IsApproved { get; set; }
    
        public virtual tbl_Category tbl_Category { get; set; }
        public virtual tbl_User tbl_User { get; set; }
    }
}