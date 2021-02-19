using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBackendAPI.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [Column(TypeName = "text")]
        public string CommentData { get; set; }
        [Column(TypeName = "nvarchar(5)")]
        public int TicketId { get; set; }
    }
}
