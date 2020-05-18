using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;

public class Arena:Location
{
    internal static Gladiator Gladiator1 = new Gladiator(2);
    internal static Gladiator Gladiator2 = new Gladiator(2);
    static bool player;
    public Arena()
    :base()
    {
        
    }
    public override void Menu()
    {
        if (Gladiator1.Owner == Owner.p || Gladiator2.Owner == Owner.p) player = true;
        else player = false;
        Fight();
        
    }
    private void Fight()
    {
        if (player)
        {
            Console.Clear();
            UI();
            Console.SetCursorPosition(0, 22);
            Write.Line("Welcome to the arena!\n");
            Write.Line($"The next match to be fought is between {Gladiator1.Name} and {Gladiator2.Name}!\n");
            Write.KeyPress();
        }
        while (Gladiator1.DeathCheck() == false && Gladiator2.DeathCheck() == false)
        {
            for (int i = 0; i < 4; i++)
            {
                if (player)
                {
                    Console.Clear();
                    UI();
                    Console.SetCursorPosition(0, 22);
                }
                Attack();
                if (Gladiator1.DeathCheck())
                {
                    if (player)
                    {
                        Console.Clear();
                        UI();
                        Console.SetCursorPosition(0, 24);
                        Write.Line($"{Gladiator2.Name} has defeated {Gladiator1.Name}");                        
                    }
                    Recap.Calculate(Gladiator1, Gladiator2);
                    break;
                }
                if (Gladiator2.DeathCheck())
                {
                    if (player)
                    {
                        Console.Clear();
                        UI();
                        Console.SetCursorPosition(0, 24);
                        Write.Line($"{Gladiator1.Name} has defeated {Gladiator2.Name}");                                            
                    }
                    Recap.Calculate(Gladiator2, Gladiator1);
                    break;
                }
                if(player)Thread.Sleep(1500);
            }
            Fatigue();            
            if (player) Write.KeyPress();
        }    
        
    }

    private void Fatigue()
    {
        Gladiator1.Endurance -= Gladiator1.Fatigue;
        Gladiator2.Endurance -= Gladiator2.Fatigue;
    }

    private void Attack()
    {
        //Bonuses based on strength
        int g1Bonus = (Gladiator1.Strength - 10) / 2;
        int g2Bonus = (Gladiator2.Strength - 10) / 2;
        //Gladiator 1 Right and left hand. Shield Bonus
        //Empty Right Hand is 2, or Weapon Dam
        int weapon1R = (Gladiator1.Torso.RightArm.Hand.Weapon.Level == 0) ? 2 : Gladiator1.Torso.RightArm.Hand.Weapon.Damage;
        if (Gladiator1.Traits.Contains((Trait)11) && Gladiator1.Torso.RightArm.Hand.Weapon.Level == 0) weapon1R += 2;
        //Block value is shield if they have on or 0
        int shield1 = (Gladiator1.Torso.LeftArm.Hand.Weapon.Type == "Shield") ? Gladiator1.Torso.LeftArm.Hand.Weapon.Damage : 0;
        //Empty Left Hand is 0, or Weapon Dam
        int weapon1L = 0;
        if (Gladiator1.Traits.Contains((Trait)14)) weapon1L += (Gladiator1.Torso.LeftArm.Hand.Weapon.Level == 0 && Gladiator1.Traits.Contains((Trait)11)) ? 2 : Gladiator1.Torso.LeftArm.Hand.Weapon.Damage;

        //Gladiator 2 Right and left hand. Shield Bonus
        //Empty Right Hand is 2, or Weapon Dam
        int weapon2R = (Gladiator2.Torso.RightArm.Hand.Weapon.Level == 0)? 2 : Gladiator2.Torso.RightArm.Hand.Weapon.Damage;
        if (Gladiator2.Traits.Contains((Trait)11) && Gladiator2.Torso.RightArm.Hand.Weapon.Level == 0) weapon2R += 2;
        //Block value is shield if they have on or 0
        int shield2 = (Gladiator2.Torso.LeftArm.Hand.Weapon.Type == "Shield") ? Gladiator2.Torso.LeftArm.Hand.Weapon.Damage : 0;
        //Empty Left Hand is 0, or Weapon Dam
        int weapon2L =  0;
        if (Gladiator2.Traits.Contains((Trait)14)) weapon2L += (Gladiator2.Torso.LeftArm.Hand.Weapon.Level == 0 && Gladiator2.Traits.Contains((Trait)11)) ? 2 : Gladiator2.Torso.LeftArm.Hand.Weapon.Damage;

        int attackRoll = Return.RandomInt(1, 101);
        if (attackRoll < 96 && attackRoll > 5)
        {
            attackRoll -= Gladiator1.Offence;
            attackRoll += Gladiator2.Offence;
            if (attackRoll < 50)
            {
                attackRoll += Gladiator2.Defence - Gladiator1.Offence;
                attackRoll = (attackRoll > 50) ? 50 : attackRoll;
            }
            if (attackRoll > 50)
            {
                attackRoll += Gladiator1.Defence - Gladiator2.Offence;
                attackRoll = (attackRoll < 50) ? 50 : attackRoll;
            }
            if (attackRoll < (41 - shield2) && attackRoll >= (25-shield2))
            {
                //Gladiator1 strikes
                int damage = (weapon1R + weapon1L)/2 + g1Bonus / 2;
                damage = (damage <= 0) ? damage = 1 : damage;
                Body body = Target(Gladiator2);
                if (body.Disabled == false)
                {
                    body.TakeDamage(damage);
                    if (body.Disabled)
                    {
                        Gladiator2.MaxEndurance -= 5;
                        Gladiator2.Endurance = (Gladiator2.Endurance - 10 <= 0) ? 0 : Gladiator2.Endurance;
                    }
                }
                if (player) Console.Write(Flavor(Gladiator1, Gladiator2, body, 1));
            }
            else if (attackRoll < (25 - shield2) && attackRoll >=(11-shield2))
            {
                //Gladiator1 strikes
                int damage = weapon1R + weapon1L + g1Bonus;
                damage = (damage <= 0) ? damage = 1 : damage;
                Body body = Target(Gladiator2);
                if (body.Disabled == false)
                {
                    body.TakeDamage(damage);
                    if (body.Disabled)
                    {
                        Gladiator2.MaxEndurance -= 5;
                        Gladiator2.Endurance = (Gladiator2.Endurance - 10 <= 0) ? 0 : Gladiator2.Endurance;
                    }
                }                
                if (player) Console.Write(Flavor(Gladiator1, Gladiator2, body, 2));
            }
            else if (attackRoll < (11 - shield2))
            {
                //Gladiator1 strikes
                int damage = weapon1R + weapon1L + g1Bonus *2;
                damage = (damage <= 0) ? damage = 1 : damage;
                Body body = Target(Gladiator2);
                if (body.Disabled == false)
                {
                    body.TakeDamage(damage);
                    if (body.Disabled)
                    {
                        Gladiator2.MaxEndurance -= 5;
                        Gladiator2.Endurance = (Gladiator2.Endurance - 10 <= 0) ? 0 : Gladiator2.Endurance;
                    }
                }
                if (player) Console.Write(Flavor(Gladiator1, Gladiator2, body, 3));
            }
            else if (attackRoll > (59 + shield1) && attackRoll <=(75+shield1))
            {
                //Gladiator2 strikes
                int damage = (weapon2R + weapon2L) / 2 + g2Bonus/2;
                damage = (damage <= 0) ? damage = 1 : damage;
                Body body = Target(Gladiator1);
                if (body.Disabled == false)
                {
                    body.TakeDamage(damage);
                    if (body.Disabled)
                    {
                        Gladiator1.MaxEndurance -= 5;
                        Gladiator1.Endurance = (Gladiator1.Endurance - 10 <= 0) ? 0 : Gladiator1.Endurance;
                    }
                }
                if (player) Console.Write(Flavor(Gladiator2, Gladiator1, body, 1));
            }
            else if (attackRoll > (75 + shield1) && attackRoll <= (90 + shield1))
            {
                //Gladiator2 strikes
                int damage = weapon2R + weapon2L + g2Bonus;
                damage = (damage <= 0) ? damage = 1 : damage;
                Body body = Target(Gladiator1);
                if (body.Disabled == false)
                {
                    body.TakeDamage(damage);
                    if (body.Disabled)
                    {
                        Gladiator1.MaxEndurance -= 5;
                        Gladiator1.Endurance = (Gladiator1.Endurance - 10 <= 0) ? 0 : Gladiator1.Endurance;
                    }
                }
                if (player) Console.Write(Flavor(Gladiator2, Gladiator1, body, 2));
            }
            else if (attackRoll > (90 + shield1))
            {
                //Gladiator2 strikes
                int damage = weapon2R + weapon2L + g2Bonus*2;
                damage = (damage <= 0) ? damage = 1 : damage;
                Body body = Target(Gladiator1);
                if (body.Disabled == false)
                {
                    body.TakeDamage(damage);
                    if (body.Disabled)
                    {
                        Gladiator1.MaxEndurance -= 5;
                        Gladiator1.Endurance = (Gladiator1.Endurance - 10 <= 0) ? 0 : Gladiator1.Endurance;
                    }
                }
                if (player) Console.Write(Flavor(Gladiator2, Gladiator1, body, 3));
            }
            else if(player) Write.Line("The gladiators square off, neither gaining a real advantage");                
        }
        else
        {
            if (attackRoll < 6)
            {
                int damage = weapon1R + weapon1L + (Gladiator1.Strength - 10); 
                damage = (damage <= 0) ? damage = 1 : damage;
                Body body = Target(Gladiator2);
                if (body.Disabled == false)
                {
                    body.TakeDamage(damage);
                    if (body.Disabled)
                    {
                        Gladiator2.MaxEndurance -= 5;
                        Gladiator2.Endurance = (Gladiator2.Endurance - 10 <= 0) ? 0 : Gladiator2.Endurance;
                    }
                }
                if (player) Console.Write(Flavor(Gladiator1, Gladiator2, body, 3));
            }
            if (attackRoll > 95)
            {
                int damage = weapon2R + weapon2L + (Gladiator1.Strength - 10); 
                damage = (damage <= 0) ? damage = 1 : damage;
                Body body = Target(Gladiator2);
                if (body.Disabled == false)
                {
                    body.TakeDamage(damage);
                    if (body.Disabled)
                    {
                        Gladiator1.MaxEndurance -= 5;
                        Gladiator1.Endurance = (Gladiator1.Endurance - 10 <= 0) ? 0 : Gladiator1.Endurance;
                    }
                }
                if (player) Console.Write(Flavor(Gladiator2, Gladiator1, body, 3));
            }
        }        
    }

    private string Flavor(Gladiator attacker, Gladiator defender, Body body, int x)
    {
        if (body == Gladiator2.Torso.Head || body == Gladiator1.Torso.Head)
        {
            if (x == 1) return $"{attacker.Name} hits {defender.Name} in {body} : level 1";
            else if (x == 2) return $"{attacker.Name} hits {defender.Name} in {body} : level 2";
            else return $"{attacker.Name} hits {defender.Name} in {body} : level 3";
        }
        else if(body == Gladiator2.Torso || body == Gladiator1.Torso)
        {
            if (x == 1) return $"{attacker.Name} hits {defender.Name} in {body} : level 1";
            else if (x == 2) return $"{attacker.Name} hits {defender.Name} in {body} : level 2";
            else return $"{attacker.Name} hits {defender.Name} in {body} : level 3";
        }
        else if (body == Gladiator2.Torso.RightArm || body == Gladiator1.Torso.RightArm)
        {
            if (x == 1) return $"{attacker.Name} hits {defender.Name} in {body} : level 1";
            else if (x == 2) return $"{attacker.Name} hits {defender.Name} in {body} : level 2";
            else return $"{attacker.Name} hits {defender.Name} in {body} : level 3";
        }
        else if (body == Gladiator2.Torso.RightArm.Hand || body == Gladiator1.Torso.RightArm.Hand)
        {
            if (x == 1) return $"{attacker.Name} hits {defender.Name} in {body} : level 1";
            else if (x == 2) return $"{attacker.Name} hits {defender.Name} in {body} : level 2";
            else return $"{attacker.Name} hits {defender.Name} in {body} : level 3";
        }
        else if (body == Gladiator2.Torso.LeftArm || body == Gladiator1.Torso.LeftArm)
        {
            if (x == 1) return $"{attacker.Name} hits {defender.Name} in {body} : level 1";
            else if (x == 2) return $"{attacker.Name} hits {defender.Name} in {body} : level 2";
            else return $"{attacker.Name} hits {defender.Name} in {body} : level 3";
        }
        else if (body == Gladiator2.Torso.LeftArm.Hand || body == Gladiator1.Torso.LeftArm.Hand)
        {
            if (x == 1) return $"{attacker.Name} hits {defender.Name} in {body} : level 1";
            else if (x == 2) return $"{attacker.Name} hits {defender.Name} in {body} : level 2";
            else return $"{attacker.Name} hits {defender.Name} in {body} : level 3";
        }
        else if (body == Gladiator2.Torso.RightLeg || body == Gladiator1.Torso.RightLeg)
        {
            if (x == 1) return $"{attacker.Name} hits {defender.Name} in {body} : level 1";
            else if (x == 2) return $"{attacker.Name} hits {defender.Name} in {body} : level 2";
            else return $"{attacker.Name} hits {defender.Name} in {body} : level 3";
        }
        else if (body == Gladiator2.Torso.LeftLeg || body == Gladiator1.Torso.LeftLeg)
        {
            if (x == 1) return $"{attacker.Name} hits {defender.Name} in {body} : level 1";
            else if (x == 2) return $"{attacker.Name} hits {defender.Name} in {body} : level 2";
            else return $"{attacker.Name} hits {defender.Name} in {body} : level 3";
        }
        else return "";
    }

    internal Body Target(Gladiator g)
    {
        int x = Return.RandomInt(0, 12);
        if (x == 0) return g.Torso.Head;
        else if (x == 1||x==2) return g.Torso.RightArm;
        else if (x == 3) return g.Torso.RightArm.Hand;
        else if (x == 4||x==5) return g.Torso.LeftArm;
        else if (x == 6) return g.Torso.LeftArm.Hand;
        else if (x == 7) return g.Torso.LeftLeg;
        else if (x == 8) return g.Torso.RightLeg;
        else return g.Torso;
    }

    public static void Match(Gladiator a, Gladiator b)
    {
        Gladiator1 = a;
        Gladiator2 = b;
        Location.list[10].Go();
    }    

    private static void UI()
    {
        Display(0, Gladiator1);
        for (int i = 0; i < 120; i++)
        {
            Write.Line(i, 10, "-");
            Write.Line(i, 20, "-");
        }
        for (int i = 0; i < 20; i++)
        {
            Write.Line(58, i, Colour.MITIGATION + "|" + Colour.RESET);
            Write.Line(59, i, Colour.MITIGATION + "|" + Colour.RESET);
        }
        Write.Line(58, 20, "+");
        Write.Line(59, 20, "+");
        Display(60, Gladiator2);
    }

    private static void Display(int x, Gladiator g)
    {
        g.Torso.Head.CheckStatus();
        g.Torso.CheckStatus();
        g.Torso.RightLeg.CheckStatus();
        g.Torso.RightArm.CheckStatus();
        g.Torso.RightArm.Hand.CheckStatus();
        g.Torso.LeftLeg.CheckStatus();
        g.Torso.LeftArm.CheckStatus();
        g.Torso.LeftArm.Hand.CheckStatus();
        g.Torso.Head.Armor.CheckStatus();
        g.Torso.Armor.CheckStatus();
        g.Torso.RightLeg.Armor.CheckStatus();
        g.Torso.RightArm.Armor.CheckStatus();
        g.Torso.RightArm.Hand.Armor.CheckStatus();
        g.Torso.LeftLeg.Armor.CheckStatus();
        g.Torso.LeftArm.Armor.CheckStatus();
        g.Torso.LeftArm.Hand.Armor.CheckStatus();
        Write.Character(x, 0, g.Name, "", "");
        Write.Line(x, 2, $"Strength   {g.Strength}");
        Write.Line(x, 3, $"Offence    {g.Offence}");
        Write.Line(x, 4, $"Defence    {g.Defence}");
        Write.Line(x, 5, $"Endurance  {g.Endurance}/{g.MaxEndurance}");
        Write.Line(x + 17, 0, Colour.SPEAK + "Head Armor" + Colour.RESET);
        Write.Line(x + 17, 1, Colour.ITEM + g.Torso.Head.Armor.Name + Colour.RESET);
        Write.Line(x + 17, 2, Colour.SPEAK + "Body Armor" + Colour.RESET);
        Write.Line(x + 17, 3, Colour.ITEM + g.Torso.Armor.Name + Colour.RESET);
        Write.Line(x + 17, 4, Colour.SPEAK + "Leg Armor" + Colour.RESET);
        Write.Line(x + 17, 5, Colour.ITEM + g.Torso.RightLeg.Armor.Name + Colour.RESET);
        Write.Line(x + 17, 6, Colour.SPEAK + "Arm Armor" + Colour.RESET);
        Write.Line(x + 17, 7, Colour.ITEM + g.Torso.RightArm.Armor.Name + Colour.RESET);
        Write.Line(x + 17, 8, Colour.SPEAK + "Gloves" + Colour.RESET);
        Write.Line(x + 17, 9, Colour.ITEM + g.Torso.RightArm.Hand.Armor.Name + Colour.RESET);
        Write.Character(x, 11, "LOCATION", $"STATUS", "ARMOR");
        Write.Character(x, 12, "Head", g.Torso.Head.Status,                 g.Torso.Head.Armor.Status);
        Write.Character(x, 13, "Torso", g.Torso.Status,                     g.Torso.Armor.Status);
        Write.Character(x, 14, "Right Arm", g.Torso.RightArm.Status,        g.Torso.RightArm.Armor.Status);
        Write.Character(x, 15, "Right Hand", g.Torso.RightArm.Hand.Status,  g.Torso.RightArm.Hand.Armor.Status);
        Write.Character(x, 16, "Left Arm", g.Torso.LeftArm.Status,          g.Torso.LeftArm.Armor.Status);
        Write.Character(x, 17, "Left Hand", g.Torso.LeftArm.Hand.Status,    g.Torso.LeftArm.Hand.Armor.Status);
        Write.Character(x, 18, "Right Leg", g.Torso.RightLeg.Status,        g.Torso.RightLeg.Armor.Status);
        Write.Character(x, 19, "Left Leg", g.Torso.LeftLeg.Status,          g.Torso.LeftLeg.Armor.Status);
        Write.Line(x + 43, 0, Colour.SPEAK + "Main Hand" + Colour.RESET);
        Write.Line(x + 43, 2, Colour.SPEAK + "Off Hand" + Colour.RESET);
        Write.Line(x + 43, 1, Colour.ITEM + g.Torso.RightArm.Hand.Weapon.Name + Colour.RESET);
        Write.Line(x + 43, 3, Colour.ITEM + g.Torso.LeftArm.Hand.Weapon.Name + Colour.RESET);
        Write.Line(x + 40, 11, "Traits");
        if (g.Traits.Count > 0) Write.Line(x + 40, 12, g.Trait1);
        if (g.Traits.Count > 1) Write.Line(x + 40, 13, g.Trait2);
        if (g.Traits.Count > 2) Write.Line(x + 40, 14, g.Trait3);
    }
}