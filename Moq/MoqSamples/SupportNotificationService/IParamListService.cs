using System;
using System.Collections.Generic;
using System.Text;

namespace SupportNotificationService
{
    public delegate T GetDataDel<T>(string connectionStr);
    public delegate int GetTranBuffLogInfo(string connectionStr);
    public delegate void UpdateTranBuffLog(string connectionStr, int LogId, int NeedAlert);
    public interface IParamListService
    {
        Dictionary<string, string> getParamList<T>(string connectionStr, GetDataDel<T> getData);
        T getData<T>(string connectionStr);
    }
}
