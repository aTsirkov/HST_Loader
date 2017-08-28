using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Text.RegularExpressions;

namespace HST_Loader
{
    public static class SerializeHelper
    {
        public static byte[] Serialize<T>(T s)
        where T : struct
        {
            var size = Marshal.SizeOf(typeof(T));
            var array = new byte[size];
            var ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(s, ptr, true);
            Marshal.Copy(ptr, array, 0, size);
            Marshal.FreeHGlobal(ptr);
            return array;
        }

        public static T Deserialize<T>(byte[] array)
            where T : struct
        {
            var size = Marshal.SizeOf(typeof(T));
            var ptr = Marshal.AllocHGlobal(size);
            Marshal.Copy(array, 0, ptr, size);
            var s = (T)Marshal.PtrToStructure(ptr, typeof(T));
            Marshal.FreeHGlobal(ptr);
            return s;
        }

        public static IEnumerable<string> ToCsv<T>(IEnumerable<T> objectlist, string separator = ",", bool header = true)
        {
            FieldInfo[] fields = typeof(T).GetFields();
            PropertyInfo[] properties = typeof(T).GetProperties();
            string str1;
            string str2;

            if (header)
            {
                str1 = String.Join(separator, fields.Select(f => f.Name).Concat(properties.Select(p => p.Name)).ToArray());
                str1 = str1 + Environment.NewLine;
                yield return str1;
            }
            foreach (var o in objectlist)
            {
                //regex is to remove any misplaced returns or tabs that would
                //really mess up a csv conversion.
                
                str2 = string.Join(separator, fields.Select(f => (Regex.Replace(Convert.ToString(f.GetValue(o)), @"\t|\n|\r", "") ?? "").Trim())
                   .Concat(properties.Select(p => (Regex.Replace(Convert.ToString(p.GetValue(o, null).ToString()), @"\t|\n|\r", "") ?? "").Trim())).ToArray());

                str2 = str2 + Environment.NewLine;
                yield return str2;
            }
        }

        public static DateTime CitectDateTime(UInt64 ticks)
        {
            System.DateTime ret = new DateTime(1970, 1, 1);
            ret = ret.AddSeconds(ticks);
            return ret;
        }
    }
}
