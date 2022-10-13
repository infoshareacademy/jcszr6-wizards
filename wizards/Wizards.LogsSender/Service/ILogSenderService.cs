using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizards.LogsSender.Service
{
    public interface ILogSenderService
    {
        Task SendLogAsync(LogLevel logLevel, string message, params object?[] args);
    }
}