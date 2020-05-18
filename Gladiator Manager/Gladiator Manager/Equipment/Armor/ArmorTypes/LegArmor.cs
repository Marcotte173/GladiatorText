using System;
using System.Collections.Generic;
using System.Text;

public class LegArmor : Armor
{
    public LegArmor(int level, int tier)
    : base(level, tier)
    {
        HP = MaxHP = level;
        name = $"{quality}{material}Legs";
        if (level == 0) name = "None";
    }
}