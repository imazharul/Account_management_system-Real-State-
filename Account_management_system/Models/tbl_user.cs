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
    
    public partial class tbl_user
    {
        public tbl_user()
        {
            this.tbl_admin = new HashSet<tbl_admin>();
            this.tbl_Expense = new HashSet<tbl_Expense>();
            this.tbl_extra_account = new HashSet<tbl_extra_account>();
            this.tbl_income_category = new HashSet<tbl_income_category>();
            this.tbl_land_account = new HashSet<tbl_land_account>();
            this.tbl_salary_expense = new HashSet<tbl_salary_expense>();
        }
    
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string email { get; set; }
        public string mobile_numbar { get; set; }
        public string present_address { get; set; }
        public string parmanent_address { get; set; }
        public string father_name { get; set; }
        public string mother_name { get; set; }
        public Nullable<int> user_type { get; set; }
        public string photo { get; set; }
        public Nullable<System.DateTime> joining_date { get; set; }
        public string gender { get; set; }
    
        public virtual ICollection<tbl_admin> tbl_admin { get; set; }
        public virtual ICollection<tbl_Expense> tbl_Expense { get; set; }
        public virtual ICollection<tbl_extra_account> tbl_extra_account { get; set; }
        public virtual ICollection<tbl_income_category> tbl_income_category { get; set; }
        public virtual ICollection<tbl_land_account> tbl_land_account { get; set; }
        public virtual ICollection<tbl_salary_expense> tbl_salary_expense { get; set; }
    }
}
