using static Libraries.GetValidateLog;
using static Libraries.TaskSpecific;

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
                ShowArray(sex);

                Array.Sort(sex);
                Array.Reverse(sex);

                //operations
                LogLine("\n \n============= Array operations =============");
                int arraySum = 0;

                LogLine("\nValues greater than 500:");
                Console.ForegroundColor = ConsoleColor.Green;
                for (var i = 0; i < sex.Length; i++)
                {
                    if (sex[i] < 500)
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
                    if (i < arraySum)
                    {
                        Log(i + " ");
                    }
                }
                Console.ResetColor();
                
                LogLine("\n \nSum of all array values: " + arraySum);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Log(arraySum.ToString());
                Log("Array average: " + arrayAverage);
                Log(arrayAverage)
                Console.ResetColor();
                break;
        }
        
        SaveLog(0);
    }
}