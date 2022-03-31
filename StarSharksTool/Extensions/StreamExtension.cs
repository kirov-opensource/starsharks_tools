namespace StarSharksTool.Extensions
{
    internal static class StreamExtension
    {
        internal static Stream FromBytes(byte[] bytes)
        {
            var stream = new MemoryStream();
            stream.Write(bytes, 0, bytes.Length);
            return stream;
        }

    }
}
