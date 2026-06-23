using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom_lib.Base
{
    public interface IAppLogger<T>
    {
        void LogInformation(string message);
        void LogInfo(string message);
        void LogError( Exception ex,string message);
    }
}
