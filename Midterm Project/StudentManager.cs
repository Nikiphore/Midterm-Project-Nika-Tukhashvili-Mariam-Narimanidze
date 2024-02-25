namespace Midterm_Project
{
    public class StudentManager
    {
        private List<Student> _students = new List<Student>();

        public void AddStudent(string name, int rollnumber, char grade)
        {
            _students.Add(new Student(name, rollnumber, grade));
            Console.WriteLine("student added!");
        }

        public void ShowStudents()
        {
            if (_students.Count == 0)
            {
                Console.WriteLine("list of students is empty.");
            }
            else
            {
                Console.WriteLine("Students' information:");

                _students.ForEach(obj => Console.WriteLine(obj));
            }

        }

        public void SearchStudentByRollNumber(int rollnumber)
        {
            bool exists = false;
            foreach (var item in _students)
            {
                if (item.RollNumber == rollnumber)
                {
                    Console.WriteLine($"student found:");
                    Console.WriteLine(item);
                    exists = true;
                    break;
                }
            }
            if (!exists)
            {
                Console.WriteLine("student not found.");
            }
        }

        public void UpdateGrade(int rollnumber, char grade)
        {
            Student student = _students.Find(obj => rollnumber == obj.RollNumber);
            if (student != null)
            {
                student.Grade = grade;
            }
            else
            {
                Console.WriteLine("Student not found.");
            }

        }

        public bool Exists(int rollnumber)
        {
            return _students.Find(obj => rollnumber == obj.RollNumber) != null;
        }
        public void Menu()
        {
            while (true)
            {
                Console.WriteLine($"1 - add student\n2 - show students\n3 - search student by roll number\n4 - update grade\n5 - exit");
                string temp = Console.ReadLine();

                if (temp == "1")
                {
                    Console.Write("enter student name: ");
                    string name = Console.ReadLine();
                    Console.Write("enter roll number: ");
                    int rollnumber;

                    while (!int.TryParse(Console.ReadLine(), out rollnumber) || Exists(rollnumber) || rollnumber < 0)
                    {
                        Console.Write("student already exists or roll number is incorrect.\nenter roll number: ");

                    }
                    Console.Write("enter grade: ");
                    char grade;

                    while (!char.TryParse(Console.ReadLine().ToUpper(), out grade) || !(grade == 'A' || grade == 'B' || grade == 'C' || grade == 'D' || grade == 'E' || grade == 'F'))
                    {
                        Console.Write("enter correct grade[A-F]: ");

                    }

                    AddStudent(name, rollnumber, grade);
                    Console.WriteLine("student successfully added");
                }


                else if (temp == "2")
                {
                    ShowStudents();
                }

                else if (temp == "3")
                {
                    Console.Write("enter roll number: ");
                    int rollnumber;

                    while (!int.TryParse(Console.ReadLine(), out rollnumber) || rollnumber < 0)
                    {
                        Console.Write("roll number is incorrect.\nenter roll number: ");

                    }
                    SearchStudentByRollNumber(rollnumber);
                }

                else if (temp == "4")
                {
                    Console.Write("enter roll number: ");
                    int rollnumber;

                    while (!int.TryParse(Console.ReadLine(), out rollnumber) || rollnumber < 0)
                    {
                        Console.Write("roll number is incorrect.\nenter roll number: ");

                    }

                    Console.Write("enter grade: ");
                    char grade;

                    while (!char.TryParse(Console.ReadLine().ToUpper(), out grade) || !(grade == 'A' || grade == 'B' || grade == 'C' || grade == 'D' || grade == 'E' || grade == 'F'))
                    {
                        Console.Write("enter correct grade[A-F]: ");

                    }

                    UpdateGrade(rollnumber, grade);

                }

                else if (temp == "5")
                {
                    Console.WriteLine("bye bye..");
                    return;
                }

                else { Console.WriteLine("incorrect input!"); }
            }
        }
    }
}