using static Libraries.GetValidateLog;
using static Libraries.TaskSpecific;
using static Libraries.ArrayActions;
using static Libraries.Funnies;
using static Libraries.ListActions;

namespace Homework_6;

internal class Program
{
    private static void Main()
    {
        FunnyPhrase();
        byte taskNumber = GetBytes("Welcome back. Choose the task (1-3): ");

        switch (taskNumber)
        {
            case 1:

                List<int> numbers = new List<int>();

                while (!numbers.Contains(99))
                {
                    numbers.Add(GetRandom(10, 101));
                }

                Log("Element count before 99: " + (numbers.Count - 1));
                break;

            case 2:

                while (true)
                {
                    List<string> products = new List<string>();
                    LogLine(
                        "\n===== Product list menu =====\n1. Add item to list \n2. Remove item from list \n3. Show list \n0. Exit \n");
                    var operation = Convert.ToByte(Ask("Choose an option: "));

                    switch (operation)
                    {
                        case 0: LogLine("Closing..."); break;
                        case 1:
                            AddToList(products);
                            continue;
                        case 2:
                            RemoveFromList(products);
                            continue;
                        case 3:
                            ListContents(products);
                            continue;
                        default:
                            LogLine("Invalid choice.");
                            break;
                    }

                    break;
                }

                break;
        }

        SaveLog(0);
    }
}
//AMS49 (GitHub: xAMS49x). ALL RIGHTS RESERVED.