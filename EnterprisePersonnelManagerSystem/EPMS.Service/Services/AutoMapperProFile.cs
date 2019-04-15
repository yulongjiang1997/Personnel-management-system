using AutoMapper;
using EPMS.Model.Dto.Admin;
using EPMS.Model.Dto.Stocks;
using EPMS.Model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Service.Services
{
    public class AutoMapperProFile:Profile 
    {
        public AutoMapperProFile()
        {
            CreateMap<ReturnAdminDto, Admin>().ReverseMap();
            CreateMap<ReturnStockDto, Stock>().ReverseMap().ForMember(o=>o.ProductName,i=>i.MapFrom(p=>p.Product.Name));
            CreateMap<ReturnStockDto, Stock>().ReverseMap().ForMember(o=>o.ProductName,i=>i.MapFrom(p=>p.Product.Name));
        }
    }
}
