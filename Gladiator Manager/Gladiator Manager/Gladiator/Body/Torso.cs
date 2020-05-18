using System;
using System.Collections.Generic;
using System.Text;

public class Torso : Body
{
    protected Head head;
    protected Arm rightArm;
    protected Arm leftArm;
    protected Leg rightLeg;
    protected Leg leftLeg;

    TorsoArmor armor;
    public Torso()
    : base()
    {
        head = new Head();
        rightArm = new Arm();
        leftArm = new Arm();
        rightLeg = new Leg();
        leftLeg = new Leg();
        hp = maxHp = 8;
        armor = new TorsoArmor(0, 0);
    }
    public Arm RightArm { get { return rightArm; } set { rightArm = value; } }
    public Arm LeftArm { get { return leftArm; } set { leftArm = value; } }
    public Leg RightLeg { get { return rightLeg; } set { rightLeg = value; } }
    public Leg LeftLeg { get { return leftLeg; } set { leftLeg = value; } }
    public override void TakeDamage(int damage)
    {
        if (armor.HP > 0)
        {
            if(armor.HP >= damage) armor.TakeDamage(damage);
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
    public Head Head { get { return head; } set { head = value; } }
    public TorsoArmor Armor { get { return armor; } set { armor = value; } }
}