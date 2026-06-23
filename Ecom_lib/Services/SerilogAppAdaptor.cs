using Ecom_lib.Base;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom_lib.Services
{
    public class SerilogAppAdaptor<T>(ILogger<T> logger) : IAppLogger<T> where T : class
    {
        

        public void LogError(Exception ex, string message)
        {
           logger.LogError(ex, message);
        }

        public void LogInfo(string message)
        {
            logger.LogWarning(message);
        }

        public void LogInformation(string message)
        {
            logger.LogInformation(message);
        }
    }
}
