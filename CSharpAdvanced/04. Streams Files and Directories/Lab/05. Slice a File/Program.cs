using System;
using System.IO;

namespace _05._Slice_a_File
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream streamReader = new FileStream("../../../sliceMe.txt", FileMode.Open))
            {
                int chunkSize = (int)Math.Ceiling(streamReader.Length / 4.0);

                for (int i = 0; i < 4; i++)
                {
                    byte[] buffer = new byte[1];
                    int count = 0;

                    using (FileStream streamWriter = new FileStream($"../../../slice-{i+1}.txt", FileMode.Create, FileAccess.Write))
                    {
                        while (count < chunkSize)
                        {
                            streamReader.Read(buffer, 0, buffer.Length);
                            streamWriter.Write(buffer, 0, buffer.Length);
                            count += buffer.Length;
                        }

                        if (streamReader.Position != streamReader.Length && i == 3)
                        {
                            byte[] lastBuffer = new byte[streamReader.Length - streamReader.Position];
                            streamReader.Read(lastBuffer, 0, lastBuffer.Length);
                            streamWriter.Write(lastBuffer, 0, lastBuffer.Length);
                        }
                    }
                }
            }
        }
    }
}
