
using Midterm_Project;
using System.Data;
using System.Text;

#region Calculator function
void Calc()
{

    int a, b;
    string temp;

    while (true)
    {
        Console.Write("enter first number: ");
        if (int.TryParse(Console.ReadLine(), out a))
        {
            break;
        }
        Console.WriteLine("enter valid number!");
    }
    while (true)
    {
        Console.Write("enter second number: ");
        if (int.TryParse(Console.ReadLine(), out b))
            break;
        Console.WriteLine("enter valid number!");
    }
    while (true)
    {
        Console.Write("enter operator [+,-,*,/]: ");
        temp = Console.ReadLine();
        if (temp == "+" || temp == "-" || temp == "*" || temp == "/")
            break;
        Console.WriteLine("enter valid operator!");
    }




    try
    {
        switch (temp)
        {
            case "+":
                Console.WriteLine($"{a}+{b}={a + b}");
                break;
            case "-":
                Console.WriteLine($"{a}-{b}={a - b}");
                break;
            case "*":
                Console.WriteLine($"{a}*{b}={a * b}");
                break;
            case "/":
                if (b == 0)
                {
                    throw new DivideByZeroException("Can't divide by 0!");
                }
                Console.WriteLine($"{a}/{b}={(double)a / b}");
                break;

        }
    }
    catch (DivideByZeroException dv)
    {
        Console.WriteLine(dv.Message);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }


}

//Calc();


#endregion



#region guess number game
void GuessNumber()
{
    Console.WriteLine("computer picked a number between 0 and 100");
    int n = new Random().Next(0, 101);
    int a = -1, counter = 0;

    do
    {
        Console.Write("guess the number: ");
        a = int.Parse(Console.ReadLine());
        counter++;
        if (a == n)
        {
            Console.WriteLine($"congratulations, you guessed the number in {counter} attempts!");
        }
        else if (a > n)
        {
            Console.WriteLine("computer's number is lower.");
        }
        else
        {
            Console.WriteLine("computer's number is higher");
        }

    }
    while (n != a);

}

//GuessNumber();


#endregion



#region hangman game
void Hangman()
{
    string[] strings = { "computer", "laptop", "water", "dog", "cat", "plant", "guitar", "program", "child", "book" };
    string word = strings[new Random().Next(0, strings.Length)];
    Console.Write("enter maximum number of attempts: ");
    int attempts = int.Parse(Console.ReadLine());
    string answer = "";
    for (int i = 0; i < word.Length; i++)
    {
        answer += "_ ";
    }
    Console.WriteLine(answer);

    while (attempts > 0)
    {
        attempts--;
        Console.WriteLine("enter letter: ");
        char ch = char.Parse(Console.ReadLine());

        if (word.Contains(ch))
        {
            char[] charArray = answer.ToCharArray();
            for (int j = 0; j < word.Length; j++)
            {
                if (word[j] == ch)
                {
                    charArray[2 * j] = ch;
                }
            }
            answer = new string(charArray);

            if (!answer.Contains("_"))
            {
                Console.WriteLine("congratulations, you guessed the word!");
                Console.WriteLine(answer);
                break;
            }

            Console.WriteLine($"you guessed the letter. {attempts} attempts left.");
            Console.WriteLine(answer);
        }
        else
        {
            Console.WriteLine($"can't guess the letter. {attempts} attempts left.");
        }
    }
    if (attempts == 0)
        Console.WriteLine("you failed!");
}

//Hangman();


#endregion



#region translator
void Translator()
{
    string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\geotoeng.txt";
    using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
    {
        using (StreamWriter sw = new StreamWriter(fs))
        {
            sw.WriteLine("sarke-mirror\r\nwigni-book\r\nmagida-table\r\nqalaqi-city\r\nchanta-bag\r\nskami-chair\r\n");
        }
    }

    path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\engtogeo.txt";
    using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
    {
        using (StreamWriter sw = new StreamWriter(fs))
        {
            sw.WriteLine("mirror-sarke\r\nbook-wigni\r\ntable-magida\r\ncity-qalaqi\r\nbag-chanta\r\nchair-skami");
        }
    }

    path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\geotorus.txt";
    using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
    {
        using (StreamWriter sw = new StreamWriter(fs))
        {
            sw.WriteLine("sarke-zerkalo\r\nwigni-kniga\r\nmagida-stol\r\nqalaqi-gorod\r\nchanta-sumka");
        }
    }

    path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\rustogeo.txt";
    using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
    {
        using (StreamWriter sw = new StreamWriter(fs))
        {
            sw.WriteLine("zerkalo-sarke\r\nkniga-wigni\r\nstol-magida\r\ngorod-qalaqi\r\nsumka-chanta");
        }
    }


    string from = "", to = "";

    while (true)
    {
        Console.WriteLine("choose number: \n1 - from georgian to english\n2 - from english to georgian\n3 - from georgian to russian\n4 - from russian to georgian\n5 - exit program");
        path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string temp;


        while (true)
        {
            temp = Console.ReadLine();
            bool endwhile = true;

            switch (temp)
            {
                case "1":
                    path += @"\geotoeng.txt";
                    from = "geo";
                    to = "eng";
                    break;
                case "2":
                    path += @"\engtogeo.txt";
                    from = "eng";
                    to = "geo";
                    break;
                case "3":
                    path += @"\geotorus.txt";
                    from = "geo";
                    to = "rus";
                    break;
                case "4":
                    path += @"\rustogeo.txt";
                    from = "rus";
                    to = "geo";
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("enter correct number!");
                    endwhile = false;
                    break;
            }

            if (endwhile) { break; }


        }


        Console.WriteLine("enter word or phrase to translate: ");
        string text = Console.ReadLine();
        bool notranslation = true;
        try
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (text == line.Split("-")[0])
                    {
                        Console.WriteLine($"translated text: {line.Split("-")[1]}");
                        notranslation = false;
                        break;
                    }
                }
            }
            if (notranslation)
            {
                Console.WriteLine($"{text} not found in dictionary. enter translation: ");
                string translation = Console.ReadLine();
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine($"{text}-{translation}");
                }

                path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $@"\{to}to{from}.txt";
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine($"{translation}-{text}");
                }
                Console.WriteLine("translation added!");

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }


}

//Translator();


#endregion



#region ATM
void Atm()
{
    string dirPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\users";
    DirectoryInfo dir = new DirectoryInfo(dirPath);
    dir.Create();

    while (true)
    {
        Console.WriteLine("1 - register user\n2 - check balanse\n3 - deposit money\n4 - withdraw money\n5 - exit");
        string temp = Console.ReadLine();
        if (temp == "5") { break; }

        if (temp == "1")
        {
            Console.Write("enter username: ");
            string username = Console.ReadLine();
            string path = dirPath + @$"\{username}.txt";
            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Exists)
            {
                Console.WriteLine($"user {username} already exists!");
            }
            else
            {
                Random rand = new Random();
                int balance = rand.Next(500, 10000);
                //Console.Write("enter balance: ");
                //int balance = int.Parse(Console.ReadLine());
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(balance);
                }
                Console.WriteLine("user added!");
            }

        }
        else if (temp == "2")
        {
            Console.Write("enter username: ");
            string username = Console.ReadLine();
            string path = dirPath + @$"\{username}.txt";

            FileInfo fileInfo = new FileInfo(path);
            if (!fileInfo.Exists)
            {
                Console.WriteLine($"{username} doesn't exist!");
                continue;
            }

            string line;
            int balance;
            using (StreamReader sr = new StreamReader(path))
            {
                if ((line = sr.ReadLine()) != null)
                {
                    balance = int.Parse(line);
                    Console.WriteLine($"balance: ${balance}");
                }
            }
        }
        else if (temp == "3")
        {
            Console.Write("enter username: ");
            string username = Console.ReadLine();
            string path = dirPath + @$"\{username}.txt";

            FileInfo fileInfo = new FileInfo(path);
            if (!fileInfo.Exists)
            {
                Console.WriteLine($"{username} doesn't exist!");
                continue;
            }

            int newmoney, oldmoney = 0;
            string line;
            using (StreamReader sr = new StreamReader(path))
            {
                if ((line = sr.ReadLine()) != null)
                {
                    oldmoney = int.Parse(line);
                }
            }


            Console.Write("enter amount of money: ");
            while (true)
            {
                try
                {
                    newmoney = int.Parse(Console.ReadLine());
                    if (newmoney < 0)
                    {
                        Console.Write("enter positive number: ");
                        continue;
                    }
                    newmoney += oldmoney;
                    break;
                }
                catch (OverflowException oe)
                {
                    Console.Write("enter lower number: ");
                }
                catch (Exception e)
                {
                    Console.Write("enter correct number: ");
                }
            }
            File.WriteAllText(path, newmoney.ToString());
            Console.WriteLine($"total amount: {newmoney}");

        }
        else if (temp == "4")
        {
            Console.Write("enter username: ");
            string username = Console.ReadLine();
            string path = dirPath + @$"\{username}.txt";

            FileInfo fileInfo = new FileInfo(path);
            if (!fileInfo.Exists)
            {
                Console.WriteLine($"{username} doesn't exist!");
                continue;
            }

            int newmoney, oldmoney = 0;
            string line;
            using (StreamReader sr = new StreamReader(path))
            {
                if ((line = sr.ReadLine()) != null)
                {
                    oldmoney = int.Parse(line);
                }
            }


            Console.Write("enter amount of money: ");
            while (true)
            {
                try
                {
                    newmoney = int.Parse(Console.ReadLine());
                    if (newmoney < 0)
                    {
                        Console.Write("enter positive number: ");
                        continue;
                    }
                    if (newmoney > oldmoney)
                    {
                        Console.Write("not enough money!\nenter lower number: ");
                        continue;
                    }
                    newmoney = oldmoney - newmoney;
                    break;
                }
                catch (OverflowException oe)
                {
                    Console.Write("enter lower number: ");
                }
                catch (Exception e)
                {
                    Console.Write("enter correct number: ");
                }
            }
            File.WriteAllText(path, newmoney.ToString());
            Console.WriteLine($"total amount: {newmoney}");
        }
        else
        {
            Console.WriteLine("wrong input!");
        }

    }
}


//Atm();



#endregion


#region bookmanager

/*
BookManager bookManager = new BookManager();
//bookManager.Menu();
bookManager.AddBook("tyeebis mefe", "dato turashvili", 2005);
bookManager.AddBook("frankenshteini", "meri sheli", 1846);
bookManager.AddBook("jinsebis taoba", "dato turashvili", 2001);
bookManager.AddBook("davit agmashenebeli", "konstantine gamsaxurdia", 1971);

bookManager.ShowBooks();
bookManager.SearchBookByTitle("frankenshteini");
bookManager.SearchBookByAuthor("dato turashvili");
*/

#endregion

#region studentmanager

/*
StudentManager studentManager = new StudentManager();
//studentManager.Menu();

studentManager.AddStudent("mariami", 15, 'A');
studentManager.AddStudent("nika", 17, 'B');
studentManager.AddStudent("elene", 20, 'D');
studentManager.AddStudent("nugzari", 10, 'F');
studentManager.ShowStudents();
studentManager.SearchStudentByRollNumber(17);
studentManager.SearchStudentByRollNumber(65);
studentManager.UpdateGrade(20, 'C');
studentManager.ShowStudents();
*/



#endregion