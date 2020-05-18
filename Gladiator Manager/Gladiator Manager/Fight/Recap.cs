using System;
using System.Collections.Generic;
using System.Text;

public class Recap
{
    public static List<string> list = new List<string> { };
    public static void Go()
    {
        Console.Clear();
        foreach (string s in list)
        {
            Write.Line(s);
        }
        Write.KeyPress();
        list.Clear();
        foreach(Owner o in Owner.list) { foreach (Gladiator g in o.Roster) { g.Endurance = g.MaxEndurance; } }
    }

    internal static void Calculate(Gladiator winner, Gladiator loser)
    {
        list.Add($"{winner.Name} has defeated {loser.Name}. ");

    }
}