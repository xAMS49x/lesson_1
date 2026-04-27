using static Libraries.GetValidateLog;

namespace Libraries;

public class Funnies
{
    public static void PhraseMsg(string msg, ConsoleColor color = ConsoleColor.DarkRed)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(msg);
        Console.WriteLine();
        Console.ResetColor();
        
    }
    
    public static void PhraseChoice()
    {
        int choice = GetRandom(1, 16);
        
        switch (choice)
        {
            case 1:
                PhraseMsg("DIE INSIDE THE FLAMES OF YOUR FRIGHT!");
                break;

            case 2:
                PhraseMsg("Pitiful humanity fell into the abyss.\nGame set, before you ever try to fight.");
                break;
            
            case 3:
                PhraseMsg("The slaughter's on,\nI'd love to see you come undone!");
                break;
            
            case 4:
                PhraseMsg("Did you know you can make you computer run faster?\n It's simple! You just press Alt+F4");
                break;
            
            case 5:
                PhraseMsg("Heavy hearts won't grieve\nThat soon I`ll be that body in the bag...");
                break;
            
            case 6:
                PhraseMsg("Still, morning comes and you can't outrun\nThe warm glow of the sun...");
                break;
            
            case 7:
                PhraseMsg("Don't get me wrong, I'd love to change my paradigm\nBut when life gives lemons hand over fist\nThere's only so much you can fix.");
                break;
            
            case 8:
                PhraseMsg("I hold no gods, I make no prayer.\nMy mind is still, my heart is bare.");
                break;
            
            case 9:
                PhraseMsg("HAIL THINE DIVINE LORD JILL! KILL THE HERETICS! JUDGEMENT FOR UNBELIEVERS!");
                break;
            
            case 10:
                PhraseMsg("Oh blood and viscera divine...");
                break;
            
            case 11:
                PhraseMsg("Can you feel it? Void stares back.");
                break;
            
            case 12:
                PhraseMsg("Rev the engine, make your fate!");
                break;
            
            case 13:
                PhraseMsg("Love? That's useless.\nPity? It's a deceitful thing.");
                break;
            
            case 14:
                PhraseMsg("Water rises and creates a vibrance\nTo bring me home far away from violence!");
                break;
            
            case 15:
                PhraseMsg("Power awaits those, who take command!");
                break;
        }
    }
}