using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EPMSEF;
using EPMS.Model.Dto;
using EPMS.Model.Dto.Attendances;
using Microsoft.EntityFrameworkCore;

namespace EPMS.Service.Services.AttendanceService
{
    public class AttendanceService : IAttendanceService
    {
        private readonly EPMSContext _context;
        private readonly IMapper _mapper;
        public AttendanceService(EPMSContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ReturnData<bool>> CreateAsync(AddAttendanceDto model)
        {
            var result = new ReturnData<bool>();
            var attendanceTime = await _context.AttendanceTimeSets.FirstOrDefaultAsync();
            if (attendanceTime != null)
            {
                var attendanceAccess = await _context.Attendances.FirstOrDefaultAsync(i => i.WorkingTime.ToString("yyyy/MM/dd") == model.CreateTime.ToString("yyyy/MM/dd"));
                if (attendanceAccess != null)
                {
                    //如果当前有打卡记录 则更新下班时间
                    attendanceAccess.OffworkTime = model.CreateTime;
                    if (Convert.ToDateTime(model.CreateTime.ToString("HH:mm:ss")) > Convert.ToDateTime(attendanceTime.OffworkTime.AddSeconds(-1).ToString("HH:mm:ss")))
                    {
                        //判断打卡时间是否超过规定下班时间 超过则是正常下班 否者早退
                        attendanceAccess.IsLeaveEarly = false;
                    }
                    else
                    {
                        attendanceAccess.IsLeaveEarly = true;
                    }
                }
                else
                {
                    //否则新增上班时间
                    if (Convert.ToDateTime(model.CreateTime.ToString("HH:mm:ss")) > Convert.ToDateTime(attendanceTime.WorkingTime.AddSeconds(59).ToString("HH:mm:ss")))
                    {
                        //判断打卡时间是否超过规定上班班时间 超过则是迟到 否者正常
                        _context.Attendances.Add(new Model.Model.Attendance()
                        {
                            IsLeaveEarly = false,
                            IsLate = true,
                            OffworkTime = null,
                            StaffInfoId = model.StaffInfoId,
                            WorkingTime = model.CreateTime,
                        });
                    }
                    else
                    {
                        _context.Attendances.Add(new Model.Model.Attendance()
                        {
                            IsLeaveEarly = false,
                            IsLate = false,
                            OffworkTime = null,
                            StaffInfoId = model.StaffInfoId,
                            WorkingTime = model.CreateTime,
                        });
                    }
                }

            }
            result.Result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<ReturnData<bool>> CreateOrEditAttendanceTimeAsync(AddOrEditAttendanceTimeDto model)
        {
            var result = new ReturnData<bool>();
            var time = await _context.AttendanceTimeSets.FirstOrDefaultAsync();
            if (time != null)
            {
                //如果存在数据就更新数据 否者新增
                time.LastUpTime = DateTime.Now;
                time.OffworkTime = Convert.ToDateTime(model.OffworkTime);
                time.WorkingTime = Convert.ToDateTime(model.WorkingTime);
            }
            else
            {
                _context.AttendanceTimeSets.Add(new Model.Model.AttendanceTimeSet()
                {
                    OffworkTime = Convert.ToDateTime(model.OffworkTime),
                    WorkingTime = Convert.ToDateTime(model.WorkingTime),
                    CreateTime = DateTime.Now,
                    LastUpTime = DateTime.Now
                });
            }
            result.Result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<ReturnAttendanceTimeDto> GetAttendanceTime()
        {
            var result = await _context.AttendanceTimeSets.FirstOrDefaultAsync();
            if (result != null)
            {
                return new ReturnAttendanceTimeDto()
                {
                    Id = result.Id,
                    LastUpDateTime = result.LastUpTime,
                    OffworkTime = result.OffworkTime.ToString().Split(" ")[1],
                    WorkingTime = result.WorkingTime.ToString().Split(" ")[1]
                };
            }
            return null;
        }

        public async Task<ReturnPagin<List<ReturnAttendanceDto>>> QueryPaginAsync(SelectAttendanceDto model)
        {
            var result = new ReturnPagin<List<ReturnAttendanceDto>>();

            var attendances = _context.Attendances.Include(i => i.StaffInfo).AsNoTracking();

            if (model.BeginTime.HasValue)
            {
                attendances = attendances.Where(i => i.CreateTime >= model.BeginTime);
            }

            if (model.EndTime.HasValue)
            {
                attendances = attendances.Where(i => i.CreateTime <= model.EndTime);
            }

            if (model.IsLate.HasValue)
            {
                attendances = attendances.Where(i => i.IsLate == model.IsLate);
            }

            if (model.IsLeaveEarly.HasValue)
            {
                attendances = attendances.Where(i => i.IsLeaveEarly == model.IsLeaveEarly);
            }

            if (model.StaffInfoId.HasValue)
            {
                attendances = attendances.Where(i => i.StaffInfoId == model.StaffInfoId);
            }

            result.Count = await attendances.CountAsync();
            result.Page = model.Page;
            result.Number = model.Number;
            result.Items = await attendances.OrderByDescending(i => i.CreateTime)
                                            .Pagin(model)
                                            .Select(i => new ReturnAttendanceDto
                                            {
                                                IsLate = i.IsLate,
                                                IsLeaveEarly = i.IsLeaveEarly,
                                                Id = i.Id,
                                                OffworkTime = i.OffworkTime,
                                                StaffInfoName = i.StaffInfo.Name,
                                                WorkingTime = i.WorkingTime
                                            }).ToListAsync();

            return result;
        }
    }
}
