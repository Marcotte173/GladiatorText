using System;
using System.Collections.Generic;
using System.Text;

public class Equipment
{
    protected string name;
    protected int price;
    protected int tier;
    protected int level;
    protected int current;
    
    public Equipment(int level, int tier)
    {
        this.level = level;
        this.tier = tier;
        price = (level == 0) ? 0 : (level == 1) ? 1000 : (level == 2) ? 3000 : 5000;
        current = 0;
    }
    
    public string Name { get { return name; } set { name = value; } }
    public int Level { get { return level; } set { level = value; } }
    public int Current { get { return current; } set { current = value; } }
    public int Tier { get { return tier; } set { tier = value; } }
    public int Price { get { return price; } set { price = value; } }
}