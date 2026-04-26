using static Libraries.GetValidateLog;
using static Libraries.TaskSpecific;
using static Libraries.ArrayActions;

namespace Homework4;

internal class Program
{
    static void Main()
    {
        byte task = GetBytes("Welcome back. Choose the task you want to see (1-3): ");
        if (!ValidateRange(task, 1, 3)) throw new Exception("No such task number.");

        switch (task)
        {
            case 1:
                // Task 1
                LogLine("Task: Array operations.\n Commencing the sequence...");
                int[] sex = GetArray();
                Array.Sort(sex);
                Array.Reverse(sex);
                ShowArray(sex);
                
                //operations
                LogLine("\n \n============= Array operations =============");
                int arraySum = 0;

                LogLine("\nValues greater than 500:");
                Console.ForegroundColor = ConsoleColor.Green;
                for (var i = 0; i < sex.Length; i++)
                {
                    if (sex[i] > 500)
                    {
                        Log(sex[i] + " ");
                    }

                    arraySum += sex[i];
                }
                Console.ResetColor();

                int arrayAverage = arraySum / sex.Length;
                LogLine("\n \nArray values less than average (" + arrayAverage + "):");
                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (var i in sex)
                {
                    if (i < arrayAverage)
                    {
                        Log(i + " ");
                    }
                }
                Console.ResetColor();

                
                foreach (var i in sex)
                {
                    if (i % 5 == 0)
                    {
                        Log(i + " ");
                    }
                }
                
                ColoredValue("\n \nSum of all array values: ", ConsoleColor.Magenta, arraySum);
                ColoredValue("Array average: ", ConsoleColor.Magenta, arrayAverage);
                
                break;
        }
        
        SaveLog(0);
    }
}