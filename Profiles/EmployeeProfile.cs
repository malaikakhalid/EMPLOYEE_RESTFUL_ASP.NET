using API.DTOS;
using API.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Profiles
{
    public class EmployeeProfile : Profile
    {

        public EmployeeProfile()
        {
            // Source -> Target
            CreateMap<Employee, EmployeeReadDtos>();
            CreateMap<EmployeeCreateDtos, Employee>();
            CreateMap<EmployeeUpdateDtos, Employee>();
            CreateMap<Employee, EmployeeUpdateDtos>();
            CreateMap<Employee, EmployeeDeleteDtos>();
        }
    }
}
