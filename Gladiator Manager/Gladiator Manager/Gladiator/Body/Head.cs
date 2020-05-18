using System;
using System.Collections.Generic;
using System.Text;

public class Head:Body
{
    int eyes;
    bool teeth;
    protected Head head;
    HeadArmor armor;

    public Head()
    : base()
    {
        eyes = 2;
        teeth = true;
        hp = maxHp = 5;
        armor = new HeadArmor(0, 0);
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
    public override void CheckStatus()
    {
        base.CheckStatus();
    }
    public HeadArmor Armor { get { return armor; } set { armor = value; } }
    public int Eyes { get { return eyes; } set { eyes = value; } }
    public bool Teeth { get { return teeth; } set { teeth = value; } }
}