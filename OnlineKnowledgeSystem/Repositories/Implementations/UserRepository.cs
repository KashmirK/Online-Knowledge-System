using OnlineKnowledgeSystem.Persistent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineKnowledgeSystem.Repositories.Interfaces;
using OnlineKnowledgeSystem.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using OnlineKnowledgeSystem.Controllers.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace OnlineKnowledgeSystem.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private const string V = "Male";
        private readonly OnlineKnowledgeDbContext context;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

        public UserRepository(OnlineKnowledgeDbContext context,
            IHostingEnvironment hostingEnvironment,
            IMapper mapper,
            UserManager<User> userManager)
        {
            this.context = context;
            this.hostingEnvironment = hostingEnvironment;
            this.mapper = mapper;
            this.userManager = userManager;
        }
        public async Task<User> Add(UserResource userResource)
        {

            var user = mapper.Map<UserResource, User>(userResource);
            //var gender = context.Users.Select(s => s.Gender);
            var result = await userManager.CreateAsync(user, userResource.Password);
            //this if statment will not execute if there are errors while saving user
            if (result.Succeeded)
                return user;

            return null;
        }


        public async Task<bool> AddBiography(string id, string biography)
        {
            var user = await context.Users.FindAsync(id);

            if (user != null)
            {
                user.Biography = biography;
                await context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<string>> GetBiography(string id)
        {
            var user = await context.Users.FindAsync(id);
            return context.Users.Select(s => s.Biography);

        }

        public async Task<bool> UpdateBiography(string id, [FromForm] string biography)
        {
            var user = await context.Users.FindAsync(id);
            user.Biography = null;
            if (user != null)
            {
                user.Biography = biography;
                context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();
                return true;
            }

            return false;
        }



        public User Delete(string id)
        {
            var user = context.Users.Find(id);
            if (user != null)
            {
                context.Remove(user);
                context.SaveChanges();
            }

            return user;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return context.Users.ToList();
        }

        public User Get(string id)
        {
            var user = context.Users.Find(id);
            mapper.Map<User, UserResource>(user);

            return user;
        }

        public async Task<User> Update(string id, UserResource userResource)
        {
           var user = context.Users.Find(id);
        //    string oldFileName = user.PhotoPath;
        //    mapper.Map<UserResource, User>(userResource, user);

        //    var uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");

        //    var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(userResource.Photo.FileName);
        //    var filePath = Path.Combine(uploadsFolder, uniqueFileName);
        //    userResource.Photo.CopyTo(new FileStream(filePath, FileMode.Create));

        //    if (!string.IsNullOrEmpty(oldFileName))
        //    {
        //        System.IO.File.Delete(oldFileName);
        //    }

        //    user.PhotoPath = filePath;

           await context.SaveChangesAsync();
            return user;
        }
    }
}
