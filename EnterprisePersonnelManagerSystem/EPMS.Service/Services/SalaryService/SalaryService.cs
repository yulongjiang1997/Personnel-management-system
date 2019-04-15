using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EPMSEF;
using EPMS.Model.Dto;
using EPMS.Model.Dto.Salarys;
using Microsoft.EntityFrameworkCore;

namespace EPMS.Service.Services.SalaryService
{
    public class SalaryService : ISalaryService
    {
        private readonly EPMSContext _context;
        private readonly IMapper _mapper;
        public SalaryService(EPMSContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ReturnData<bool>> CreateAsync(AddSalaryDto model)
        {
            var result = new ReturnData<bool>();
            var salarys = await _context.Salarys.FirstOrDefaultAsync(i => i.StaffInfoId == model.StaffInfoId && i.CreateTime.ToString("yy/MM") == DateTime.Now.ToString("yy/MM"));
            if (salarys != null)
            {
                result.Message = "当月此员工已经录入工资，录入失败";
                result.Result = false;
                return result;
            }
            _context.Salarys.Add(new Model.Model.Salary
            {
                CreateTime = DateTime.Now,
                StaffInfoId = model.StaffInfoId,
                BasicSalary = model.BasicSalary,
                Deduction = model.Deduction,
                LastUpTime = DateTime.Now,
                MealSubsidy = model.MealSubsidy,
                OtherSubsidies = model.OtherSubsidies,
                Reward = model.Reward,
                TransportationSubsidy = model.TransportationSubsidy,
            });
            result.Result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var salarys = await _context.Salarys.FirstOrDefaultAsync(i => i.Id == id);
            if (salarys != null)
            {
                _context.Salarys.Remove(salarys);
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ReturnPagin<List<ReturnSalaryDto>>> QueryPaginAsync(SelectSalaryDto model)
        {
            var result = new ReturnPagin<List<ReturnSalaryDto>>();

            var salarys = _context.Salarys.Include(i => i.StaffInfo).AsNoTracking();

            result.Items = await salarys.OrderByDescending(i => i.CreateTime).Pagin(model).Select(i => new ReturnSalaryDto
            {
                Id = i.Id,
                StaffInfoName = i.StaffInfo.Name,
                BasicSalary = i.BasicSalary,
                Deduction = i.Deduction,
                CreateTime = i.LastUpTime,
                MealSubsidy = i.MealSubsidy,
                OtherSubsidies = i.OtherSubsidies,
                Reward = i.Reward,
                TransportationSubsidy = i.TransportationSubsidy,
            }).ToListAsync();
            result.Count = await salarys.CountAsync();
            result.Number = model.Number;
            result.Page = model.Page;
            return result;
        }
    }
}
