using System;
using APICore.DataModelService;
using APICore.DataService;
using APICore.ModelService;
using AutoMapper;
using Stripe;

namespace APICore.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ApplicationUser, AppUserModel>();
            //CreateMap<Course, CourseModel>();
        }
    }
}
