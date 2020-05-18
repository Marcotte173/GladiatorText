using System;
using System.Collections.Generic;
using System.Text;

public class Weapon:Equipment
{
    protected int damage;
    protected string type;
    public Weapon(int level, int tier)
    : base(level, tier)
    {

    }
    public int Damage { get { return damage; } set { damage = value; } }
    public string Type { get { return type; } set { type = value; } }
}