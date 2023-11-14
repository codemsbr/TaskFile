namespace TaskFile
{
    internal class Student
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Code { get; set; }

        public Student(string name, string surName, string code)
        {
            Name = name;
            SurName = surName;
            Code = code;
        }

        public override string ToString()
        {
            return $"{Code} {Name} {SurName}";
        }
    }
}
