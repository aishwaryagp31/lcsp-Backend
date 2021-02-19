using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBackendAPI.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string FirstName { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string LastName { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        [Required]
        public string Phone { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string UserName { get; set; }
        [Column(TypeName = "nvarchar(8)")]
        [Required]
        public string Password { get; set; }


    }
}
