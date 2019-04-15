using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EPMSEF;
using EPMS.Model.Dto;
using EPMS.Model.Dto.PersonalSchedules;
using EPMS.Model.Model;
using Microsoft.EntityFrameworkCore;

namespace EPMS.Service.Services.PersonalScheduleService
{
    public class PersonalScheduleService : IPersonalScheduleService
    {
        private readonly EPMSContext _context;
        private readonly IMapper _mapper;
        public PersonalScheduleService(EPMSContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ReturnData<bool>> CreateAsync(AddPersonalScheduleDto model)
        {
            var result = new ReturnData<bool>();
            _context.PersonalSchedules.Add(new PersonalSchedule()
            {
                EventDetails = model.EventDetails,
                EventName = model.EventName,
                ScheduleTime = model.ScheduleTime,
                StaffId = model.StaffId,
            });
            result.Result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var personalSchedule = await _context.PersonalSchedules.FirstOrDefaultAsync(i => i.Id == id);
            if (personalSchedule != null)
            {
                _context.PersonalSchedules.Remove(personalSchedule);
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ReturnData<bool>> EditAsync(EditPersonalScheduleDto model, int id)
        {
            var result = new ReturnData<bool>();
            var personalSchedule = await _context.PersonalSchedules.FirstOrDefaultAsync(i => i.Id == id);
            if (personalSchedule != null)
            {
                personalSchedule.EventDetails = model.EventDetails;
                personalSchedule.EventName = model.EventName;
                personalSchedule.ScheduleTime = model.ScheduleTime;
                personalSchedule.LastUpTime = DateTime.Now;
            }
            result.Result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<ReturnPagin<List<ReturnPersonalScheduleDto>>> QueryAsync(SelectPersonalScheduleDto model)
        {
            var result = new ReturnPagin<List<ReturnPersonalScheduleDto>>();
            var personalSchedules = _context.PersonalSchedules.Include(i=>i.StaffInfo).AsNoTracking();
            result.Items = await personalSchedules.Select(i => new ReturnPersonalScheduleDto()
            {
                CreateTime = i.CreateTime,
                LastUpTime = i.LastUpTime,
                ScheduleTime = i.ScheduleTime,
                EventName = i.EventName,
                EventDetails = i.EventDetails,
                Id = i.Id,
                 UserName=i.StaffInfo.Name
            }).ToListAsync();
            result.Page = model.Page;
            result.Number = model.Number;
            result.Count = result.Items.Count;
            return result;
        }
    }
}
