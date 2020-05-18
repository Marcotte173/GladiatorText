using System;
using System.Collections.Generic;
using System.Text;

public class Slaver : Location
{
    new public static List<Gladiator> list = new List<Gladiator> { };

    internal static void NewStock()
    {
        list.Clear();
        for (int i = 0; i < 9; i++) { Gladiator.Create(Return.RandomInt(1,3)); }
        Gladiator temp;
        for (int j = 0; j <= list.Count - 2; j++)
        {
            for (int i = 0; i <= list.Count - 2; i++)
            {
                if (list[i].Price < list[i + 1].Price)
                {
                    temp = list[i + 1];
                    list[i + 1] = list[i];
                    list[i] = temp;
                }
            }
        }
    }

    public Slaver()
    : base()
    {
         
    }

    public override void Menu()
    {
        base.Menu();
        Console.WriteLine("You walk into the slaver's compound");
        Console.WriteLine("Rizzo walks up to you");
        Write.Line("'Greeting my friend! You're here for new gladiators, yes? Come take a look!'");
        Write.KeyPress();
        Display();
    }

    private void Display()
    {
        DisplayGladiator();
        Write.Line(0, 25,"'Well? Does anyone catch your eye?'");
        Write.Line(0, 26, "[0] to return");
        Gladiator g = new Gladiator(1);
        int choice = Return.Int();
        if (choice > 0 && choice <= list.Count) g = list[choice - 1];
        else if (choice == 0) Location.list[0].Go();
        else Display();
        DisplayGladiator();
        Write.Line(15, 18, g.Name);
        Write.Line(15, 19, "Price " + g.Price);
        if (Return.Afford(g.Price))
        {             
            if (Write.Confirm(15, 20))
            {
                Write.Line(0, 25, $"'Wonderful!'\nRizzo takes your money, and {g.Name} joins your team\n");
                Owner.p.Gold -= g.Price;
                RosterAdd(g);
                Write.KeyPress();
                Location.list[0].Go();
            }
            else Display();
        }
        else
        {
            Write.Line(0, 25, "You can't afford it\n");
            Write.KeyPress();
            Location.list[0].Go();
        }
    }

    private void RosterAdd(Gladiator g)
    {
        if (Owner.p.Roster.Count < 5)
        {
            g.Owner = Owner.p;
            Owner.p.Roster.Add(g);
        }
        else
        {
            Write.Line("Your roster is full! Release a gladiator!");
            Write.KeyPress();
        }

    }

    private void DisplayGladiator()
    {
        Console.Clear();
        Write.Line(0, 0, "Num");
        Write.Line(5, 0, "Name");
        Write.Line(20, 0, "Strength");
        Write.Line(35, 0, "Offence");
        Write.Line(50, 0, "Defence");
        Write.Line(65, 0, "Endurance");
        Write.Line(80, 0, "Price");
        for (int i = 0; i < list.Count; i++)
        {
            Write.Line(1, i + 2, (i + 1).ToString());
            Write.Line(5, i + 2, list[i].Name);
            Write.Line(23, i + 2, list[i].Strength.ToString());
            Write.Line(38, i + 2, list[i].Offence.ToString());
            Write.Line(53, i + 2, list[i].Defence.ToString());
            Write.Line(69, i + 2, list[i].Endurance.ToString());
            Write.Line(80, i + 2, list[i].Price.ToString());
        }
    }
}