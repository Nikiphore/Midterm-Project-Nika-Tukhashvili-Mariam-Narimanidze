namespace Midterm_Project
{

    public class Student : Person //ვქმნით კლასს და Person-ის შვილს ვხდით(ვიყენებთ მემკვიდრეობას) 
    {
        public int RollNumber { get; set; }
        public char Grade { get; set; }


        public Student()
        {

        }

        public Student(string name, int rollNumber, char grade) : base(name) //თან ვიძახებთ მშობლის კონსტრუქტორს
        {
            RollNumber = rollNumber;
            Grade = grade;
        }

        public override string ToString() //ფუნქცია ობიექტის გამოსატანად
        {
            return base.ToString() + $", Roll Number {RollNumber}, Grade {Grade}";
        }
    }
}