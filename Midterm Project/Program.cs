
using Midterm_Project;
using System.Data;
using System.Diagnostics;
using System.Text;

#region Calculator function
void Calc() //ვქმნით კალკულატორის ფუნქციას
{

    int a, b;
    char temp;

    Console.Write("enter first number: "); //შემოგვყავს პირველი რიცხვი
    while (!int.TryParse(Console.ReadLine(), out a)) //ვამოწმებთ int ტიპის შემოდის თუ არა, თუ კი ვწერთ ცვლად a-ში
    {
        Console.Write("enter valid number: ");
    }


    Console.Write("enter second number: "); //შემოგვყავს პირველი რიცხვი
    while (!int.TryParse(Console.ReadLine(), out b)) //ვამოწმებთ int ტიპის შემოდის თუ არა, თუ კი ვწერთ ცვლად b-ში
    {
        Console.Write("enter valid number: ");
    }


    Console.Write("enter operator [+,-,*,/]: "); //ვირჩევთ მოქმედებას
    while (!char.TryParse(Console.ReadLine(), out temp) || !(temp == '+' || temp == '-' || temp == '*' || temp == '/')) //ვამოწმებთ მითითებული ოპერატორებიდან თუ შეგვყავს სწორად
    {
        Console.Write("enter valid operator: ");
    }


    try
    {
        switch (temp) //ვასრულებთ მოქმედებებს
        {
            case '+':
                Console.WriteLine($"{a}+{b}={a + b}");
                break;
            case '-':
                Console.WriteLine($"{a}-{b}={a - b}");
                break;
            case '*':
                Console.WriteLine($"{a}*{b}={a * b}");
                break;
            case '/':
                if (b == 0) //ვამოწმებთ 0-ზე ხომ არ ვყოფთ
                {
                    throw new DivideByZeroException("Can't divide by 0!"); //გადავცემთ ახალ exception-ს
                }
                Console.WriteLine($"{a}/{b}={(double)a / b}");
                break;

        }
    }
    catch (DivideByZeroException dv)
    { //თუ ნოლზე გაყოფა მოხდება, აღმოაჩენს
        Console.WriteLine(dv.Message);
    }
    catch (Exception ex) //თუ სხვა რაიმე შეცდომა მოხდება, აღმოაჩენს
    {
        Console.WriteLine(ex.Message);
    }


}

//Calc(); //ფუნქციის გაშვება


#endregion



#region guess number game
void GuessNumber()
{
    Console.WriteLine("computer picked a number between 0 and 100");
    int n = new Random().Next(0, 101); //ვიღებთ შემთხვევით რიცხვს და ვწერთ ცვლად n-ში
    int a, counter = 0;

    do //ეშვება while-მდე
    {
        Console.Write("guess the number: ");
        while (!int.TryParse(Console.ReadLine(), out a)) //მომხმარებელს შემოჰყავს რიცხვი, რომელიც უნდა იყოს ინტ
        {
            Console.Write("enter correct number: ");
        }
        counter++; //ვითვლით მცდელობების რაოდენობას
        if (a == n) //თუ მომხამერებელი გამოიცნობს ჩაფიქრებულ რიცხვს
        {
            Console.WriteLine($"congratulations, you guessed the number in {counter} attempts!");
        }
        else if (a > n) //თუ მომხმარებლის მიერ შეყვანილი რიცხვი მეტია ჩაფიქრებულ რიცხვზე
        {
            Console.WriteLine("computer's number is lower.");
        }
        else //თუ მომხმარებლის მიერ შეყვანილი რიცხვი ნაკლებია ჩაფიქრებულ რიცხვზე
        {
            Console.WriteLine("computer's number is higher");
        }

    }
    while (n != a); // მანამდე ვუშვებთ სანამ მომხმარებელი არ გამოიცნობს

}

//GuessNumber();


#endregion



#region hangman game
void Hangman()
{
    string[] strings = { "computer", "laptop", "water", "dog", "cat", "plant", "guitar", "program", "child", "book" }; //ვქმნით სიტყვების მასივს თამაშისთვის
    string word = strings[new Random().Next(0, strings.Length)]; //ვირჩევთ მასივიდან შემთხვევით სიტყვას თამაშის დასაწყებად
    Console.Write("enter maximum number of attempts: ");
    int attempts; 
    //მომხმარებელი თავად ირჩევს წინასწარ თუ რამდენი მცდელობა ექნება
    while (!int.TryParse(Console.ReadLine(), out attempts) || attempts <= 0) //უნდა იყოს ინტ და დადებითი რიცხვი
    {
        Console.Write("enter correct number: ");
    }

    string answer = "";
    for (int i = 0; i < word.Length; i++)
    {
        answer += "_ ";  //შერჩეულ სიტყვას ვმალავთ
    }
    Console.WriteLine(answer);

    while (attempts > 0) //მანამდე გრძელდება თამაში სანამ ცდების რაოდენობა არ ამოიწურება
    {
        Console.Write("enter letter: "); //სათითაოდ შემოაქვს მომხმარებელს ასოები
        char ch;
        while (!char.TryParse(Console.ReadLine().ToLower(), out ch)) //ვამოწმებთ ასო თუ სწორად შეჰყავს, უნდა იყოს ჩარი
        {
            Console.Write("enter correct letter: ");
        }


        if (word.Contains(ch)) //ვამოწმებთ ჩაფიქრებულ სიტყვაში არის თუ არა ეს ასო
        {
            char[] charArray = answer.ToCharArray(); //ვქმნით ახალ მასივს, სადაც სტრინგის თითოეული char(სიმბოლო) იქნება შენახული რათა მერე გამოვაჩინოთ ის ასო რომელიც გამოიცნო
            for (int j = 0; j < word.Length; j++) //ციკლს ვუშვებთ რათა შევამოწმოთ გამოცნობილი ასო ერთზე მეტჯერ ხომ არ შეგვხვდა
            {
                if (word[j] == ch)
                {
                    charArray[2 * j] = ch; //ვითვალისწინებთ რომ დეფისების გარდა გვიწერია სფეისები(გამოტოვებული ადგილები)
                }
            }
            answer = new string(charArray); //ისევ ვამთელებთ სიმბოლოებისგან სტრინგს

            if (!answer.Contains("_")) //ვამოწმებთ სიტყვაში ხომ არ დარჩა გამოუცნობი ასო
            {
                Console.WriteLine("congratulations, you guessed the word!");
                Console.WriteLine(answer);
                break;
            }

            Console.WriteLine($"you guessed the letter. {attempts} attempts left."); //ვამცნობთ ყოველი ასოს სწორად გამოცნობას და დარჩენილი მცდელობების რაოდენობას
            Console.WriteLine(answer);
        }
        else
        {
            attempts--;
            Console.WriteLine($"can't guess the letter. {attempts} attempts left."); //ვამცნობთ რომ ვერ გამოიცნო და რამდენი მცდელობა დარჩა
        }
    }
    if (attempts == 0)
        Console.WriteLine("you failed!"); //წააგო
}

//Hangman();


#endregion



#region translator
void Translator()
{   //ქართულიდან ინგლისურზე
    string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\geotoeng.txt"; //ცვლადში ვინახავთ ფაილის გზას(path)
    using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write)) //ვიყენებთ FileStream, ვქმნით ფაილს
    {
        using (StreamWriter sw = new StreamWriter(fs)) //ვიყენებთ StreamWriter(ვქმნით მის ობიექტს)
        {
            sw.WriteLine("sarke-mirror\r\nwigni-book\r\nmagida-table\r\nqalaqi-city\r\nchanta-bag\r\nskami-chair"); //ფაილში ვწერთ მოცემულ ტექსტს
        }
    }
    ////ინგლისურიდან ქართულზე
    //path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\engtogeo.txt";
    //using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
    //{
    //    using (StreamWriter sw = new StreamWriter(fs))
    //    {
    //        sw.WriteLine("mirror-sarke\r\nbook-wigni\r\ntable-magida\r\ncity-qalaqi\r\nbag-chanta\r\nchair-skami");
    //    }
    //}
    //ქართულიდან რუსულზე
    path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\geotorus.txt";
    using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
    {
        using (StreamWriter sw = new StreamWriter(fs))
        {
            sw.WriteLine("sarke-zerkalo\r\nwigni-kniga\r\nmagida-stol\r\nqalaqi-gorod\r\nchanta-sumka");
        }
    }
    ////რუსულიდან ქართულზე
    //path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\rustogeo.txt";
    //using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
    //{
    //    using (StreamWriter sw = new StreamWriter(fs))
    //    {
    //        sw.WriteLine("zerkalo-sarke\r\nkniga-wigni\r\nstol-magida\r\ngorod-qalaqi\r\nsumka-chanta");
    //    }
    //}


    string from = "", to = "";

    while (true)
    {
        Console.WriteLine("choose number: \n1 - from georgian to english\n2 - from english to georgian\n3 - from georgian to russian\n4 - from russian to georgian\n5 - exit program"); //მომხმარებელმა უნდა აირჩიოს რომელი ლექსიკონი უნდა
        path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string temp;


        while (true)
        {
            temp = Console.ReadLine(); //მომხმარებელი ირჩევს ლექსიკონს
            bool endwhile = true;

            switch (temp)
            {   //ვინახავთ ადგილმდებარეობას არჩეული ლექსიკონის
                case "1":
                    path += @"\geotoeng.txt";
                    from = "geo";
                    to = "eng";
                    break;
                case "2":
                    path += @"\geotoeng.txt";
                    from = "eng";
                    to = "geo";
                    break;
                case "3":
                    path += @"\geotorus.txt";
                    from = "geo";
                    to = "rus";
                    break;
                case "4":
                    path += @"\geotorus.txt";
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
        string text = Console.ReadLine();//მომხმარებელს შეჰყავს სიტყვა რომლის თარგმანიც უნდა
        bool notranslation = true;
        try
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null) //ვამოწმებთ ფაილში ყველა ხაზს სანამ ცარიელი არ შეხვდება
                {
                    if (from == "geo")
                    {
                        if (text == line.Split("-")[0]) //ვამოწმებთ მომხმარებლის მიერ შეყვანილი სიტყვა არის თუ არა ლექსიკონში
                        {
                            Console.WriteLine($"translated text: {line.Split("-")[1]}"); //გამოგვაქვს გადათარგმნილი სიტყვა
                            notranslation = false;
                            break;
                        }
                    }
                    else
                    {
                        if (text == line.Split("-")[1]) //ვამოწმებთ მომხმარებლის მიერ შეყვანილი სიტყვა არის თუ არა ლექსიკონში
                        {
                            Console.WriteLine($"translated text: {line.Split("-")[0]}"); //გამოგვაქვს გადათარგმნილი სიტყვა
                            notranslation = false;
                            break;
                        }
                    }
                    //if (text == line.Split("-")[0]) //ვამოწმებთ მომხმარებლის მიერ შეყვანილი სიტყვა არის თუ არა ლექსიკონში
                    //{
                    //    Console.WriteLine($"translated text: {line.Split("-")[1]}"); //გამოგვაქვს გადათარგმნილი სიტყვა
                    //    notranslation = false;
                    //    break;
                    //}
                }
            }
            if (notranslation) //თუ თარგმანი ვერ ვიპოვეთ
            {
                Console.WriteLine($"{text} not found in dictionary. enter translation: ");
                string translation = Console.ReadLine();
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    if (from == "geo")
                    {
                        sw.WriteLine($"{text}-{translation}"); //მომხმარებელი თავად ამატებს სიტყვის თარგმანს
                    }
                    else
                    {
                        sw.WriteLine($"{translation}-{text}"); //მომხმარებელი თავად ამატებს სიტყვის თარგმანს
                    }
                    //sw.WriteLine($"{text}-{translation}"); //მომხმარებელი თავად ამატებს სიტყვის თარგმანს
                }

                //path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $@"\{to}to{from}.txt";
                //using (StreamWriter sw = new StreamWriter(path, true))
                //{
                //    sw.WriteLine($"{translation}-{text}");// ასევე ამ სიტყვას ვამატებთ მეორე ლექსიკონში
                //}
                Console.WriteLine("translation added!");

            }
        }
        catch (Exception ex) //თუ რაიმე შეცდომა მოხდა catch დაიჭერს
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
    dir.Create(); //ვქმნით ფოლდერს

    while (true)
    {
        Console.WriteLine("1 - register user\n2 - check balanse\n3 - deposit money\n4 - withdraw money\n5 - exit");
        string temp = Console.ReadLine(); //მომხმარებელი ირჩევს მოქმედებას
        if (temp == "5") { break; }

        if (temp == "1") //ვარეგისტრირებთ მომხმარებელს
        {
            Console.Write("enter username: ");
            string username = Console.ReadLine();
            string path = dirPath + @$"\{username}.txt";
            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Exists) //სანამ დავარეგისტრირებთ ვამოწმებთ უკვე ხომ არ არსებობს user
            {
                Console.WriteLine($"user {username} already exists!");
            }
            else
            {
                //int balance = 0;
                Console.Write("enter balance: ");
                int balance = int.Parse(Console.ReadLine());
                using (StreamWriter sw = new StreamWriter(path)) //ვქმნით მისი სახელის ფაილს
                {
                    sw.WriteLine(balance); //ვუწერთ ბალანსს ფაილში
                }
                Console.WriteLine("user added!");
            }

        }
        else if (temp == "2") //ვამოწმეთ ბალანსს
        {
            Console.Write("enter username: ");
            string username = Console.ReadLine();
            string path = dirPath + @$"\{username}.txt";

            FileInfo fileInfo = new FileInfo(path); //გადავცემთ ფაილის ადგილმდებარეობას
            if (!fileInfo.Exists)
            {
                Console.WriteLine($"{username} doesn't exist!");
                continue;
            }

            string line;
            int balance;
            using (StreamReader sr = new StreamReader(path))
            {
                if ((line = sr.ReadLine()) != null) //ვამოწმებთ ფაილი ცარიელი ხომ არაა
                {
                    balance = int.Parse(line);
                    Console.WriteLine($"balance: ${balance}"); //გამოგვაქვს ბალანსი
                }
            }
        }
        else if (temp == "3") //თანხის შეტანა
        {
            Console.Write("enter username: ");
            string username = Console.ReadLine();
            string path = dirPath + @$"\{username}.txt";

            FileInfo fileInfo = new FileInfo(path);
            if (!fileInfo.Exists) // თუ არ არსებობს მითითებული ექაუნთი
            {
                Console.WriteLine($"{username} doesn't exist!");
                continue;
            }

            int newmoney, oldmoney = 0;
            string line;
            using (StreamReader sr = new StreamReader(path))
            {
                if ((line = sr.ReadLine()) != null) //ვამოწმებთ ფაილი ცარიელი ხომ არაა
                {
                    oldmoney = int.Parse(line); //ვინახავთ ბალანსს ცვლადში
                }
            }


            Console.Write("enter amount of money: ");
            while (true)
            {
                try //ვითვალისწინებთ შეცდომებს
                {
                    newmoney = int.Parse(Console.ReadLine());
                    if (newmoney < 0) //არ შემოიტანოს უარყოფითი რიცხვი
                    {
                        Console.Write("enter positive number: ");
                        continue;
                    }
                    newmoney += oldmoney; // ბალანსი შეავსო მითითებული თანხით
                    break;
                }
                catch (OverflowException oe) //ვითვალისწინებთ რომ შეყვანილი რიცხვი არ გასცდეს int-ს
                {
                    Console.Write("enter lower number: ");
                }
                catch (Exception e)
                {
                    Console.Write("enter correct number: ");
                }
            }
            File.WriteAllText(path, newmoney.ToString()); //ფაილში ჩაიწერა ახალი ბალანსი
            Console.WriteLine($"total amount: {newmoney}");

        }
        else if (temp == "4")//თანხის გატანა
        {
            Console.Write("enter username: ");
            string username = Console.ReadLine();
            string path = dirPath + @$"\{username}.txt";

            FileInfo fileInfo = new FileInfo(path);
            if (!fileInfo.Exists) // თუ არ არსებობს მითითებული ექაუნთი
            {
                Console.WriteLine($"{username} doesn't exist!");
                continue;
            }

            int newmoney, oldmoney = 0;
            string line;
            using (StreamReader sr = new StreamReader(path))
            {
                if ((line = sr.ReadLine()) != null) //ვამოწმებთ ფაილი ცარიელი ხომ არაა
                {
                    oldmoney = int.Parse(line); //ვინახავთ ბალანსს ცვლადში
                }
            }


            Console.Write("enter amount of money: ");
            while (true)
            {
                try //ვითვალისწინებთ შეცდომებს
                {
                    newmoney = int.Parse(Console.ReadLine());
                    if (newmoney < 0) //არ შემოიტანოს უარყოფითი რიცხვი
                    {
                        Console.Write("enter positive number: ");
                        continue;
                    }
                    if (newmoney > oldmoney)
                    {
                        Console.Write("not enough money!\nenter lower number: ");
                        continue;
                    }
                    newmoney = oldmoney - newmoney; //ბალანსს ჩამოაკლდა მითითებული თანხა
                    break;
                }
                catch (OverflowException oe) //ვითვალისწინებთ რომ შეყვანილი რიცხვი არ გასცდეს int-ს
                {
                    Console.Write("enter lower number: ");
                }
                catch (Exception e)
                {
                    Console.Write("enter correct number: ");
                }
            }
            File.WriteAllText(path, newmoney.ToString()); //ფაილში ჩაიწერა ახალი ბალანსი
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
BookManager bookManager = new BookManager(); //ვქმნით ობიექტს
//bookManager.Menu(); //ვიძახებთ მენიუს
//ვამატებთ წიგნებს
bookManager.AddBook("tyeebis mefe", "dato turashvili", 2005); 
bookManager.AddBook("frankenshteini", "meri sheli", 1846);
bookManager.AddBook("jinsebis taoba", "dato turashvili", 2001);
bookManager.AddBook("davit agmashenebeli", "konstantine gamsaxurdia", 1971);

bookManager.ShowBooks(); //გამოგვაქვს ყველა წიგნი
//ვეძებთ წიგნებს
bookManager.SearchBookByTitle("frankenshteini");
bookManager.SearchBookByAuthor("dato turashvili");
*/

#endregion

#region studentmanager

/*
StudentManager studentManager = new StudentManager(); //ვქმნით ობიექტს
//studentManager.Menu(); //ვიძახებთ მენიუს
//ვამატებთ სტუდენტებს
studentManager.AddStudent("mariami", 15, 'A');
studentManager.AddStudent("nika", 17, 'B');
studentManager.AddStudent("elene", 20, 'D');
studentManager.AddStudent("nugzari", 10, 'F');
studentManager.ShowStudents(); //გამოგვაქვს სტუდენტების სია
//ვეძებთ სტუდენტებს
studentManager.SearchStudentByRollNumber(17);
studentManager.SearchStudentByRollNumber(65);
studentManager.UpdateGrade(20, 'C'); //ვანახლებთ ქულას
studentManager.ShowStudents(); //გამოგვაქვს სტუდენტების სია
*/



#endregion