using System;
using System.ComponentModel.DataAnnotations;

namespace launchPad.Models {

    public class Category {
        [Key]
        [Required]
        public int categoryID {get;set;}
        [Required]
        [Display(Name="name")]
        public string categoryName {get;set;}
    }
}
