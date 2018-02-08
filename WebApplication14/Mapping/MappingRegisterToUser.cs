using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication14.Models;
using WebApplication14.Models.ViewModel;

namespace WebApplication14.Mapping
{
    public class MappingRegisterToUser : Profile
        {
            public MappingRegisterToUser()
            {
                CreateMap<RegisterModel, AppUser>().ForMember(au => au.UserName, map => map.MapFrom(vm => vm.Email));
            }
        }
    }
