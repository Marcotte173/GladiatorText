using System;
using System.Collections.Generic;
using System.Text;

public class Body
{
    protected int maxHp;
    protected int hp;
    protected bool disabled;
    protected bool uninjured;
    protected bool injured;
    protected bool severelyInjured;

    public Body()
    {
        uninjured = true;
    }
    public int HP { get { return hp; } set { hp = value; } }
    public int MaxHP { get { return maxHp; } set { maxHp = value; } }
    public bool Disabled { get { return disabled; } set { disabled = value; } }
    public bool Undamaged { get { return uninjured; } set { uninjured = value; } }
    public bool Damaged { get { return injured; } set { injured = value; } }
    public bool SeverelyDamaged { get { return severelyInjured; } set { severelyInjured = value; } }
    public virtual void CheckStatus() 
    {
        if (hp <= 0)
        {
            disabled = true;
            uninjured = false;
            injured = false;
            severelyInjured = false;
        }
        else if (hp == maxHp)
        {
            disabled = false;
            uninjured = true;
            injured = false;
            severelyInjured = false;
        }
        else if (hp < maxHp && (hp == 1 && hp == 2))
        {
            disabled = false;
            uninjured = false;
            injured = false;
            severelyInjured = true;
        }
        else 
        {
            disabled = false;
            uninjured = false;
            injured = true;
            severelyInjured = false;
        }        
    }
    public virtual void TakeDamage(int damage)
    {
        hp -= damage;        
    }
    public string Status { get { return (uninjured) ? Colour.HEALTH + "Uninjured" + Colour.RESET : (disabled) ? Colour.DAMAGE + "Disabled" + Colour.RESET : (severelyInjured) ? Colour.GOLD + "Severely Injured" + Colour.RESET : Colour.HIT + "Injured" + Colour.RESET; }}
}