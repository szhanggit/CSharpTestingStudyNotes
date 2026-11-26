using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TXCBasicSpecflow.Factory
{
    /*
     * Static class to get stored datas
     * Is instantiated at the start of every scenarios
     */

    public class DataManager
    {
        private static Data data;

        public static Data GetData()
        {
            return data;
        }

        public static void SetData(Data datagen)
        {
            data = datagen;
        }

    }
}
