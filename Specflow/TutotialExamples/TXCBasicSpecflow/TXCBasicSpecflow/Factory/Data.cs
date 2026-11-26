using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TXCBasicSpecflow.Factory
{
    /*
     * Class to store datas.
     * Is instantiated at the beginning of every scenarios
     */
    public class Data
    {
        public Data()
        {

        }

        //Url
        public string URL = "";
        public string DEV_BASE_URL = "https://localhost:44310/";
        public string STAGING_BASE_URL = "https://localhost:44310/";
        public string UAT_BASE_URL = "https://localhost:44310/";


        // API call
        public string Environment = "";
        public Dictionary<string, string> parameters = new Dictionary<string, string>();
        public bool ResponseSuccess;
        public string ResponseMessage;

    }
}
