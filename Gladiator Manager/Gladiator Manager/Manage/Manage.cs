using System;
using System.Collections.Generic;
using System.Text;

public class Manage:Location
{
    
    public Manage()
    : base()
    {

    }
    public override void Menu()
    {
        Console.Clear();
        Write.Line("You are at your compound, surveying your team.");
        Write.Line("From here you can manage your gladiators. \nTraining, Healing, you can even try to help them gain a competitive edge");
        Return.Roster(Owner.p);        
        Write.Line(0, 25, "[1] " + Colour.HIT + "Assign your main gladiator\n" + Colour.RESET);        
        Write.Line("[2] " + Colour.ENERGY + "Train a Gladiator" + Colour.RESET);
        Write.Line("[3] " + Colour.DEFENCE + "Release a Gladiator" + Colour.RESET);
        Write.Line("[0] " + Colour.TIME + "Return to the Main Hub" + Colour.RESET);
        string choice = Return.Option();
        if (choice == "1")
        {
            Console.Clear();
            Write.Line("You are at your compound, surveying your team.");
            Write.Line("From here you can manage your gladiators. \nTraining, Healing, you can even try to help them gain a competitive edge");
            Return.Roster(Owner.p);
            Write.Line(0, 20, "Who would your like to be your main Gladiator?\n[0] to Return\n\n");
            for (int i = 0; i < Owner.p.Roster.Count; i++)
            {
                Write.Line($"[{i + 1}] {Owner.p.Roster[i].Name}");
            }
            Gladiator g = new Gladiator(1);
            int glad = Return.Int();
            if (glad > 0 && glad <= Owner.p.Roster.Count)
            {
                g = Owner.p.Roster[glad - 1];
                Gladiator temp = new Gladiator(1);
                temp = Owner.p.Roster[0];
                Owner.p.Roster[0] = g;
                Owner.p.Roster[glad - 1] = temp;
            }
            else if (glad == 0) Location.list[0].Go();
        }
        else if (choice == "2")
        {

        }
        else if (choice == "3")
        {
            Console.Clear();
            Write.Line("You are at your compound, surveying your team.");
            Write.Line("From here you can manage your gladiators. \nTraining, Healing, you can even try to help them gain a competitive edge");
            Return.Roster(Owner.p);
            Write.Line(0, 20, "Who would your like to release?\n[0] to Return\n\n");
            for (int i = 0; i < Owner.p.Roster.Count; i++)
            {
                Write.Line($"[{i + 1}] {Owner.p.Roster[i].Name}");
            }
            Gladiator g = new Gladiator(1);
            int glad = Return.Int();
            if (glad > 0 && glad <= Owner.p.Roster.Count)
            {
                g = Owner.p.Roster[glad - 1];
                Owner.p.Roster.Remove(g);
                Write.Line(g.Name + " has been released from your team.");
                Write.KeyPress();
            }
            else if (glad == 0) Location.list[0].Go();
        }
        else if (choice == "0") Location.list[0].Go();
        Menu();
    }    
}