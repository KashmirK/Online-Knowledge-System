//using Abp.Domain.Uow;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using OnlineKnowledgeSystem.Models;
using OnlineKnowledgeSystem.Persistent;
using OnlineKnowledgeSystem.Repositories.Interfaces;
using OnlineKnowledgeSystem.Resources;
using System;
using System.IO;
using System.Threading.Tasks;

namespace OnlineKnowledgeSystem.Repositories.Implementations
{
    public class PhotoRepository : IPhotoRepository
{
    private readonly OnlineKnowledgeDbContext context;
    private readonly IHostingEnvironment hostingEnvironment;
        //private readonly IUnitOfWork unitOfWork;
        private readonly IUserRepository repository;
        private readonly IMapper mapper;
    public PhotoRepository(OnlineKnowledgeDbContext context,
                            IMapper mapper,
                            IHostingEnvironment hostingEnvironment
                            //IUnitOfWork unitOfWork
                            )
    {
        this.context = context;
            this.mapper = mapper;
            this.hostingEnvironment = hostingEnvironment;
           // this.unitOfWork = unitOfWork;
            
        }

    public async Task<Photo> Add(string id, PhotoResource photoResource)
    {
            //var user = repository.Get(id);
            
        var user =await context.Users.FindAsync(id);
            if (user == null)
            {
                return null;
            }
            if(user !=null)
            { 
            var uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);
            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(photoResource.PhotoPath.FileName);
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);
            photoResource.PhotoPath.CopyTo(new FileStream(filePath, FileMode.Create));
                var file = new Photo { PhotoPath = filePath }; 
               //await unitOfWork.CompleteAsync();
                var photo =  mapper.Map<PhotoResource, Photo>(photoResource);
            photo.PhotoPath = filePath;

            user.Photo = photo;
            await context.SaveChangesAsync();
            return photo;
            }

            return null;

        }
                

}
}
