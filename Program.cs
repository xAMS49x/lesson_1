class Program
{
    public static void showError(string msg)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("An error has occured: " + msg);
        Console.ResetColor();
    }

    public static string GetString(string msg)
    {
        Console.WriteLine(msg);
        return Console.ReadLine();
    }

    public static int GetInt(string msg)
    {
        return Convert.ToInt32(GetString(msg));
    }

    public static double GetDouble(string msg)
    {
        return Convert.ToDouble(GetString(msg));
    }

    public static byte GetBytes(string msg)
    {
        return Convert.ToByte(GetString(msg));
    }

    public static bool ValidateStringLength(string text, int minLength, int maxLength)
    {
        if (text.Trim().Length < minLength || text.Trim().Length > maxLength)
        {
            return true;
        }

        return false;
    }

    public static bool ValidateRange(byte value, int min, int max)
    {
        if (value < min || value > max)
        {
            return false;
        }

        return true;
    }

    public static int CoinFlip(string result)
    {
        var coinToss = new Random();
        int roll = coinToss.Next(1, 1001);

        switch (roll)
        {
            case <= 498:
                result = "Heads";
                return 3;

            case <= 996:
                result = "Tails";
                return 1;

            default:
                result = "Edge";
                return 10;
        }
    }

    static void Main()
    {
        byte task = GetBytes("Welcome back. Choose the task you want to see (1-3): ");
        if (!ValidateRange(task, 1, 3))
        {
            showError("No such task number.");
            return;
        }
        
        switch (task)
        {
            // Task 1
            case 1:

                Console.WriteLine("Greetings, you are using version 0.0.2 of A-B Signing Gateway.");
                string login = GetString("Enter your login(email): ");

                if (login.Trim().Length < 8)
                {
                    showError("login must be at least 8 characters long.");
                    return;
                }

                string password = GetString("Enter your password: ");

                if (ValidateStringLength(password.Trim(), 7, 30))
                {
                    showError("password must be at least 8 characters long.");
                    return;
                }

                int age = DateTime.Now.Year - GetInt("Enter year of your birth: ");

                if (age > 105 || age < 0)
                {
                    showError("age value is invalid.");
                    return;
                }

                if (age < 18)
                {
                    showError("you MUST be above 18 to use our services.");
                    return;
                }

                string loginCheck = GetString("Good! You are registered. \n Log right back in. \n Login: ");

                string passwordCheck = GetString("Enter your password: ");

                if (loginCheck != login)
                {
                    showError("Access denied.");
                }

                else if (passwordCheck != password)
                {
                    showError("Access denied.");
                }

                else
                {
                    Console.WriteLine("Login successful.");
                }

                break;

            // Task 2: Rock-paper-scissors
            case 2:

                Console.WriteLine("Hello and welcome to good old Rock, Paper, Scissors!");
                string userName = GetString("Enter your username for game: ");
                if (userName.Trim().Length < 1)
                    showError("Username can't be empty!");


                Console.WriteLine("Now, let's play!\nPlaying against CPU...");
                byte userPoints = 0;
                byte cpuPoints = 0;

                for (int i = 0; i <= 10; i++)
                {
                    Console.WriteLine("Game stars");
                    byte userChoice = GetBytes("Rock (1), paper (2) or scissors (3)?");
                    if (!ValidateRange(userChoice, 1, 3))
                    {
                        showError("Make a valid choice!");
                        return;
                    }

                    //CPU
                    Random rand = new Random();
                    var cpuChoice = (byte)rand.Next(1, 4);
                    switch (cpuChoice)
                    {
                        case 1:
                            Console.WriteLine("CPU chose Rock");
                            break;
                        case 2:
                            Console.WriteLine("CPU chose Paper");
                            break;
                        case 3:
                            Console.WriteLine("CPU chose Scissors");
                            break;
                    }

                    //Game
                    if (userChoice == cpuChoice)
                        Console.WriteLine("Draw!");

                    else if (
                        (userChoice == 1 && cpuChoice == 2) ||
                        (userChoice == 2 && cpuChoice == 3) ||
                        (userChoice == 3 && cpuChoice == 1))
                    {
                        Console.WriteLine("You lost!");
                        cpuPoints++;
                    }

                    else
                    {
                        Console.WriteLine("You won!");
                        userPoints++;
                    }

                    Console.WriteLine($"Score:\n{userName} - {userPoints}\nCPU - {cpuPoints}");
                }

                if (userPoints > cpuPoints)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("Congratulations! You won!");
                    Console.ResetColor();
                }
                else if (userPoints < cpuPoints)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("You're weak. I'm strong. And I win, toymaker!\n You lost.");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("Tie!");
                }

                break;

            // Task 3: Coin flip
            case 3:

                Console.WriteLine(
                    "Wanna play one little game? Coin flip it is! Two players take turns tossing a coin. Heads worth 3 points, tails worth 1 and if coin lands on it's edge - it worth 10 points!");
                string firstPlayer = GetString("Enter first player name: ");
                if (ValidateStringLength(firstPlayer.Trim(), 1, 100))
                {
                    showError("Name can't be empty.");
                    return;
                }

                string secondPlayer = GetString("Enter second player name: ");
                if (ValidateStringLength(secondPlayer.Trim(), 1, 100))
                {
                    showError("Name can't be empty.");
                    return;
                }

                // Game
                byte firstPlayerPoints = 0;
                byte secondPlayerPoints = 0;

                for (int round = 1; round <= 5; round++)
                {
                    Console.WriteLine("Round " + round);
                    string firstPlayerResult = null;
                    var points1 = (byte)CoinFlip(firstPlayerResult);
                    firstPlayerPoints += points1;
                    Console.WriteLine($"{firstPlayer}: {firstPlayerResult} (+{points1} points.)");

                    Console.WriteLine("Round " + round);
                    string secondPlayerResult = null;
                    var points2 = (byte)CoinFlip(secondPlayerResult);
                    secondPlayerPoints += points2;
                    Console.WriteLine($"{secondPlayer}: {secondPlayerResult} (+{points2} points.)");
                }

                Console.WriteLine(
                    $"\n Results:\n {firstPlayer}: {firstPlayerPoints} points\n {secondPlayer}: {secondPlayerPoints} points");


                if (firstPlayerPoints > secondPlayerPoints)
                {
                    Console.WriteLine($"{firstPlayer} have won!");
                }
                else if (secondPlayerPoints > firstPlayerPoints)
                {
                    Console.WriteLine($"{secondPlayer} have won!");
                }
                else
                {
                    Console.WriteLine("Both players drew!");
                }

                break;
        }
    }
}