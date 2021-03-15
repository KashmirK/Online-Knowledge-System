using AutoMapper;
using OnlineKnowledgeSystem.Controllers.Resources;
using OnlineKnowledgeSystem.Models;
using OnlineKnowledgeSystem.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineKnowledgeSystem.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserResource>().ReverseMap();
            CreateMap<Photo, PhotoResource>().ReverseMap();
                
        }
    }
}
