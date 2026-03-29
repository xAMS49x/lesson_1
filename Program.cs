class Program
{
    
    static void Main()
    {
        // Console.ForegroundColor = ConsoleColor.Black;
        // Console.BackgroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("Welcome! Pick the task you want to see (1-5): ");
        int TaskNumber = Convert.ToInt32(Console.ReadLine());
        
        switch(TaskNumber)
        {
            
        case 1: 
        // Task 1
        Console.WriteLine("Enter the number a: ");
        int a = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("Enter the number b: ");
        int b = Convert.ToInt32(Console.ReadLine());
        
        double result = a * Math.Pow(b, 2);
        Console.WriteLine($"Your result is:  {result}");

            break;
        
        
        // Task 2
        case 2:
        Console.WriteLine("Count yo days");
        int days = Convert.ToInt32(Console.ReadLine());
        int weeks = 0;
        
        while (days >= 7)
        {
            days -= 7;
            weeks++;
        }
        Console.WriteLine($"Yo days: weeks: {weeks}, days: {days}");

            break;
        
        
        // Task 3
        case 3:
            Console.WriteLine("12% of number calculator. Enter your number: ");
            double number = Convert.ToInt32(Console.ReadLine());
            
            double percentage = (number * 12) / 100;
            Console.WriteLine($"12% of {number} is: {percentage}");

            break;
        
        // Task 4
        case 4:
            Console.WriteLine("Enter kilometer value: ");
            double kilometer = double.Parse(Console.ReadLine());
            double miles = kilometer * 0.6213712; 
            
            Console.WriteLine("Enter kilogram value: ");
            double kgs = double.Parse(Console.ReadLine());
            double lbs = kgs * 2.2046226;
            
            Console.WriteLine("Enter liter value: ");
            double liter = double.Parse(Console.ReadLine());
            double gallons = liter * 0.2641721;
            
            Console.WriteLine($"\n{kilometer} kilometers is: {miles} miles");
            Console.WriteLine($"{kgs} kgs is: {lbs} lbs");
            Console.WriteLine($"{liter} liters is: {gallons} gallons");
            
            break;
        // Task 5
        case 5:
            
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            
            Console.Write("Enter your year of birth: ");
            int date = int.Parse(Console.ReadLine());
            
            int age = DateTime.Now.Year - date;
            Console.WriteLine($"Welcome, {name}! You are {age} years old.");
            
            Console.WriteLine("\nIs that right? (y/n)");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "y":
                    if (age <= 15)
                    {
                        Console.Write("yooo,go back to kindergarten");
                    }

                    if (age > 16)
                    {
                        Console.Write("I am comfortable talking to you then");
                    }

                    if (age > 30)
                    {
                        Console.Write("Oh my god, what are you, a fossil? Holy hell, dinosaur, bro");
                    }
                    
                    break;
                
                case "n":
                    Environment.Exit(0);
                    break;
            }
            
            break;
        }
    }
}