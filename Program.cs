using static Libraries.GetValidateLog;
using static Libraries.TaskSpecific;
using static Libraries.ArrayActions;
using static Libraries.Funnies;

namespace Homework4;

internal class Program
{
    private static void Main()
    {
        PhraseChoice();
        LogLine("Welcome back. Only one task today, eh?");

        LogLine("Task: Array operations.\n Commencing the sequence...");
        int[] arrayUser = GetArray();
        Array.Sort(arrayUser);
        Array.Reverse(arrayUser);
        ShowArray(arrayUser);
        

        while (true)
        {
            LogLine(
                "\n \n=========================================== Array operations ===========================================");
            byte operation = Convert.ToByte(Ask("Choose operation you want to perform (1-12, 0 - exit):"));
            
            switch (operation)
            {
                
                case 0: LogLine("Closing..."); break;
                case 1:
                    GreaterThan500(arrayUser);
                    break;
                case 2:
                    Sum(arrayUser);
                    break;
                case 3:
                    Average(arrayUser);
                    break;
                case 4:
                    LessThanAverage(arrayUser);
                    break;
                case 5:
                    MultipliesOf5(arrayUser);
                    break;
                case 6:
                    EvenNumbers(arrayUser);
                    break;
                case 7:
                    GreatestSmallestNumbers(arrayUser);
                    break;
                case 8:
                    Within500To600RangeCount(arrayUser);
                    break;
                case 9:
                    Number899IsInArray(arrayUser);
                    break;
                case 10:
                    SumOf100To200RangeValues(arrayUser);
                    break;
                case 11:
                    SecondLargest(arrayUser);
                    break;
                case 12:
                    NumbersContaining7(arrayUser);
                    break;
                
                default:
                    LogLine("Invalid choice.");
                    break;
            }
            
            RepeatFunctionBlock("Return to menu? (y)");
            SaveLog(0);
        }
        // Assembled!
    }
}
//AMS49 (GitHub: xAMS49x). ALL RIGHTS RESERVED.