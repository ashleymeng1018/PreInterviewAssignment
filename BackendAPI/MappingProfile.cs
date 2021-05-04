using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BackendAPI.Models;
using DataStorage.Models;
using Task = DataStorage.Models.Task;

namespace BackendAPI
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            //Source -> Target
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(dest =>dest.Tasks, opt=>opt.Ignore())
                .ReverseMap();
            CreateMap<Task, TaskDTO>().ReverseMap();
        }
    }
}
