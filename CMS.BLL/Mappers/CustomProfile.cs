using AutoMapper;
using CMS.DAL.DTOS;
using CMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BLL.Mappers
{
    public class CustomProfile : Profile
    {
        public CustomProfile()
        {
            CreateMap<BranchDto, Branch>().ReverseMap();
            CreateMap<EmployeeDto, Employee>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();
        }
    }
}
