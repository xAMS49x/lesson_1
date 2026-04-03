class Program
{
    
    static void Main()
    {
        Console.WriteLine("Вітаю у AB Fitness Tracker! Введіть свою ціль (у кроках): ");
        float goal = float.Parse(Console.ReadLine());
        
        Console.WriteLine("Супер, тепер ввдеіть Ваш поточний результат: ");
        float current = float.Parse(Console.ReadLine());
        
        float percentage = (current / goal) * 100;
        if (percentage < 0)
        {
            Console.WriteLine("Значення не може бути від'ємним");
            return;
        }
        
        Math.Round(percentage);

        if (percentage < 70)
        {
            Console.WriteLine("Ну це не діло, треба більше рухатись!");
        }
        
        else if (percentage > 70 && percentage < 90)
        {
            Console.WriteLine("Чудово, але треба активніше!");
        }
        
        else if (percentage > 90 && percentage < 99)
        {
            Console.WriteLine("Дуже близько, продовжуйте!");
        }
        
        else if (percentage > 100 && percentage < 199)
        {
            Console.WriteLine("Ваша ціль досягнута!");
        }

        else if (percentage > 200)
        {
            Console.WriteLine("Та господі, куди ти так гониш");
        }
    }
}