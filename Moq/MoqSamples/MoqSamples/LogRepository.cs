using System;
using System.Collections.Generic;
using System.Text;

namespace MoqSamples
{
    public interface ILogRepository
    {
        void Write(Exception ex, string param1, string param2, string param3, string param4, string param5);
    }
    public class LogRepository : ILogRepository
    {
        public void Write(Exception ex, string param1, string param2, string param3, string param4, string param5) {
            return;
        }
    }
}
