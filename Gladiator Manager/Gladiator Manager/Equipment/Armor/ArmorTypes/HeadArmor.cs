using System;
using System.Collections.Generic;
using System.Text;

public class HeadArmor:Armor
{
    public HeadArmor(int level, int tier)
    : base(level, tier)
    {
        HP = MaxHP = level*2;
        name = $"{quality}{material}Cap";
        if (level == 0) name = "None";
    }
}