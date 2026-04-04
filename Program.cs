using System.Runtime.InteropServices.JavaScript;

class Program
{
    
    static void Main()
    {   // Intro
        Console.WriteLine("Welcome again! Pick the task you want to execute (1-4): ");
        short choice = short.Parse(Console.ReadLine());
        if (choice > 4 || choice < 1)
        {
            Console.WriteLine("Error: non-existent value");
            return;
        }

        switch (choice)
        {
            case 1: 
                
                // Task 1
                Console.WriteLine("Greetings. Enter your points to determine your grade (0-100)");
                int points = Convert.ToInt32(Console.ReadLine());
                if (points > 100 || points < 0)
                {
                    Console.WriteLine("Please, ENTER A VALID VALUE");
                    return;
                }
        
                if (points > 90 && points <= 100)
                {
                    Console.WriteLine("Grade: A");
                }
        
                else if (points > 70 && points <= 89)
                {
                    Console.WriteLine("Grade: B");
                }
        
                else if (points > 50 && points <= 69)
                {
                    Console.WriteLine("Grade: C");
                }
        
                else if (points <= 50)
                {
                    Console.WriteLine("Grade: D");
                }
                break;
            
            case 2:
                
                // Task 2
                Console.WriteLine("Hello and welcome to Absolute Cinema! We need your age to calculate price for the ticket: ");
                int age = Convert.ToInt32(Console.ReadLine());
                    if (age > 100 || age < 0)
                    {
                        Console.WriteLine("Please, ENTER A VALID VALUE");
                        return;
                    }

                if (age < 6 || age > 65)
                {
                    Console.WriteLine("The ticket is free, enjoy!");
                }
                
                else if (age >= 6 && age <= 12)
                {
                    Console.WriteLine("The ticket will be 50₴");
                }
                
                else if (age > 12 && age <= 17)
                {
                    Console.WriteLine("The ticket will be 80₴");
                }
                
                else if (age > 17 && age <= 64)
                {
                    Console.WriteLine("The ticket will be 120₴");
                }
                break;

            case 3:

                // Task 3
                Console.WriteLine("Enter a month number you want to find info about: ");
                string inMonth = Console.ReadLine();

                if (int.TryParse(inMonth, out int month))
                {
                    if (month < 1 || month > 12)
                    {
                        Console.WriteLine("Please, ENTER A VALID VALUE");
                        return;
                    }
                    
                    string season = "";
                    int days = 0;

                    switch (month)
                    {
                        case 12:
                        case 1:
                        case 2:
                            season = "Winter";
                            break;

                        case 3:
                        case 4:
                        case 5:
                            season = "Spring";
                            break;

                        case 6:
                        case 7:
                        case 8:
                            season = "Summer";
                            break;

                        case 9:
                        case 10:
                        case 11:
                            season = "Autumn";
                            break;
                    }

                    switch (month)
                    {
                        case 1:
                        case 3:
                        case 5:
                        case 7:
                        case 8:
                        case 10:
                        case 12:
                            days = 31;
                            break;

                        case 4:
                        case 6:
                        case 9:
                        case 11:
                            days = 30;
                            break;

                        case 2:
                            days = 28;
                            break;
                    }

                    Console.WriteLine($"This month is in {season} season and has {days} days.");
                }
                else
                {
                    Console.WriteLine("Error: Data you have entered is NOT a number");
                }
                break;
            
            case 4:
                
                // Task 4
                Console.WriteLine("Greetings, you are using version 0.0.1 of A-B Signing Gateway.");
                Console.WriteLine("Enter your login (email):");
                string login = Console.ReadLine();
                
                Console.WriteLine("Enter your password: ");
                string password = Console.ReadLine();
                
                Console.WriteLine("Enter year of your birth: ");
                int year = Convert.ToInt32(Console.ReadLine());

                int age2 = DateTime.Now.Year - year;
                
                if (age2 > 100 || age2 < 0)
                {
                    Console.WriteLine("Please, ENTER A VALID VALUE");
                    return;
                }

                if (age2 < 18)
                {
                    Console.WriteLine("You MUST be above 18 to use our services.");
                }
                
                Console.WriteLine("Good! You are registered. \n Log right back in. \n Login: ");
                string loginCheck = Console.ReadLine();
                
                Console.WriteLine("Enter your password: ");
                string passwordCheck = Console.ReadLine();

                if (loginCheck != login)
                {
                    Console.WriteLine("Access Denied. Wrong email.");
                    
                    if (passwordCheck != password)
                    {
                        Console.WriteLine("Access Denied. Wrong password.");
                    }
                }
                else
                {
                    Console.WriteLine("Login successful.");
                }
                break;
        }
    }
}