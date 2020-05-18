using System;
using System.Collections.Generic;
using System.Text;

public enum Trait {MissingArm,MissingLeg,OneEye,Blind,MissingHand,Unflappable,FastLearner,SlowLearner,BladeMaster,ShieldExpert,HeightenedSenses,UnarmedMaster,Afraid,DeathResistant,Ambidextrous}; 
public class Gladiator
{
    protected string name;
    protected int maxStrength;
    protected int strength;
    protected int offence;
    protected int maxOffence;
    protected int endurance;
    protected int maxEndurance;
    protected int defence;
    protected int maxDefence;
    protected int creative;  
    protected Torso torso;
    protected int win;
    protected int price;
    protected Owner owner;
    protected List<Trait> traits = new List<Trait> { };
    public static List<string> list = new List<string> { };

    public Gladiator(int x)
    {
        int t = Return.RandomInt(5, 20);
        if (t > 4 && t < 14) { traits.Add((Trait)t); }
        strength = 8 + Return.RandomInt(1, 2*x);
        maxOffence = offence = Return.RandomInt(x + (x / 2), x * 3);
        maxDefence = defence = Return.RandomInt(x + (x / 2), x * 3);
        endurance = maxEndurance = Return.RandomInt(x *4, x * 6);     
        torso = new Torso();
        price = (strength + offence + defence + endurance) / 4 * 350 + Return.RandomInt(-125, 126);
        name = list[Return.RandomInt(0, list.Count)];
    }
    public string Name { get { return name; } set { name = value; } }
    public int Strength { get 
        {
            double En = Convert.ToDouble(endurance);
            double Men = Convert.ToDouble(maxEndurance);
            if (En / Men >= 0.75f) return strength;
            else if (En / Men > 0.5f) return strength / 3;
            else if (En / Men > 0.3f) return strength / 4;
            else return 0;
        }
        set { strength = value; } }
    public int Offence { 
        get 
        {
            double En = Convert.ToDouble(endurance);
            double Men = Convert.ToDouble(maxEndurance);
            if (En / Men >= 0.75f) return offence;
            else if (En / Men > 0.5f) return offence / 2;
            else if (En / Men > 0.3f) return offence / 3;
            else return 0;
        } 
        set { offence = value; } }
    public int Defence {
        get
        {
            double En = Convert.ToDouble(endurance);
            double Men = Convert.ToDouble(maxEndurance);
            if (En / Men >= 0.75f) return defence;
            else if (En / Men > 0.5f) return defence / 3;
            else if (En / Men > 0.3f) return defence / 4;
            else return 0;
        }       
        set { defence = value; } }
    public int MaxDefence { get { return maxDefence; } set { maxDefence = value; } }
    public int MaxStrength { get { return maxStrength; } set { maxStrength = value; } }
    public int MaxOffence { get { return maxOffence; } set { maxOffence = value; } }
    public int Win { get { return win; } set { win = value; } }
    public int Creative { get { return creative; } set { creative = value; } }
    public int Endurance { get { return endurance; } set { endurance = value; } }
    public int MaxEndurance { get { return maxEndurance; } set { maxEndurance = value; } }
    public Owner Owner { get { return owner; } set { owner = value; } }
    public Torso Torso { get { return torso; } set { torso = value; } }
    public List<Trait> Traits { get { return traits; } set { traits = value; } }
    public string Trait1 
    { 
        get 
        {
            if (traits[0] == Trait.Afraid) return "Afraid";
            else if (traits[0] == Trait.DeathResistant) return "Death Resistant";
            else if (traits[0] == Trait.UnarmedMaster) return "Unarmed Master";
            else if (traits[0] == Trait.HeightenedSenses) return "Heightened Senses";
            else if (traits[0] == Trait.ShieldExpert) return "Shield Expert";
            else if (traits[0] == Trait.BladeMaster) return "Blade Master";
            else if (traits[0] == Trait.SlowLearner) return "Slow Learner";
            else if (traits[0] == Trait.FastLearner) return "Fast Learner";
            else if (traits[0] == Trait.Ambidextrous) return "Ambidextrous";
            else return "Unflappable";
        } 
    }

    internal int Fatigue { get { return  2 + torso.Head.Armor.Fatigue + torso.Armor.Fatigue + torso.RightArm.Armor.Fatigue + torso.RightArm.Hand.Armor.Fatigue + torso.LeftArm.Armor.Fatigue + torso.LeftArm.Hand.Armor.Fatigue + torso.RightLeg.Armor.Fatigue + torso.LeftLeg.Armor.Fatigue; } }

    public string Trait2
    {
        get
        {
            if (traits[1] == Trait.Afraid) return "Afraid";
            else if (traits[1] == Trait.DeathResistant) return "Death Resistant";
            else if (traits[1] == Trait.UnarmedMaster) return "Unarmed Master";
            else if (traits[1] == Trait.HeightenedSenses) return "Heightened Senses";
            else if (traits[1] == Trait.ShieldExpert) return "Shield Expert";
            else if (traits[1] == Trait.BladeMaster) return "Blade Master";
            else if (traits[1] == Trait.SlowLearner) return "Slow Learner";
            else if (traits[1] == Trait.FastLearner) return "Fast Learner";
            else if (traits[1] == Trait.Ambidextrous) return "Ambidextrous";
            else return "Unflappable";
        }
    }
    public string Trait3
    {
        get
        {
            if (traits[2] == Trait.Afraid) return "Afraid";
            else if (traits[2] == Trait.DeathResistant) return "Death Resistant";
            else if (traits[2] == Trait.UnarmedMaster) return "Unarmed Master";
            else if (traits[2] == Trait.HeightenedSenses) return "Heightened Senses";
            else if (traits[2] == Trait.ShieldExpert) return "Shield Expert";
            else if (traits[2] == Trait.BladeMaster) return "Blade Master";
            else if (traits[2] == Trait.SlowLearner) return "Slow Learner";
            else if (traits[2] == Trait.FastLearner) return "Fast Learner";
            else if (traits[2] == Trait.Ambidextrous) return "Ambidextrous";
            else return "Unflappable";
        }
    }
    public int Price 
    { 
        get 
        {
            return
            price;
        } 
    }
    public bool DeathCheck()
    {
        return (Torso.Disabled|| Torso.Head.Disabled);
    }
    
    internal static void Create(int x)
    {
        Slaver.list.Add(new Gladiator(x));
    }
}