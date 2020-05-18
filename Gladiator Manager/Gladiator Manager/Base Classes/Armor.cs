using System;
using System.Collections.Generic;
using System.Text;

public class Armor:Equipment
{
    int maxHp;
    int hp;
    int fatigue;
    int encumbrance;
    protected bool destroyed;
    protected bool undamaged;
    protected bool damaged;
    protected bool severelyDamaged;
    protected bool none;
    protected string quality;
    protected string material;
    public Armor(int level, int tier)
    : base(level,tier)
    {        
        quality = (tier == 0) ? "Battered " : (tier == 1) ? "" : (tier == 2) ? "Nice " : "Superior ";
        material = (level == 0) ? "None" : (level == 1) ? "Leather " : (level == 2) ? "Chain " : "Plate ";
        fatigue = level;
    }
    public int HP { get { return hp; } set { hp = value; } }
    public int MaxHP { get { return maxHp; } set { maxHp = value; } }
    public int Fatigue { get { return hp; } set { hp = value; } }
    public int Encumbrance { get { return encumbrance; } set { encumbrance = value; } }
    public bool Destroyed { get { return destroyed; } set { destroyed = value; } }
    public bool Undamaged { get { return undamaged; } set { undamaged = value; } }
    public bool Damaged { get { return damaged; } set { damaged = value; } }
    public bool SeverelyDamaged { get { return severelyDamaged; } set { severelyDamaged = value; } }
    public virtual void CheckStatus()
    {
        if (level == 0)
        {
            none = true;
            destroyed = false;
            undamaged = false;
            damaged = false;
            severelyDamaged = false;
        }
        else if (hp <= 0)
        {
            destroyed = true;
            undamaged = false;
            damaged = false;
            severelyDamaged = false;
            none = false;
        }
        else if (hp == maxHp)
        {
            destroyed = false;
            undamaged = true;
            damaged = false;
            severelyDamaged = false;
            none = false;
        }
        else if (hp < maxHp && (hp == 1 && hp == 2))
        {
            destroyed = false;
            undamaged = false;
            damaged = false;
            severelyDamaged = true;
            none = false;
        }
        else
        {
            destroyed = false;
            undamaged = false;
            damaged = true;
            severelyDamaged = false;
            none = false;
        }        
    }
    public virtual void TakeDamage(int damage)
    {
        hp -= damage;        
    }
    public string Status { get { return (undamaged) ? Colour.HEALTH + "Undamaged" + Colour.RESET : (destroyed) ? Colour.DAMAGE + "Destroyed" + Colour.RESET : (severelyDamaged) ? Colour.GOLD + "Severely Damaged" + Colour.RESET : (Damaged)?Colour.HIT + "Damaged" + Colour.RESET:"None"; } }
}