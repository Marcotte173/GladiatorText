using System;
using System.Collections.Generic;
using System.Text;

public class ArmArmor : Armor
{
    public ArmArmor(int level, int tier)
    : base(level, tier)
    {
        HP = MaxHP = level;
        name =$"{quality}{material}Vambraces" ;
        if (level == 0) name = "None";
    }
}