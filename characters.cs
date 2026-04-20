using static Library.Library;

namespace characters;

public class DicePlayer
{
    //Dice players
    public string Name { get; set; }
    public int DiceRollScore { get; set; } = 0;

    public DicePlayer(string name)
    {
        Name = name;
        Log($"A new player has joined!\nPlayer name: {name}");
    }

    private static readonly Random _random = new();

    public byte RollDice()
    {
        var roll = _random.Next(1, 7);
        Log(
            $"Player {Name} rolled a {roll}\nAdded to total score changed from {DiceRollScore} to {DiceRollScore + roll}");
        Log("==========================");
        DiceRollScore += roll;
        return (byte)roll;
    }
}

public class Character
{
    // fighting characters
    public string Name { get; set; }
    public int Health { get; private set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int CritChance { get; set; }
    public int DodgeChance { get; set; }

    public bool IsAlive => Health > 0;

    public Character(string name, int health, int attack, int defense, int critChance, int dodgeChance)
    {
        Name = name;
        Health = health;
        Attack = attack;
        Defense = defense;
        CritChance = critChance;
        DodgeChance = dodgeChance;
    }

    public void AttackDefender(Character defender, Random random)
    {
        Console.WriteLine($"{Name} attacks {defender.Name}\n");

        
        if (defender.TryDodge(random))
        {
            Console.WriteLine($"{defender.Name} evaded!");
            return;
        }

       
        int currentAttack = Attack;
        bool isCritical = random.Next(1, 101) <= CritChance;

        if (isCritical)
        {
            currentAttack = (int)(Attack * 1.5);
            Console.WriteLine("Critical hit!");
        }

        int damage = currentAttack - defender.Defense;

        if (damage < 0)
            damage = 0;

        defender.TakeDamage(damage);

        Console.WriteLine($"{Name} have dealt {damage} damage to {defender.Name}\n");
    }

    private bool TryDodge(Random random)
    {
        return random.Next(1, 101) <= DodgeChance;
    }

    private void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health < 0)
            Health = 0;
    }
}