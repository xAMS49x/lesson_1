using System.Text;

namespace Libraries
{
    public class GetValidateLog
    {
        // getters
        public static string GetString(string msg)
        {
            return Ask(msg) ?? throw new InvalidOperationException("Null exception occured.");
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
        
        public static int GetRandom(int min, int max)
        {
            var random = new Random();
            return random.Next(min, max);
        }

        public static int[] GetArray()
        {
            var size = GetInt("Enter the size of the array: ");
            var min = GetInt("Enter the min number value for the number generation: ");
            var max = GetInt("Enter the max number value for the number generation:\n");

            if (size <= 0)
                throw new ArgumentException("Array size must be greater than zero!");

            if (min > max)
                throw new ArgumentException("Min value must be less than max value!");
            
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = GetRandom(min, max + 1);
            }
            
            return array;
        }

        // Validations
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
       
        
        // Logger (AWS (Ask, Write, Save))
        public static StringBuilder log = new StringBuilder();

        public static void LogLine(string message)
        {
            Console.WriteLine(message);
            log.AppendLine($"<program> {message}");
        }
        
        public static void Log(string message)
        {
            Console.Write(message);
            log.Append(message);
        }

        public static string Ask(string prompt)
        {
            Console.WriteLine(prompt);
            log.Append($"<program> {prompt}");

            string input = Console.ReadLine()!;
            log.AppendLine();
            log.AppendLine($"<user> {input}");

            return input;
        }
        
        public static void SaveLog(int exitCode = 0)
        {
            log.AppendLine($"\nProcess finished with exit code {exitCode}");

            string logDirectory = "/home/ams/RiderProjects/lesson_1(2)/logs";
            string fileName = $"log_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.txt";
            string path = Path.Combine(logDirectory, fileName);

            File.WriteAllText(path, log.ToString());
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\nLog saved to: {path}");
            Console.ResetColor();
        }
    }
}