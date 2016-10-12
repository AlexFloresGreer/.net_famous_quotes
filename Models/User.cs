using System;
using System.ComponentModel.DataAnnotations;

namespace DapperApp.Models {
    public class User : BaseEntity {
        [Key]
        public long Id { get; set; }

        [Required]
        [MinLengthAttribute(2)]
        public string first_name { get; set; }

        [Required]
        [MinLengthAttribute(2)]
        public string quote { get; set; }
        public DateTime created_at { get; set; }
        
    }
}