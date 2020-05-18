using System;
using System.Collections.Generic;
using System.Text;
public class Location
{
    public static List<Location> list = new List<Location> { new Hub(), new Slaver(), new Manage(), new Buy(), null, null, null, null, null, null,new Arena()};

    public Location()
    {

    }

    public void Go() { Menu(); }

    public virtual void Menu() { Console.Clear(); }
}