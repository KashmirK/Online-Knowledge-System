using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineKnowledgeSystem.Models
{
    public class Photo
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(256)]
        public string PhotoPath { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
    }
}
