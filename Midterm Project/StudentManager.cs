using System.Threading.Channels;

namespace Midterm_Project
{
    public class StudentManager
    {
        private List<Student> _students = new List<Student>(); //სტუდენტების ლისტი

        public void AddStudent(string name, int rollnumber, char grade) //ფუნქცია ამატებს ახალ სტუდენტს
        {
            _students.Add(new Student(name, rollnumber, grade));
            Console.WriteLine("student added!");
        }

        public void ShowStudents() //ფუნქციას გამოაქვს სტუდენტების სია
        {
            if (_students.Count == 0) //ვამოწმებთ ცარიელი ხომ არ არის სია
            {
                Console.WriteLine("list of students is empty.");
            }
            else
            {
                Console.WriteLine("Students' information:");

                _students.ForEach(obj => Console.WriteLine(obj)); //ვიყენებთ ლამბდას სიის გამოსატანად
            }

        }

        public void SearchStudentByRollNumber(int rollnumber) //ვეძებთ სიაში სტუდენტს სიის ნომრით
        {
            bool exists = false;
            foreach (var item in _students)
            {
                if (item.RollNumber == rollnumber)
                {
                    Console.WriteLine($"student found:");
                    Console.WriteLine(item);
                    exists = true;
                    break; //ერთს იპოვის და გაჩერდება
                }
            }
            if (!exists)
            {
                Console.WriteLine("student not found.");
            }
        }

        public void UpdateGrade(int rollnumber, char grade) //ვანახლებთ ქულას
        {
            Student student = _students.Find(obj => rollnumber == obj.RollNumber); //ვეძებთ სიაში მითითებული სიის ნომრით სტუდენტს
            if (student != null)
            {
                student.Grade = grade; //ვანიჭებთ ახალ ქულას
            }
            else
            {
                Console.WriteLine("Student not found.");
            }

        }

        public bool Exists(int rollnumber)  //აბრუნებს ბულს, ამოწმებს არსებობს თუ არა კონკრეტული სტუდენტი სიაში
        {
            return _students.Find(obj => rollnumber == obj.RollNumber) != null;
        }
        public void Menu() //ვქმნით მენიუს
        {
            while (true)
            {
                Console.WriteLine($"1 - add student\n2 - show students\n3 - search student by roll number\n4 - update grade\n5 - exit");
                string temp = Console.ReadLine(); //მომხმარებელი ირჩევს მოქმედებას

                if (temp == "1") //ვამატებთ სტუდენტს
                {
                    Console.Write("enter student name: ");
                    string name = Console.ReadLine();
                    Console.Write("enter roll number: ");
                    int rollnumber;

                    while (!int.TryParse(Console.ReadLine(), out rollnumber) || Exists(rollnumber) || rollnumber < 0) //ვამოწმებთ სწორად შეჰყავს თუ არა სიის ნომერი,უნდა იყოს ინტ ტიპის, არ უნდა მეორდებოდეს სიაში და არ უნდა იყოს უარყოფითი რიცხვი
                    {
                        Console.Write("student already exists or roll number is incorrect.\nenter roll number: ");

                    }
                    Console.Write("enter grade: ");
                    char grade;

                    while (!char.TryParse(Console.ReadLine().ToUpper(), out grade) || !(grade == 'A' || grade == 'B' || grade == 'C' || grade == 'D' || grade == 'E' || grade == 'F')) //ვამოწმებთ ქულა თუ სწორად შეჰყავს, უნდა იყოს ჩარი და მოიცავდეს A-F შუალედს
                    {
                        Console.Write("enter correct grade[A-F]: ");

                    }

                    AddStudent(name, rollnumber, grade); //ვამატებთ სტუდენტს
                    Console.WriteLine("student successfully added");
                }


                else if (temp == "2") //გამოგვაქვს სია
                {
                    ShowStudents();
                }

                else if (temp == "3") //ვეძებთ სტუდენტს სიის ნომრით
                {
                    Console.Write("enter roll number: ");
                    int rollnumber;

                    while (!int.TryParse(Console.ReadLine(), out rollnumber) || rollnumber < 0) //უნდა იყოს ინტ და არაუარყოფითი
                    {
                        Console.Write("roll number is incorrect.\nenter roll number: ");

                    }
                    SearchStudentByRollNumber(rollnumber);
                }

                else if (temp == "4") //ვცვლით ქულას
                {
                    Console.Write("enter roll number: ");
                    int rollnumber;

                    while (!int.TryParse(Console.ReadLine(), out rollnumber) || rollnumber < 0) //უნდა იყოს ინტ და არაუარყოფითი
                    {
                        Console.Write("roll number is incorrect.\nenter roll number: ");

                    }

                    Console.Write("enter grade: ");
                    char grade;

                    while (!char.TryParse(Console.ReadLine().ToUpper(), out grade) || !(grade == 'A' || grade == 'B' || grade == 'C' || grade == 'D' || grade == 'E' || grade == 'F')) //ვამოწმებთ ქულა თუ სწორად შეჰყავს, უნდა იყოს ჩარი და მოიცავდეს A-F შუალედს
                    {
                        Console.Write("enter correct grade[A-F]: ");

                    }

                    UpdateGrade(rollnumber, grade);

                }

                else if (temp == "5") //მთავრდება პროგრამა
                {
                    Console.WriteLine("bye bye..");
                    return;
                }

                else { Console.WriteLine("incorrect input!"); }
            }
        }
    }
}