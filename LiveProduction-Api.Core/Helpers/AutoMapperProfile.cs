using AutoMapper;
using LiveProduction_Api.Core.Models;
using LiveProduction_Api.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiveProduction_Api.Core.Helpers
{
   public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<User, RegisterDTO>();
            CreateMap<User, UpdateDTO>();

        }
    }
}
