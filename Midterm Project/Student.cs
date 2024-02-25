namespace Midterm_Project
{
    public class Student : Person
    {
        public int RollNumber { get; set; }
        public char Grade { get; set; }


        public Student()
        {

        }

        public Student(string name, int rollNumber, char grade) : base(name)
        {
            RollNumber = rollNumber;
            Grade = grade;
        }

        public override string ToString()
        {
            return base.ToString() + $", Roll Number {RollNumber}, Grade {Grade}";
        }
    }
}