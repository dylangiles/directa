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

        public static long LongFromBytes(byte[] bytes)
        {
            long result = ((long)bytes[0] << 56)
                          + ((long)bytes[1] << 48)
                          + ((long)bytes[2] << 40)
                          + ((long)bytes[3] << 32)
                          + (bytes[4] << 24)
                          + (bytes[5] << 16)
                          + (bytes[6] << 8)
                          + bytes[7];
            return result;
        }


        public static byte[] BytesFromInteger(int value)
        {
            byte[] result = new byte[sizeof(int)];
            result[3] = (byte)((value & 0xFF000000) >> 24);
            result[2] = (byte)((value & 0x00FF0000) >> 16);
            result[1] = (byte)((value & 0x0000FF00) >> 8);
            result[0] = (byte)(value & 0x000000FF);
            return result;
        }

        public static byte[] BytesFromDouble(double value) => BitConverter.GetBytes(value);

        public static byte[] BytesFromLong(long value) => BitConverter.GetBytes(value);

    }
}
