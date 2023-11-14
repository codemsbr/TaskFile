namespace TaskFile
{
    internal class FollderAndFileController
    {
        //public static string rootFile = Path.GetFullPath(Path.Combine(rootFolder + @"jsonData.json"));
        //public static string rootFile = rootFolder + @"jsonData.json";
        public static string rootFile = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory() + @"..\..\..\..\DataBase\" + "jsonData.json"));

        public static string rootFolder = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory() + @"..\..\..\..\" + "DataBase"));

        public void CreateFollder()
        {
            if (!Directory.Exists(rootFolder))
                Directory.CreateDirectory(rootFolder);
        }

        public void CreateFile()
        {
            if (FileAndFollder())
                File.Create(rootFile);
        }

        public bool FileAndFollder() => Directory.Exists(rootFolder) && !File.Exists(rootFile);
    }
}
