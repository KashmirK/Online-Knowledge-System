using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using OnlineKnowledgeSystem.Controllers.Resources;
using OnlineKnowledgeSystem.Models;
using OnlineKnowledgeSystem.Persistent;
using OnlineKnowledgeSystem.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineKnowledgeSystem.Controllers
{
    [Route("/api/users")]
    public class UserController : Controller

    {
        private readonly int MAX_BYTES = 1 * 1024 * 1024;
        private readonly string[] ACCEPTED_FILE_TYPES = new[] { ".jpg", ".jpeg", ".png" };
        private readonly OnlineKnowledgeDbContext context;
        private readonly IMapper mapper;
        private readonly IUserRepository repository;
        private readonly IHostingEnvironment hostingEnvironment;

        public UserController(OnlineKnowledgeDbContext context, IMapper mapper, 
                        IUserRepository repository,
                        IHostingEnvironment hostingEnvironment)
        {
            this.context = context;
            this.mapper = mapper;
            this.repository = repository;
            this.hostingEnvironment = hostingEnvironment;
        }


        //[Route("/api/createuser")]
        [HttpPost("adduser")]
        public async Task<IActionResult> CreateUser([FromForm] UserResource userResource)
        {

            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            //if (userResource.Photo == null) return BadRequest("Null file");
            //if (userResource.Photo.Length == 0) return BadRequest("Empty file");
            //if (userResource.Photo.Length > MAX_BYTES) return BadRequest("Max file size exceeded");
            //if (!ACCEPTED_FILE_TYPES.Any(s => s == Path.GetExtension(userResource.Photo.FileName))) return BadRequest("Invalid Type.");

            var user = await repository.Add(userResource);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromForm] UserResource userResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var user = await context.Users.FindAsync(id);
            await repository.Update(id, userResource);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(string id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            repository.Delete(id);
            return Ok(id);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(string id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var user = repository.Get(id);
            if(user == null)
            {
                return NotFound("not found");
            }

            return Ok(user);
            
        }

        //[Route("/api/getusers")]
        [HttpGet("getall")]
        public IEnumerable<User> GetAllUsers()
        {
            return repository.GetAllUsers();
        }

        [HttpPut("addbiography/{id}")]

        public async Task<IActionResult> AddBiography(string id, string biography)
        {
            bool result = await repository.AddBiography(id, biography);

            if(result)
            {
                return Ok("Biography added");
            }
            return NotFound("User Not Found");
        }

        [HttpPut("updatebiography/{id}")]

        public async Task<IActionResult> UpdateBiography(string id, string biography)
        {
            bool result = await repository.UpdateBiography(id, biography);

            if (result)
            {
                return Ok("Biography Updated");
            }
            return NotFound("User Not Found");
        }

        [HttpGet("getbiography/{id}")]
        public async Task<IActionResult> GetBiography(string id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var user = await context.Users.FindAsync(id);
            if(user != null)
            {
                await repository.GetBiography(id);
                return Ok(user.Biography);
                
            }

            return NotFound("not found");           
        }

    }
}
