using System;
using System.Collections.Generic;
using System.Text;

public class ComputerOwner:Owner
{    
    public ComputerOwner(int gladiators, int level, int goldBoost, int prestigeBoost)
    : base()
    {
        prestige = 100 + prestigeBoost;
        gold = 1000 + goldBoost;
        win = 0;
        loss = 0;
        name = Gladiator.list[Return.RandomInt(0, list.Count)];
        for (int i = 0; i < gladiators; i++)
        {
            Gladiator g = new Gladiator(Return.RandomInt(3,level));
            Roster.Add(g);
            g.Owner = this;
        }
    }
}