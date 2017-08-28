using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HSTLoaderConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            HST_Loader.MasterFile mf = new HST_Loader.MasterFile("C:\\Users\\TsirkovAA\\Documents\\Visual Studio 2015\\Projects\\HST_Loader\\HST\\AI_CR_CLN_HMI.HST");
            foreach(HST_Loader.HSTFILEHEADER f in mf.HSTFiles)
            {
                string fileName = Path.GetFileName(f.Name);
                fileName = "C:\\Users\\TsirkovAA\\Documents\\Visual Studio 2015\\Projects\\HST_Loader\\HST\\" + fileName;
                HST_Loader.DataFile df = new HST_Loader.DataFile(fileName, true);
            }

        }
    }
}
