using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EPMSEF;
using EPMS.Model.Dto;
using EPMS.Model.Dto.Positions;
using Microsoft.EntityFrameworkCore;

namespace EPMS.Service.Services.PositionService
{
    public class PositionService : IPositionService
    {
        private readonly EPMSContext _context;
        private readonly IMapper _mapper;
        public PositionService(EPMSContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ReturnData<bool>> CreateAsync(AddPositionDto model)
        {
            var result = new ReturnData<bool>();
            var position = await _context.Positions.FirstOrDefaultAsync(i => i.DepartmentId == model.DepartmentId && i.Name == model.Name);
            if (position != null)
            {
                result.Message = "同一部门存在相同职位，添加失败";
                result.Result = false;
                return result;
            }
            _context.Positions.Add(new Model.Model.Position
            {
                DepartmentId = model.DepartmentId,
                Name = model.Name
            });
            result.Result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var position = await _context.Positions.FirstOrDefaultAsync(i => i.Id == id);
            if (position != null)
            {
                _context.Positions.Remove(position);
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ReturnData<bool>> EditAsync(int id, EditPositionDto model)
        {
            var result = new ReturnData<bool>();
            var check = await _context.Positions.FirstOrDefaultAsync(i => i.DepartmentId == model.DepartmentId && i.Name == model.Name && i.Id != id);
            if (check != null)
            {
                result.Message = "同一部门存在相同职位，修改失败";
                result.Result = false;
                return result;
            }
            var position = await _context.Positions.FirstOrDefaultAsync(i => i.Id == id);
            if (position != null)
            {
                var checktime = await CheckTimeOut.Check(position.LastUpTime, model.LastUpTime);
                if (!checktime.Success)
                {
                    return checktime;
                }
                position.Name = model.Name;
                position.DepartmentId = model.DepartmentId;
            }
            result.Result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<List<ReturnPositionDto>> GetPositionByDepartmentId(int id)
        {
            var positions = await _context.Positions.Include(i => i.Department).Where(i => i.DepartmentId == id).Select(i => new ReturnPositionDto
            {
                DepartmentName = i.Department.Name,
                Id = i.Id,
                LastUpTime = i.LastUpTime,
                CreateTime = i.CreateTime,
                Name = i.Name
            }).ToListAsync();
            return positions;
        }

        public async Task<ReturnPagin<List<ReturnPositionDto>>> QueryPaginAsync(SelectPositionDto model)
        {

            var result = new ReturnPagin<List<ReturnPositionDto>>();

            var positions = _context.Positions.Include(i => i.Department).AsNoTracking();

            result.Items = await positions.OrderByDescending(i => i.CreateTime).Pagin(model).Select(i => new ReturnPositionDto
            {
                DepartmentName = i.Department.Name,
                Id = i.Id,
                LastUpTime = i.LastUpTime,
                CreateTime = i.CreateTime,
                Name = i.Name
            }).ToListAsync();
            result.Count = await positions.CountAsync();
            result.Number = model.Number;
            result.Page = model.Page;
            return result;
        }

    }
}
