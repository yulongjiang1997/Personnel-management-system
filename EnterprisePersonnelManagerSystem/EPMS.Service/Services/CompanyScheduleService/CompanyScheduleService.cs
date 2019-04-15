using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EPMSEF;
using EPMS.Model.Dto;
using EPMS.Model.Dto.CompanySchedules;
using EPMS.Model.Model;
using Microsoft.EntityFrameworkCore;

namespace EPMS.Service.Services.CompanyScheduleService
{
    public class CompanyScheduleService : ICompanyScheduleService
    {
        private readonly EPMSContext _context;
        private readonly IMapper _mapper;
        public CompanyScheduleService(EPMSContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ReturnData<bool>> CreateAsync(AddCompanyScheduleDto model)
        {
            var result = new ReturnData<bool>();
            _context.CompanySchedules.Add(new CompanySchedule()
            {
                EventDetails = model.EventDetails,
                EventName = model.EventName,
                ScheduleTime = model.ScheduleTime
            });
            result.Result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var company = await _context.CompanySchedules.FirstOrDefaultAsync(i => i.Id == id);
            if (company != null)
            {
                _context.CompanySchedules.Remove(company);
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ReturnData<bool>> EditAsync(EditCompanyScheduleDto model, int id)
        {
            var result = new ReturnData<bool>();
            var company = await _context.CompanySchedules.FirstOrDefaultAsync(i => i.Id == id);
            if (company != null)
            {
                company.EventDetails = model.EventDetails;
                company.EventName = model.EventName;
                company.ScheduleTime = model.ScheduleTime;
                company.LastUpTime = DateTime.Now;
            }
            result.Result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<ReturnPagin<List<ReturnCompanyScheduleDto>>> QueryAsync(SelectCompanyScheduleDto model)
        {
            var result = new ReturnPagin<List<ReturnCompanyScheduleDto>>();
            var companys = _context.CompanySchedules.AsNoTracking();
            result.Items = await companys.Select(i => new ReturnCompanyScheduleDto()
            {
                CreateTime = i.CreateTime,
                LastUpTime = i.LastUpTime,
                ScheduleTime = i.ScheduleTime,
                EventName = i.EventName,
                EventDetails = i.EventDetails,
                Id = i.Id
            }).ToListAsync();
            result.Page = model.Page;
            result.Number = model.Number;
            result.Count = result.Items.Count;
            return result;
        }
    }
}
