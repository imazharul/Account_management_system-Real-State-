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
    
    public partial class tbl_customer
    {
        public tbl_customer()
        {
            this.tbl_land_account = new HashSet<tbl_land_account>();
        }
    
        public int customer_id { get; set; }
        public string applicant_name { get; set; }
        public string email { get; set; }
        public string present_address { get; set; }
        public string parmanent_address { get; set; }
        public string mobile_number { get; set; }
        public string father_name { get; set; }
        public string mother_name { get; set; }
        public Nullable<int> user_type { get; set; }
        public string photo { get; set; }
        public string birth_date { get; set; }
        public string religion { get; set; }
        public string year { get; set; }
    
        public virtual ICollection<tbl_land_account> tbl_land_account { get; set; }
    }
}
