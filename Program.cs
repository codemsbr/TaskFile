namespace TaskFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FollderAndFileController follderAndFileController = new FollderAndFileController();
            StudentService studentService = new StudentService();
            follderAndFileController.CreateFollder();
            follderAndFileController.CreateFile();
            StudentService.FileRead();

            bool isContinued = true;
            do
            {
                studentService.AllMenuController();
                Console.WriteLine("Do you want to continue ? Y/N");
                isContinued = Console.ReadLine() == "Y";
                studentService.FileWrite();
            }
            while (isContinued);
        }
    }
}