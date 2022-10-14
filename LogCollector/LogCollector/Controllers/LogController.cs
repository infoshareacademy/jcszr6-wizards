using AutoMapper;
using LogCollector.Dto;
using LogCollector.Models;
using LogCollector.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace LogCollector.Controllers
{
    [Route("api/logs")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly LogDbContext _logDbContext;
        private readonly IMapper _mapper;
        public LogController(LogDbContext logDbContext, IMapper mapper)
        {
            _logDbContext = logDbContext;
            _mapper = mapper;
        }
        
        [HttpGet("api/logs/{id}")]
        public async Task<IActionResult> GetLogAsync(int id)
        {
            var log = await _logDbContext.Logs.SingleOrDefaultAsync(l => l.Id == id);
            var logDto = _mapper.Map<LogDto>(log);
            return Ok(logDto);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetLogByProperty(
            [FromQuery] DateTime? startTimeStamp,
            [FromQuery] DateTime? endTimeStamp,
            [FromQuery] string? appName,
            [FromQuery] string? logLevel)
        {
            var logs = _logDbContext.Logs.AsEnumerable();
            if (startTimeStamp != null && endTimeStamp != null)
            {
                logs = logs.Where(l => l.TimeStamp >= startTimeStamp && l.TimeStamp <= endTimeStamp);
            }

            if (appName != null)
            {
                logs = logs.Where(l => l.AppName.ToLower() == appName.ToLower());
            }

            if (logLevel != null)
            {
                logs = logs.Where(l => l.LogLevel.ToLower() == logLevel.ToLower());
            }

            return Ok(logs.ToList());
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Request invalid", typeof(ProblemDetails))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Internal server error occurs")]
        public async Task<IActionResult> PostLogAsync(LogDto logDto)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var log = _mapper.Map<Log>(logDto);
            _logDbContext.Logs.Add(log);
            await _logDbContext.SaveChangesAsync();
            return Ok(logDto);
        }
    }
}
