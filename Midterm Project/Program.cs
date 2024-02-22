
using System.Data;
using System.Text;

void calc()
{

    int a,b;
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
                if (b== 0)
                {
                    throw new DivideByZeroException("Can't divide by 0!");
                }
                Console.WriteLine($"{a}/{b}={(double)a / b}");
                break;

        }
    }
    catch(DivideByZeroException dv){
        Console.WriteLine(dv.Message); 
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    

}

//calc();




void guessNumber()
{
    Console.WriteLine("computer picked a number between 0 and 100");
    int n = new Random().Next(0,101);
    int a=-1, counter=0;

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

//guessNumber();




void hangman()
{
    string[] strings = { "computer", "laptop", "water", "dog", "cat", "plant", "guitar", "program", "child", "book" };
    string word = strings[new Random().Next(0,strings.Length)];
    Console.Write("enter maximum number of attempts: ");
    int attempts = int.Parse(Console.ReadLine());
    string answer = "";
    for (int i=0; i<word.Length; i++)
    {
        answer += "_ ";
    }
    Console.WriteLine(answer);

    while(attempts > 0) 
    {
        attempts--;
        Console.WriteLine("enter letter: ");
        char ch = char.Parse(Console.ReadLine());
        
        if (word.Contains(ch))
        {
            char[] charArray = answer.ToCharArray();
            for (int j=0; j<word.Length; j++)
            {
                if (word[j] == ch)
                {
                    charArray[2*j] = ch;
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

//hangman();




void translator()
{
    Console.WriteLine("choose number: \n1 - from georgian to english\n2 - from english to georgian\n3 - from georgian to russian\n4 - from russian to georgian");
    string temp;
    while (true)
    {
        temp = Console.ReadLine();
        if (temp == "1" ||  temp == "2" || temp == "3" || temp == "4")
        {
            break;
        }
        else
        {
            Console.WriteLine("enter correct number!");
        }
    }

    string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

    switch (temp)
    {
        case "1":
            path += @"\geotoeng.txt";
            break;
        case "2":
            path += @"\engtogeo.txt";
            break;
        case "3":
            path += @"\geotorus.txt";
            break;
        case "4":
            path += @"\rustogeo.txt";
            break;
    }

    Console.WriteLine("enter word or phrase to translate: ");
    string text = Console.ReadLine();
    bool notranslation=true;
    try
    {
        using (StreamReader sr = new StreamReader(path))
        {
            string line;
            while((line = sr.ReadLine()) != null)
            {
                if (text == line.Split("-")[0])
                {
                    Console.WriteLine($"translated text: {line.Split("-")[1]}");
                    notranslation = false;
                    break;
                }
            }
            //if (sr.ReadLine == null)
            //{
            //    notranslation = true;
                
            //}
        }
        if (notranslation)
        {
            Console.WriteLine($"{text} not found in dictionary. enter translation: ");
            string translation = Console.ReadLine();
            using (StreamWriter sw = new StreamWriter(path,true))
            {
                sw.WriteLine($"{text}-{translation}");
            }
            Console.WriteLine("translation added!");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

}

translator();