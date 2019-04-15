using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPMS.Model.Dto.Attendances;
using EPMS.Service.Services.AttendanceService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPMS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _service;
        public AttendanceController(IAttendanceService service)
        {
            _service = service;
        }

        /// <summary>
        /// 添加考勤记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(AddAttendanceDto model)
        {
            var result = await _service.CreateAsync(model);
            return Ok(result);
        }

        /// <summary>
        /// 添加或修改考勤时间
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateOrEditAttendanceTime")]
        public async Task<IActionResult> OutStock(AddOrEditAttendanceTimeDto model)
        {
            var result = await _service.CreateOrEditAttendanceTimeAsync(model);
            return Ok(result);
        }

        /// <summary>
        /// 分页查询考勤记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("QueryPagin")]
        public async Task<IActionResult> QueryPaginAsync(SelectAttendanceDto model)
        {

            var result = await _service.QueryPaginAsync(model);

            return Ok(result);
        }

        /// <summary>
        /// 获取当前考勤时间
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAttendanceTime")]
        public async Task<IActionResult> GetAttendanceTime()
        {
            var result = await _service.GetAttendanceTime();
            return Ok(result);
        }
    }
}