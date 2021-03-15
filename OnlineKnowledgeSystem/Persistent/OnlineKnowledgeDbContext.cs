using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineKnowledgeSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineKnowledgeSystem.Persistent
{
    public class OnlineKnowledgeDbContext : IdentityDbContext<User>
    {
        public OnlineKnowledgeDbContext(DbContextOptions<OnlineKnowledgeDbContext> options) : base(options) { }
        public DbSet<Photo> Photos { get; set; }
    }
}
