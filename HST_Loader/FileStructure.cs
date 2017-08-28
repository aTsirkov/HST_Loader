using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HST_Loader
{
    [StructLayout(LayoutKind.Explicit, Pack = 1, CharSet = CharSet.Ansi, Size = 176)]
    public struct MASTERHEADER
    {
        [FieldOffset(0)]
        //[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        //public	string	    Title;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public	byte[]	    Title;
        [FieldOffset(128)]
        //[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
        //public string       ID;
        public UInt64 ID;
        [FieldOffset(136)]
        public	UInt16	    Type;
        [FieldOffset(138)]
        public	UInt16	    Version;
        [FieldOffset(140)]
        public	UInt32	    Alignment1;
        [FieldOffset(144)]
        public	UInt32	    Mode;
        [FieldOffset(148)]
        public	UInt16	    History;
        [FieldOffset(150)]
        public	UInt16	    nFiles;
        [FieldOffset(152)]
        public	UInt16	    Next;
        [FieldOffset(154)]
        public	UInt16	    AddOn;
        //[FieldOffset(156)]
        //[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
        //public string       Alignment;
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        //public byte[] Alignment;

    }

    [StructLayout(LayoutKind.Explicit, Pack = 1, CharSet = CharSet.Ansi, Size =144)]
    public struct HEADER
    {
        [FieldOffset(0)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
        public string       ID;
        [FieldOffset(8)]
        public	UInt16      Type;
        [FieldOffset(10)]
        public	UInt16      Version;
        [FieldOffset(12)]
        public	UInt32	    StartEvNo;
        [FieldOffset(16)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string LogName;
        [FieldOffset(96)]
        public	UInt32	    Mode;
        [FieldOffset(100)]
        public	UInt16	    Area;
        [FieldOffset(102)]
        public	UInt16	    Priv;
        [FieldOffset(104)]
        public	UInt16	    FileType;
        [FieldOffset(106)]
        public	UInt32	    SamplePeriod;
        [FieldOffset(110)]
        //[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
        //public string       sEngUnits;
        public UInt64 sEngUnits;
        [FieldOffset(118)]
        public	UInt32	    Format;
        [FieldOffset(122)]
        public	UInt32      StartTime;
        [FieldOffset(126)]
        public	UInt32	    EndTime;
        [FieldOffset(130)]
        public	UInt32	    DataLength;
        [FieldOffset(134)]
        public	UInt32	    FilePointer;
        [FieldOffset(138)]
        public	UInt32	    EndEvNo;
        [FieldOffset(142)]
        public UInt16       Alignment;
    }

    [StructLayout(LayoutKind.Explicit, Pack = 1, CharSet = CharSet.Ansi, Size = 288)]
    public struct HSTFILEHEADER
    {
        [FieldOffset(0)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 144)]
        public string   Name;
        [FieldOffset(144)]
        public HEADER   Header;
    }

    [StructLayout(LayoutKind.Explicit, Pack = 1, CharSet = CharSet.Ansi, Size = 272)]
    public struct DATAFILEHEADER
    {
        [FieldOffset(0)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 112)]
        public string Title;
        [FieldOffset(112)]
        public SCALES Scales;
        [FieldOffset(128)]
        public HEADER Header;
    }

    [StructLayout(LayoutKind.Explicit, Pack = 1, CharSet = CharSet.Ansi, Size = 16)]
    public struct SCALES
    {
        [FieldOffset(0)]
        public float	RawZero;
        [FieldOffset(4)]
        public float	RawFull;
        [FieldOffset(8)]
        public float	EngZero;
        [FieldOffset(12)]
        public float    EngFull;
    }

    [StructLayout(LayoutKind.Explicit, Pack = 1, CharSet = CharSet.Ansi, Size = 12)]
    public struct SCALEDEVENTSAMPLE
    {
        [FieldOffset(0)]
        public UInt32   Value;
        [FieldOffset(4)]
        public UInt32   Time;
        [FieldOffset(8)]
        public UInt32   Milliseconds;
    }

    [StructLayout(LayoutKind.Explicit, Pack = 1, CharSet = CharSet.Ansi, Size = 2)]
    public struct FLOATEVENTSAMPLE
    {
        [FieldOffset(0)]
        public UInt16 Value;
        //[FieldOffset(8)]
        //public UInt64 Time;
    }
}
