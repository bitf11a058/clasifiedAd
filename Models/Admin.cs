//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClassifiedAds.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Admin
    {


        public int Admin_Id { get; set; }
        [Required(ErrorMessage="Please Enter The Name")]
        public string UserName { get; set; }
        public string Email { get; set; }
       
        public string Password { get; set; }
        public string City { get; set; }
         [Required(ErrorMessage = "Please Enter The Phone")]
        public string Phone { get; set; }
    }
}
