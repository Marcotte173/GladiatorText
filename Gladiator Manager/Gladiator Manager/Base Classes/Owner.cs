using System;
using System.Collections.Generic;
using System.Text;

public class Owner
{    
    public static Owner p = Gladiator_Manager.Program.p;
    public static List<Owner> list = new List<Owner> { p };
    protected string name;
    protected int prestige;
    protected int gold;
    protected int actions;
    protected int win;
    protected int loss;
    protected int matches; 
    List<Gladiator> roster = new List<Gladiator> { } ;
    public Owner()
    {
        matches = 0;
        prestige = 100;
        gold = 2000;
        actions = 3;
        win = 0;
        loss = 0;
        Gladiator g = new Gladiator(5);
        roster.Add(g);
        g.Owner = this;
    }
    public string Name { get { return name; } set { name = value; } }
    public int Prestige { get { return prestige; } set { prestige = value; } }
    public int Gold { get { return gold; } set { gold = value; } }
    public int Action { get { return actions; } set { actions = value; } }
    public int Win { get { return win; } set { win = value; } }
    public int Loss { get { return loss; } set { loss = value; } }
    public int Matches { get { return matches; } set { matches = value; } }
    public List<Gladiator> Roster { get { return roster; } set { roster = value; } }
}