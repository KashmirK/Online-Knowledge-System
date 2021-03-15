using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineKnowledgeSystem.Models
{
    public class User : IdentityUser
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(50)]
        public string DateOfBirth { get; set; }
        [Required]
        [MaxLength(10)]
        public string Gender { get; set; }
        public Photo Photo { get; set; }
        public string Biography { get; set; }
       

    }
}
