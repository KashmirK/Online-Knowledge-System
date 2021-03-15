using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineKnowledgeSystem.Controllers.Resources
{
    public class UserResource
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(255)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(255)]
        public string Email { get; set; }
        [Required]
        [MaxLength(255)]
        public string PhoneNumber { get; set; }
        [Required]
        [MaxLength(255)]
        public string Password { get; set; }
        [Required]
        [MaxLength(255)]
        public string DateOfBirth { get; set; }
        
        public string Gender { get; set; }
        


    }
}
