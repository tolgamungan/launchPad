using System;
using System.ComponentModel.DataAnnotations;

namespace launchPad.Models {

    public class Link {

        [Key]
        [Required]
        public int linkID { get; set; }
        [Required]
        public int categoryID {get;set;}
        [Required]
        [MaxLength(50)]
        public string label {get;set;}
        [Required]
        [Url]
        public string url {get;set;}
        [Required]
         public bool pinned {get;set;}
        
    }
}
