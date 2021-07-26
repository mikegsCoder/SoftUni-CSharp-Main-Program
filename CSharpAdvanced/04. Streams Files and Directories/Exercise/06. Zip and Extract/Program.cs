using System.IO.Compression;

namespace _06._Zip_and_Extract
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "../../../copyMe.png";
            using (ZipArchive zipArchive = ZipFile.Open("../../../zipFile.zip", ZipArchiveMode.Create))
            {
                zipArchive.CreateEntryFromFile(filePath, "newName.png");
            }
            using (ZipArchive zipExtract = ZipFile.Open("../../../zipFile.zip", ZipArchiveMode.Read))
            {
                zipExtract.ExtractToDirectory("../../../");
            } 
        }
    }
}
