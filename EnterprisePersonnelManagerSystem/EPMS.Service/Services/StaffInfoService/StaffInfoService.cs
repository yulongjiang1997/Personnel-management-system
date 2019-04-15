using AutoMapper;
using EPMSEF;
using EPMS.Model.Dto;
using EPMS.Model.Dto.Staffinfos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPMS.Service.Services.StaffInfoService
{
    public class StaffInfoService : IStaffInfoService
    {
        private readonly EPMSContext _context;
        private readonly IMapper _mapper;
        public StaffInfoService(EPMSContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ReturnData<bool>> CreateAsync(AddStaffinfoDto model)
        {
            var result = new ReturnData<bool>();
            var staffInfos = await _context.StaffInfos.FirstOrDefaultAsync(i => i.Email == model.Email && i.Name == model.Name);
            if (staffInfos != null)
            {
                result.Message = "存在相同员工，添加失败";
                result.Result = false;
                return result;
            }
            _context.StaffInfos.Add(new Model.Model.StaffInfo
            {
                Email = model.Email,
                Name = model.Name,
                CreateTime = DateTime.Now,
                EntryTime = model.EntryTime,
                LastUpTime = DateTime.Now,
                Phone = model.Phone,
                PositionId = model.PositionId,
                ResignationTime = model.ResignationTime,
                WorkingStatus = model.WorkingStatus,
            });
            result.Result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var staffInfos = await _context.StaffInfos.FirstOrDefaultAsync(i => i.Id == id);
            if (staffInfos != null)
            {
                _context.StaffInfos.Remove(staffInfos);
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ReturnData<bool>> EditAsync(int id, EditStaffinfoDto model)
        {
            var result = new ReturnData<bool>();
            var check = await _context.StaffInfos.FirstOrDefaultAsync(i => i.Name == model.Name && i.Email == model.Email && i.Id != id);
            if (check != null)
            {
                result.Message = "存在相同员工，修改失败";
                result.Result = false;
                return result;
            }
            var staffInfos = await _context.StaffInfos.FirstOrDefaultAsync(i => i.Id == id);
            if (staffInfos != null)
            {
                var checktime = await CheckTimeOut.Check(staffInfos.LastUpTime, model.LastUpTime);
                if (!checktime.Success)
                {
                    return checktime;
                }
                staffInfos.Email = model.Email;
                staffInfos.Name = model.Name;
                staffInfos.EntryTime = model.EntryTime;
                staffInfos.LastUpTime = DateTime.Now;
                staffInfos.Phone = model.Phone;
                staffInfos.PositionId = model.PositionId;
                if (model.WorkingStatus == Model.Enums.WorkingStatus.Quit)
                {
                    staffInfos.ResignationTime = DateTime.Now;
                }
                staffInfos.WorkingStatus = model.WorkingStatus;
            }
            result.Result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<ReturnPagin<List<ReturnStaffinfoDto>>> QueryPaginAsync(SelectStaffinfoDto model)
        {

            var result = new ReturnPagin<List<ReturnStaffinfoDto>>();

            var staffInfos = _context.StaffInfos.Include(i=>i.Position).AsNoTracking();

            result.Items = await staffInfos.OrderByDescending(i => i.CreateTime).Pagin(model).Select(i => new ReturnStaffinfoDto
            {
                 Id=i.Id,
                Email = i.Email,
                Name = i.Name,
                EntryTime = i.EntryTime,
                LastUpTime = i.LastUpTime,
                Phone = i.Phone,
                PositionName = i.Position.Name,
                ResignationTime = i.ResignationTime,
                WorkingStatus = i.WorkingStatus,

            }).ToListAsync();
            result.Count = await staffInfos.CountAsync();
            result.Number = model.Number;
            result.Page = model.Page;
            return result;
        }
    }
}
