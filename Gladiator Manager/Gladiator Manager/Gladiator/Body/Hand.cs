using System;
using System.Collections.Generic;
using System.Text;

public class Hand : Body
{
    bool hook;
    Weapon weapon;
    HandArmor armor;
    public Hand(bool dominant)
    :base()
    {
        hp = maxHp = 5;
        armor = new HandArmor(0, 0);
        weapon = new Blade(0, 0);
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
    public Weapon Weapon { get { return weapon; } set { weapon = value; } }
    public HandArmor Armor { get { return armor; } set { armor = value; } }
    public bool Hook { get { return hook; } set { hook = value; } }
}