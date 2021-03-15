using OnlineKnowledgeSystem.Models;
using OnlineKnowledgeSystem.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineKnowledgeSystem.Repositories.Interfaces
{
    public interface IPhotoRepository
    {
        Task<Photo> Add(string id, PhotoResource photo);
    }
}
