using System;
using System.Collections.Generic;
using System.Text;

public class Return
{
    internal static Random rand = new Random();    
    internal static int RandomInt(int min, int max) { return rand.Next(min, max); }

    internal static bool Afford(int price)
    {
        return Owner.p.Gold >= price;
    }
    internal static int Integer()
    {
        int sellChoice;
        do
        {

        } while (!int.TryParse(Console.ReadLine(), out sellChoice));
        return sellChoice;
    }
    internal static int Int()
    {
        int sellChoice;
        do
        {

        } while (!int.TryParse(Console.ReadKey(true).KeyChar.ToString().ToLower(), out sellChoice));
        return sellChoice;
    }

    internal static void Info()
    {
        Write.Line(60, 28, Colour.TIME + $"It is Day { Hub.day}" + Colour.RESET);
        Write.Line(0, 0, $"You have " + Colour.GOLD + $"{Owner.p.Gold}" + Colour.RESET + " Gold");
        Write.Line(45, 0, $"You have " + Colour.XP + $"{Owner.p.Prestige}" + Colour.RESET + " Prestige");
        Write.Line(90, 0, $"You have " + Colour.ENERGY + $"{Owner.p.Action}" + Colour.RESET + " remaining actions");
    }

    internal static string Option()
    {
        return Console.ReadKey(true).KeyChar.ToString().ToLower();
    }

    public static void Roster(Owner p)
    {
        int x = 5;
        Write.Line(x, 4, Colour.ITEM + "MAIN");
        for (int i = 0; i < p.Roster.Count; i++)
        {
            Write.Line(x, 6,  Colour.NAME + p.Roster[i].Name + Colour.RESET);
            Write.Line(x, 8,  Colour.HEALTH + "Wins" + Colour.RESET  + $"       { p.Roster[i].Win}");
            Write.Line(x, 9,  Colour.DAMAGE + "Strength" + Colour.RESET + $"   {p.Roster[i].Strength}");
            Write.Line(x, 10, Colour.HIT + "Offence" + Colour.RESET  + $"    {p.Roster[i].Offence}");
            Write.Line(x, 11, Colour.HIT + "Defence" + Colour.RESET  + $"    {p.Roster[i].Defence}");
            Write.Line(x, 12, Colour.SPEAK + "Endurance" + Colour.RESET + $"  {p.Roster[i].Endurance}");
            if (p.Roster[i].Traits.Count > 0) Write.Line(x, 14, Colour.ABILITY + $"{p.Roster[i].Trait1}" + Colour.RESET);
            if (p.Roster[i].Traits.Count > 1) Write.Line(x, 15, Colour.ABILITY + $"{p.Roster[i].Trait2}" + Colour.RESET);
            if (p.Roster[i].Traits.Count > 2) Write.Line(x, 16, Colour.ABILITY + $"{p.Roster[i].Trait3}" + Colour.RESET);
            x += 25;
        }
    }

    internal static void ToHub() { Location.list[0].Go(); }
}