//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Account_management_system.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_notification_receiver
    {
        public int id { get; set; }
        public string receiver { get; set; }
        public string status { get; set; }
        public Nullable<int> notification_id { get; set; }
    
        public virtual tbl_notification tbl_notification { get; set; }
    }
}
