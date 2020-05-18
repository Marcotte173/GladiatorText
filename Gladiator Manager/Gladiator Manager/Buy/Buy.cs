using System;
using System.Collections.Generic;
using System.Text;

public class Buy:Location
{
    static List<int> armorUpgrade = new List<int> { 0, 150, 300, 450, 600, 800, 1000, 1200, 1500, 2000 };
    static List<int> weaponUpgrade = new List<int> { 0, 200, 400, 500, 600, 900, 1200, 1500, 2000, 2500 };
    static List<Blade> Weapons = new List<Blade>
    {
        new Blade(0,0),
        new Blade(1,0), //Dagger
        new Blade(1,1), //Dagger
        new Blade(1,2), //Dagger
        new Blade(2,0), //Sword
        new Blade(2,1), //Sword
        new Blade(2,2), //Sword
        new Blade(3,0), //2 Hand Swords
        new Blade(3,1), //2 Hand Swords
        new Blade(3,2), //2 Hand Swords
    };
    static List<HeadArmor> HeadArmor = new List<HeadArmor>
    {
        new HeadArmor(0,0),
        new HeadArmor(1,0), //Leather
        new HeadArmor(1,1), //Leather
        new HeadArmor(1,2), //Leather
        new HeadArmor(2,0), //Chain
        new HeadArmor(2,1), //Chain
        new HeadArmor(2,2), //Chain
        new HeadArmor(3,0), //Plate
        new HeadArmor(3,1), //Plate
        new HeadArmor(3,2), //Plate
    };
    static List<TorsoArmor> TorsoArmor = new List<TorsoArmor>
    {
        new TorsoArmor(0,0),
        new TorsoArmor(1,0), //Leather
        new TorsoArmor(1,1), //Leather
        new TorsoArmor(1,2), //Leather
        new TorsoArmor(2,0), //Chain
        new TorsoArmor(2,1), //Chain
        new TorsoArmor(2,2), //Chain
        new TorsoArmor(3,0), //Plate
        new TorsoArmor(3,1), //Plate
        new TorsoArmor(3,2), //Plate
    };
    static List<ArmArmor> ArmArmor = new List<ArmArmor>
    {
        new ArmArmor(0,0),
        new ArmArmor(1,0), //Leather
        new ArmArmor(1,1), //Leather
        new ArmArmor(1,2), //Leather
        new ArmArmor(2,0), //Chain
        new ArmArmor(2,1), //Chain
        new ArmArmor(2,2), //Chain
        new ArmArmor(3,0), //Plate
        new ArmArmor(3,1), //Plate
        new ArmArmor(3,2), //Plate
    };
    static List<HandArmor> HandArmor = new List<HandArmor>
    {
        new HandArmor(0,0),
        new HandArmor(1,0), //Leather
        new HandArmor(1,1), //Leather
        new HandArmor(1,2), //Leather
        new HandArmor(2,0), //Chain
        new HandArmor(2,1), //Chain
        new HandArmor(2,2), //Chain
        new HandArmor(3,0), //Plate
        new HandArmor(3,1), //Plate
        new HandArmor(3,2), //Plate
    };
    static List<LegArmor> LegArmor = new List<LegArmor>
    {
        new LegArmor(0,0),
        new LegArmor(1,0), //Leather
        new LegArmor(1,1), //Leather
        new LegArmor(1,2), //Leather
        new LegArmor(2,0), //Chain
        new LegArmor(2,1), //Chain
        new LegArmor(2,2), //Chain
        new LegArmor(3,0), //Plate
        new LegArmor(3,1), //Plate
        new LegArmor(3,2), //Plate
    };
    public Buy()
        :base()
    {

    }
    public override void Menu()
    {
        Console.Clear();
        Write.Line("You are at your compound, surveying your team.");
        Write.Line("From here you can manage your gladiators. \nTraining, Healing, you can even try to help them gain a competitive edge");
        Return.Roster(Owner.p);
        Write.Line(0, 20, "Who would your like to equip?\n[0] to Return\n\n");
        for (int i = 0; i < Owner.p.Roster.Count; i++)
        {
            Write.Line($"[{i + 1}] {Owner.p.Roster[i].Name}");
        }
        Gladiator g = new Gladiator(1);
        int glad = Return.Int();
        if (glad > 0 && glad <= Owner.p.Roster.Count)
        {
            g = Owner.p.Roster[glad - 1];
            Equip(g);
        }
        else if (glad == 0) Location.list[0].Go();
    }

    private void Equip(Gladiator g)
    {
        Console.Clear();
        Return.Info();
        Write.Line(20, 6, Colour.NAME + g.Name + Colour.RESET);
        Write.Line(20, 8, Colour.HEALTH + "Wins" + Colour.RESET + $"       { g.Win}");
        Write.Line(20, 9, Colour.DAMAGE + "Strength" + Colour.RESET + $"   {g.Strength}");
        Write.Line(20, 10, Colour.HIT + "Offence" + Colour.RESET + $"    {g.Offence}");
        Write.Line(20, 11, Colour.HIT + "Defence" + Colour.RESET + $"    {g.Defence}");
        Write.Line(20, 12, Colour.SPEAK + "Endurance" + Colour.RESET + $"  {g.Endurance}");
        if (g.Traits.Count > 0) Write.Line(20, 14, Colour.ABILITY + $"{g.Trait1}" + Colour.RESET);
        if (g.Traits.Count > 1) Write.Line(20, 15, Colour.ABILITY + $"{g.Trait2}" + Colour.RESET);
        if (g.Traits.Count > 2) Write.Line(20, 16, Colour.ABILITY + $"{g.Trait3}" + Colour.RESET);
        Write.Line(50, 6, Colour.ITEM +  "Head Armor      " + Colour.RESET  + $"   {g.Torso.Head.Armor.Name}");
        Write.Line(50, 7, Colour.ITEM +  "Torso Armor     " + Colour.RESET  + $"   {g.Torso.Armor.Name}");
        Write.Line(50, 8, Colour.ITEM +  "Arm Armor       " + Colour.RESET  + $"   {g.Torso.RightArm.Armor.Name}");
        Write.Line(50, 9, Colour.ITEM +  "Hand Armor      " + Colour.RESET  + $"   {g.Torso.RightArm.Hand.Armor.Name}");
        Write.Line(50, 10, Colour.ITEM + "Leg Armor       " + Colour.RESET  + $"   {g.Torso.RightLeg.Armor.Name}");
        Write.Line(50, 11, Colour.ITEM + "Main Hand Weapon" + Colour.RESET  + $"   {g.Torso.RightArm.Hand.Weapon.Name}  ");
        Write.Line(50, 12, Colour.ITEM + "Off Hand Weapon " + Colour.RESET  + $"   {g.Torso.LeftArm.Hand.Weapon.Name} ");
        Write.Line(0, 18, "[1] " + Colour.ITEM + "Upgrade Head Armor      " + Colour.GOLD + $"{armorUpgrade[g.Torso.Head.Armor.Current + 1]}\n" + Colour.RESET);
        Write.Line(       "[2] " + Colour.ITEM + "Upgrade Torso Armor     " + Colour.GOLD + $"{armorUpgrade[g.Torso.Armor.Current + 1]}" + Colour.RESET);
        Write.Line(       "[3] " + Colour.ITEM + "Upgrade Arm Armor       " + Colour.GOLD + $"{armorUpgrade[g.Torso.RightArm.Armor.Current + 1]}" + Colour.RESET);
        Write.Line(       "[4] " + Colour.ITEM + "Upgrade Hand Armor      " + Colour.GOLD + $"{armorUpgrade[g.Torso.RightArm.Hand.Armor.Current + 1]}" + Colour.RESET);
        Write.Line(       "[5] " + Colour.ITEM + "Upgrade Leg Armor       " + Colour.GOLD + $"{armorUpgrade[g.Torso.RightLeg.Armor.Current + 1]}" + Colour.RESET);
        Write.Line(       "[M] " + Colour.ITEM + "Upgrade Main Hand       " + Colour.GOLD + $"{armorUpgrade[g.Torso.RightArm.Hand.Weapon.Current + 1]}" + Colour.RESET);
        Write.Line(       "[O] " + Colour.ITEM + "Upgrade Off Hand        " + Colour.GOLD + $"{armorUpgrade[g.Torso.LeftArm.Hand.Weapon.Current + 1]}" + Colour.RESET);
        Write.Line(       "[0] " + Colour.TIME + "Return to compound      " + Colour.RESET);

        string choice = Return.Option();
        if (choice == "1")
        {
            if (Return.Afford(armorUpgrade[g.Torso.Head.Armor.Current + 1]))
            {
                g.Torso.Head.Armor = HeadArmor[g.Torso.Head.Armor.Current + 1];
                Owner.p.Gold -= armorUpgrade[g.Torso.Head.Armor.Current + 1];
                g.Torso.Head.Armor.Current++;
            }
            else Write.KeyPress();
        }
        else if (choice == "2")
        {
            if (Return.Afford(armorUpgrade[g.Torso.Armor.Current + 1]))
            {
                g.Torso.Armor = TorsoArmor[g.Torso.Armor.Current + 1];
                Owner.p.Gold -= armorUpgrade[g.Torso.Armor.Current + 1];
                g.Torso.Armor.Current++;
            }
            else Write.KeyPress();
        }
        else if (choice == "3")
        {
            if (Return.Afford(armorUpgrade[g.Torso.RightArm.Armor.Current + 1]))
            {
                g.Torso.RightArm.Armor = ArmArmor[g.Torso.RightArm.Armor.Current + 1];
                g.Torso.LeftArm.Armor = ArmArmor[g.Torso.RightArm.Armor.Current + 1];
                Owner.p.Gold -= armorUpgrade[g.Torso.RightArm.Armor.Current + 1];
                g.Torso.RightArm.Armor.Current++;
            }
            else Write.KeyPress();
        }
        else if (choice == "4")
        {
            if (Return.Afford(armorUpgrade[g.Torso.RightArm.Hand.Armor.Current + 1]))
            {
                g.Torso.RightArm.Hand.Armor = HandArmor[g.Torso.RightArm.Hand.Armor.Current + 1];
                g.Torso.LeftArm.Hand.Armor = HandArmor[g.Torso.RightArm.Hand.Armor.Current + 1];
                Owner.p.Gold -= armorUpgrade[g.Torso.RightArm.Hand.Armor.Current + 1];
                g.Torso.RightArm.Hand.Armor.Current++;
            }
            else Write.KeyPress();
        }
        else if (choice == "5")
        {
            if (Return.Afford(armorUpgrade[g.Torso.RightLeg.Armor.Current + 1]))
            {
                g.Torso.RightLeg.Armor = LegArmor[g.Torso.RightLeg.Armor.Current + 1];
                g.Torso.LeftLeg.Armor = LegArmor[g.Torso.RightLeg.Armor.Current + 1];
                Owner.p.Gold -= armorUpgrade[g.Torso.RightLeg.Armor.Current + 1];
                g.Torso.RightLeg.Armor.Current++;
            }
            else Write.KeyPress();
        }
        else if (choice == "m")
        {
            if (Return.Afford(weaponUpgrade[g.Torso.RightArm.Hand.Weapon.Current + 1]))
            {
                g.Torso.RightArm.Hand.Weapon = Weapons[g.Torso.RightArm.Hand.Weapon.Current + 1];
                Owner.p.Gold -= weaponUpgrade[g.Torso.RightArm.Hand.Weapon.Current + 1];
                g.Torso.RightArm.Hand.Weapon.Current++;
            }
            else Write.KeyPress();
        }
        else if (choice == "o")
        {
            if (Return.Afford(weaponUpgrade[g.Torso.LeftArm.Hand.Weapon.Current + 1]))
            {
                g.Torso.LeftArm.Hand.Weapon = Weapons[g.Torso.LeftArm.Hand.Weapon.Current + 1];
                Owner.p.Gold -= weaponUpgrade[g.Torso.LeftArm.Hand.Weapon.Current + 1];
                g.Torso.LeftArm.Hand.Weapon.Current++;
            }
            else Write.KeyPress();
        }
        else if (choice == "0") Location.list[2].Go();
        Equip(g);
    }
}