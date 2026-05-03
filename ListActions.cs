using static Libraries.GetValidateLog;
using static Libraries.TaskSpecific;

namespace Libraries;

public class ListActions
{
    public static void AddToList(List<string> list)
    {
        Console.Clear();
        list.Add(GetString("Name the item you want to add to list: "));
        LogLine("Item added to the list.");
        PressAnyKeyToContinue();
    }

    public static void RemoveFromList(List<string> list)
    {
        Console.Clear();
        if (list.Remove(GetString("Name the item you want to remove from list: ")))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            LogLine("Item removed from the list.");
            PressAnyKeyToContinue();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            LogLine("Item could not be removed from the list.");
            PressAnyKeyToContinue();
        }
    }

    public static void ListContents(List<string> list)
    {
        Console.Clear();
        LogLine("List contents: ");
        list.ForEach(item  => LogLine(item));
        PressAnyKeyToContinue();
    }
}