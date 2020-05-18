using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

public class Hub:Location
{
    static Owner p = Owner.p;
    static List<Owner> ownerList = Owner.list;
    public static int day = 1;
    static bool audience;
    public Hub()
    : base()
    {

    }
    public override void Menu()
    {
        Console.Clear();
        Return.Info();
        Return.Roster(p);
        while (day < 11)
        {            
            Write.Line(0, 18, "[1] " + Colour.GOLD + "Hire Gladiators\n" + Colour.RESET);
            Write.Line("[2] " + Colour.ENERGY + "Manage Gladiators" + Colour.RESET);
            Write.Line("[3] " + Colour.ITEM + "Purchase Equipment" + Colour.RESET);
            Write.Line("[4] " + Colour.ENERGY + "Jobs" + Colour.RESET);
            Write.Line("[5] " + Colour.ENERGY + "Shady Jobs" + Colour.RESET);
            Write.Line("[6] " + Colour.DEFENCE + "Graveyard" + Colour.RESET);
            Write.Line("[7] " + Colour.XP + "Owner Rankings" + Colour.RESET);
            if (audience) Write.Line("[8] " + Colour.XP + "Audience with the emperor" + Colour.RESET);
            else Write.Line("[X] " + Colour.MITIGATION + "The emperor has no interest in you" + Colour.RESET);
            Write.Line("[X] " + Colour.MITIGATION + "Not implemented" + Colour.RESET);
            Write.Line("[0] " + Colour.TIME + "Next day" + Colour.RESET);
            Write.Line("[?] Help");
            string choice = Return.Option();
            if (choice == "1") Location.list[1].Go();
            else if (choice == "2") Location.list[2].Go();
            else if (choice == "3") Location.list[3].Go();
            else if (choice == "9") { }
            else if (choice == "0")
            {
                Arena.Match(ownerList[0].Roster[0], ownerList[1].Roster[0]);
                Arena.Match(ownerList[2].Roster[0], ownerList[3].Roster[0]);
                Arena.Match(ownerList[4].Roster[0], ownerList[5].Roster[0]);
                Arena.Match(ownerList[6].Roster[0], ownerList[7].Roster[0]);
                Arena.Match(ownerList[8].Roster[0], ownerList[9].Roster[0]);
                day++;
                p.Action = 3;
                if (day % 3 == 0) Slaver.NewStock();
                Recap.Go();
            }
            Menu();
        }        
    }

    
}