using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace SupportNotificationService
{
    public delegate object GetPropValueDel(object src, string propName);
    public interface ICommonMethod
    {
        int isValidEmail(string emailAddresses);
        bool isEmail(string inputEmail);
        DataSet ConvertToDataSet<T>(IList<T> list);
        DataSet ConvertObjectToDataSet(System.Collections.IList list);
        string ConvertHTMLStringToText(string htmlString);
        void SaveToFile(MemoryStream ms, string fileName);
        string ReadFileToString(string EmailTemplatePath);
        object GetPropValue(object src, string propName);
        string getTableData<T>(List<T> list, GetPropValueDel _getPropValueFunc);
    }
}
