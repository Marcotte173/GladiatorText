using System;
using System.Collections.Generic;
using System.Text;

public class Blade : Weapon
{
    public Blade(int level, int tier)
    : base(level, tier)
    {
        damage = level + tier * 2;
        if (level == 0) name = "Fist";
    }
}