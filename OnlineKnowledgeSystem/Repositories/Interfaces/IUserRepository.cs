using Microsoft.AspNetCore.Mvc;
using OnlineKnowledgeSystem.Controllers.Resources;
using OnlineKnowledgeSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineKnowledgeSystem.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Add(UserResource userReource);
        User Get(string id);
        IEnumerable<User> GetAllUsers();
        Task<User> Update(string id, UserResource userResource);
        User Delete(string id);
        Task<IEnumerable<string>> GetBiography(string id);
        Task<bool> AddBiography(string id, string biography);
        Task<bool> UpdateBiography(string id, string biography);
        

    }
}
