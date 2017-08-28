using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HST_Loader
{
    public class MasterFile
    {
        private MASTERHEADER masterHeader = new MASTERHEADER();
        private List<HSTFILEHEADER> hstFiles = new List<HSTFILEHEADER>();

        public MasterFile(string fileName)
        {
            try
            {
                using (FileStream fileStreem = File.OpenRead(fileName))
                {
                    using (BinaryReader file = new BinaryReader(fileStreem))
                    {
                        Int32 pos = 0;
                        Byte[] body;
                        file.BaseStream.Seek(pos, SeekOrigin.Begin);

                        body = file.ReadBytes(Marshal.SizeOf(typeof(MASTERHEADER)));
                        masterHeader = SerializeHelper.Deserialize<MASTERHEADER>(body);

                        while (file.BaseStream.Length > file.BaseStream.Position)
                        {
                            body = file.ReadBytes(Marshal.SizeOf(typeof(HSTFILEHEADER)));

                            HSTFILEHEADER hfh = new HSTFILEHEADER();
                            hfh = SerializeHelper.Deserialize<HSTFILEHEADER>(body);

                            hstFiles.Add(hfh);
                        }
                    }
                }
            }
            catch  { }
        }

        public MASTERHEADER MasterHeader
        {
            get { return masterHeader; }
        }

        public List<HSTFILEHEADER> HSTFiles
        {
            get { return hstFiles; }
        }
    }

    public class DataFile
    {
        private DATAFILEHEADER dataHeader = new DATAFILEHEADER();
        private Dictionary<Int32, FLOATEVENTSAMPLE> hstValues = new Dictionary<Int32, FLOATEVENTSAMPLE>();

        public DataFile(string fileName, bool onlyChanges)
        {
            try
            {
                using (FileStream fileStreem = File.OpenRead(fileName))
                {
                    using (BinaryReader file = new BinaryReader(fileStreem))
                    {
                        Int32 pos = 0;
                        Byte[] body;
                        file.BaseStream.Seek(pos, SeekOrigin.Begin);

                        body = file.ReadBytes(Marshal.SizeOf(typeof(DATAFILEHEADER)));
                        dataHeader = SerializeHelper.Deserialize<DATAFILEHEADER>(body);

                        FLOATEVENTSAMPLE prev = new FLOATEVENTSAMPLE();
                        Int32 Ticket = 0;

                        while (file.BaseStream.Length > file.BaseStream.Position)
                        {
                            body = file.ReadBytes(Marshal.SizeOf(typeof(FLOATEVENTSAMPLE)));
                            Ticket++;

                            FLOATEVENTSAMPLE hfh = new FLOATEVENTSAMPLE();
                            hfh = SerializeHelper.Deserialize<FLOATEVENTSAMPLE>(body);

                            if (!onlyChanges || !prev.Equals(hfh))
                                hstValues.Add(Ticket, hfh);
                            prev = hfh;
                        }
                    }
                }
            }
            catch { }
        }

        public DATAFILEHEADER DataHeader
        {
            get { return dataHeader; }
        }

        public Dictionary<Int32, FLOATEVENTSAMPLE> HSTValues
        {
            get { return hstValues; }
        }

    }

}
