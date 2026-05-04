using static Libraries.GetValidateLog;
using static Libraries.TaskSpecific;
using static Libraries.Funnies;
using static Libraries.ListActions;

namespace Libraries;

public class Student
{
    public string Name { get; set; }
    public int BirthYear { get; set; }
    public string Group { get; set; }

    public Student(string name, int birthYear, string group)
    {
        Name = name;
        BirthYear = birthYear;
        Group = group;
    }
}

public static class StudentListActions
{
    public static void AddStudent(List<Student> students)
    {
        LogLine("===== Adding student menu =====");

        var name = GetString("Enter the name of the student: ") ?? "";
        name = name.Trim();

        if (string.IsNullOrWhiteSpace(name))
        {
            LogLine("Name can't be empty!");
            PressAnyKeyToContinue();
            return;
        }

        int birthYear;
        while (true)
        {
            var input = GetString("Enter year of birth: ");

            if (int.TryParse(input, out birthYear))
                break;

            LogLine("Invalid year of birth.");
        }


        var group = GetString("Enter the group of the student: ") ?? "";
        group = group.Trim();

        if (string.IsNullOrWhiteSpace(group))
        {
            LogLine("Group name can't be empty!");
            PressAnyKeyToContinue();
            return;
        }

        students.Add(new Student(name, birthYear, group));

        Console.ForegroundColor = ConsoleColor.Green;
        LogLine("\nStudent added.");

        PressAnyKeyToContinue();
    }

    public static void SearchStudentByName(List<Student> students)
    {
        if (students.Count == 0)
        {
            LogLine("List is empty.");
            PressAnyKeyToContinue();
            return;
        }


        string query = GetString("Enter the name to search: ");
        query = query.Trim();

        if (string.IsNullOrWhiteSpace(query))
        {
            LogLine("Request can't empty.");
            PressAnyKeyToContinue();
            return;
        }

        List<Student> foundStudents = new List<Student>();

        for (int i = 0; i < students.Count; i++)
        {
            Student s = students[i];

            if (s.Name.Contains(query, StringComparison.OrdinalIgnoreCase))
            {
                foundStudents.Add(s);
            }
        }

        if (foundStudents.Count == 0)
        {
            LogLine("No students with such name found.");
            PressAnyKeyToContinue();
            return;
        }

        LogLine("\nIndividuals found:");
        for (int i = 0; i < foundStudents.Count; i++)
        {
            Student s = foundStudents[i];
            LogLine($"{i + 1}. Name: {s.Name}, Year of birth: {s.BirthYear}, Group: {s.Group}");
        }
        
        PressAnyKeyToContinue();
    }

    public static void ListStudents(List<Student> students)
    {
        LogLine("===== Student list =====");

        if (students.Count == 0)
        {
            LogLine("List is empty.");
            PressAnyKeyToContinue();
            return;
        }

        for (int i = 0; i < students.Count; i++)
        {
            Student s = students[i];
            LogLine($"{i + 1}. Name: {s.Name}, Year of birth: {s.BirthYear}, Group: {s.Group}");
        }
        
        PressAnyKeyToContinue();
    }
}