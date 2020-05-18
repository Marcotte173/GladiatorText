using System;
using System.Collections.Generic;
using System.Text;

public class Arm:Body
{
    bool bladeArm;
    protected Hand hand;

    ArmArmor armor;
    public Arm()
    : base()
    {
        hp = maxHp = 5;
        hand = new Hand(false);
        armor = new ArmArmor(0, 0);
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
        if (disabled) hand.HP = 0;
        hand.CheckStatus();
    }
    public Hand Hand { get { return hand; } set { hand = value; } }
    public ArmArmor Armor { get { return armor; } set { armor = value; } }
    public bool BladeArm { get { return bladeArm; } set { bladeArm = value; } }
}