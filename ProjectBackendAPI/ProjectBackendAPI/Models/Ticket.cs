using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBackendAPI.Models
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        [Required]
        public string Summary { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        [Required]
        public string Description { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string ComplaintType { get; set; }
        [Column(TypeName = "nvarchar(5)")]
        public int UserId { get; set; }
        //[Column(TypeName = "nvarchar(5)")]
        //public int CommentId { get; set; }
    }
}
