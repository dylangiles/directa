using System;
namespace Directa.Runtime
{
    public static class ByteConverter
    {
        public static int IntegerFromBytes(byte[] bytes)
        {
            int result = (bytes[0] << 24)
                + (bytes[1] << 16)
                + (bytes[2] << 8)
                + bytes[3];
            return result;
        }

        public static byte[] BytesFromInteger(int value)
        {
            byte[] result = new byte[sizeof(int)];
            result[0] = (byte)((value & 0xFF000000) >> 24);
            result[1] = (byte)((value & 0x00FF0000) >> 16);
            result[2] = (byte)((value & 0x0000FF00) >> 8);
            result[3] = (byte)(value & 0xFF000000);
            return result;
        }
    }
}
