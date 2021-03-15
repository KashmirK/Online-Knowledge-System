using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineKnowledgeSystem.Resources
{
    public class PhotoResource
    {

        public int Id { get; set; }
        public IFormFile PhotoPath { get; set; }
    }
}
