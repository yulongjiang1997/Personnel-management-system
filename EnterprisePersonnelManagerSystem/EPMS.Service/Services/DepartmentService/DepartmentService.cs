using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EF;
using EPMS.Model.Dto;
using EPMS.Model.Dto.Departments;
using EPMS.Model.Model;
using Microsoft.EntityFrameworkCore;

namespace EPMS.Service.Services.DepartmentService
{
    public class DepartmentService : IDepartmentService
    {
        private readonly EPMSContext _context;
        private readonly IMapper _mapper;
        public DepartmentService(EPMSContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ReturnData<bool>> CreateAsync(AddDepartmentDto model)
        {
            var result = new ReturnData<bool>();
            var deparment = await _context.Departments.FirstOrDefaultAsync(i => i.Name == model.Name);
            if (deparment != null)
            {
                result.Message = "已存在相同名称部门，添加失败";
                result.Result = false;
                result.Success = true;
                return result;
            }
            _context.Departments.Add(new Department()
            {
                Name = model.Name
            });
            result.Result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deparment = await _context.Departments.FirstOrDefaultAsync(i => i.Id == id);
            if (deparment != null)
            {
                _context.Departments.Remove(deparment);
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> EditAsync(EditDepartmentDto model, int id)
        {
            var departments = await _context.Departments.FirstOrDefaultAsync(i => i.Id == id);
            if (departments != null)
            {
                _context.Departments.Remove(departments);
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<ReturnDepartmentDto>> QueryAsync(SelectDeparmentDto model)
        {
            var departments = _context.Departments.AsNoTracking();

            return await departments.Select(i => new ReturnDepartmentDto()
            {
                CreateTime = i.CreateTime,
                Id = i.Id,
                LastUpTime = i.LastUpTime,
                Name = i.Name
            }).ToListAsync();
        }
    }
}
