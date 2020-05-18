using System;

namespace Gladiator_Manager
{
    class Program
    {
        public static Owner p = new Owner();        
        static void Main(string[] args)
        {            
            Colour.SetupConsole();
            string[] names = System.IO.File.ReadAllLines(Environment.CurrentDirectory + "/Names.txt");
            for (int i = 0; i < names.Length; i++) { Gladiator.list.Add(names[i]); }
            for (int i = 0; i < 9; i++)
            {
                Owner.list.Add(new ComputerOwner(Return.RandomInt(2, 5), 6, Return.RandomInt(50, 300), Return.RandomInt(-10, 90)));
            }
            Write.Line(Colour.RESET);            
            Slaver.NewStock();
            Story();
        }

        private static void Story()
        {
            Console.Clear();
            Write.Line("Flavor Coming");
            Write.KeyPress();
            Name();
        }

        private static void Name()
        {
            Console.Clear();
            Write.Line("What is your name?\n");
            string choice = Console.ReadLine();
            Console.Clear();
            Write.Line(choice + " is your name?");
            if(Write.Confirm(0,2))
            {
                p.Name = choice;
                Location.list[0].Go();
            }
            else Name();
        }
    }
}
