using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OnlineKnowledgeSystem.Models;
using OnlineKnowledgeSystem.Persistent;
using OnlineKnowledgeSystem.Repositories.Implementations;
using OnlineKnowledgeSystem.Repositories.Interfaces;
using OnlineKnowledgeSystem.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineKnowledgeSystem.Controllers
{
    [Route("/api/photo/{id}/addphoto")]
    public class PhotoController : Controller
    {
        private readonly OnlineKnowledgeDbContext context;
        private readonly IPhotoRepository repository;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IMapper mapper;

        //[ModelBinder(Photo)]
        public PhotoController(OnlineKnowledgeDbContext context, IPhotoRepository repository,
                IHostingEnvironment hostingEnvironment,
                IMapper mapper
                    )
        {
            this.context = context;
            this.repository = repository;
            this.hostingEnvironment = hostingEnvironment;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Upload(string id,PhotoResource photoResource)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            

            var resulut  = await repository.Add(id, photoResource);
            return Ok();
            
            
        }
    }
}
