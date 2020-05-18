using System;
using System.Collections.Generic;
using System.Text;

public class Leg : Body
{
    bool peg;
    LegArmor armor;
    public Leg()
    : base()
    {
        hp = maxHp = 5;
        armor = new LegArmor(0, 0);
    }
    public override void TakeDamage(int damage)
    {
        if (armor.HP > 0)
        {
            if (armor.HP >= damage) armor.TakeDamage(damage);
            else
            {
                armor.TakeDamage(armor.HP);
                base.TakeDamage(damage - armor.HP);
            }
        }
        else base.TakeDamage(damage);
    }
    public LegArmor Armor { get { return armor; } set { armor = value; } }
    public bool Peg { get { return peg; } set { peg = value; } }
}