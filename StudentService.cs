using Newtonsoft.Json;

namespace TaskFile
{
    internal class StudentService
    {
        public static List<Student> students = new List<Student>();

        public void AllMenuController()
        {
            Menu();
            int answer = Convert.ToInt32(Console.ReadLine());
            switch (answer)
            {
                case 1:
                    CreateStudent();
                    break;

                case 2:
                    Student studentRemove = CoreStudent();
                    RemoveStudent(studentRemove);
                    break;

                case 3:
                    Student studentEdit = CoreStudent();
                    EditStudent(studentEdit);
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }

        }

        public static void FileRead()
        {
            using (StreamReader sr = new StreamReader(FollderAndFileController.rootFile))
            {
                students = JsonConvert.DeserializeObject<List<Student>>(sr.ReadToEnd());
                if (students == null)
                    students = new List<Student>();
            }
        }

        public void FileWrite()
        {
            using (StreamWriter sw = new StreamWriter(FollderAndFileController.rootFile))
            {
                sw.WriteLine(JsonConvert.SerializeObject(students));
            }
        }

        public void CreateStudent()
        {
            Console.Write("Enter Code : ");
            string code = Console.ReadLine();

            Console.Write("Enter Name : ");
            string name = Console.ReadLine();

            Console.Write("Enter Surname : ");
            string surName = Console.ReadLine();

            if (students.Any(x => x.Code != code))
                students.Add(new Student(name, surName, code));
            else
                Console.WriteLine("Error");
        }

        public Student GetStudentByCore(string code)
        {
            return students.FirstOrDefault(x => x.Code == code);
        }

        public void RemoveStudent(Student stundent)
        {
            students.Remove(stundent);
        }

        public void EditStudent(Student student)
        {
            Console.WriteLine("1.Edit Student Name");
            Console.WriteLine("2.Edit Student SurName");
            Console.Write("Enter answer : ");
            int answer = Convert.ToInt32(Console.ReadLine());

            switch (answer)
            {
                case 1:
                    EditStudentName(student);
                    break;
                case 2:
                    EditStudentSurName(student);
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }

        public void GetAll()
        {
            #region Yol 1
            //using (StreamReader sr = new StreamReader(FollderAndFileController.rootFile))
            //{
            //    Console.WriteLine(sr.ReadToEnd());
            //}
            #endregion
            students.ForEach(x =>
            {
                Console.WriteLine(x);
            });
        }

        public Student CoreStudent()
        {
            GetAll();
            Console.Write("Enter Student Code : ");
            return GetStudentByCore(Console.ReadLine());
        }

        void EditStudentName(Student student)
        {
            Console.Write("Entre Name : ");
            student.Name = Console.ReadLine();
        }

        void EditStudentSurName(Student student)
        {
            Console.Write("Entre Sur Name : ");
            student.SurName = Console.ReadLine();
        }

        void Menu()
        {
            Console.WriteLine("1.Create Student");
            Console.WriteLine("2.Remove Student");
            Console.WriteLine("3.Edit Student");
            Console.Write("Enter Answer : ");
        }

    }
}
