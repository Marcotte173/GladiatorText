using System;
using System.Collections.Generic;
using System.Text;

public class Write
{
    internal static void Line(int x, int y, string words) { Console.SetCursorPosition(x, y); Console.Write(words); }
    internal static void Line(string words) { Console.WriteLine(words); }
    internal static void Character(int x, int y, string word1, string word2)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(word1);
        Console.SetCursorPosition(x + 25, y);
        Console.Write(word2);
    }
    internal static void Character(int x, int y, string word1,string word2, string word3) 
    { 
        Console.SetCursorPosition(x, y);  
        Console.Write(word1); 
        Console.SetCursorPosition(x + 12, y); 
        Console.Write(word2); 
        Console.SetCursorPosition(x + 25, y); 
        Console.Write(word3); 
    }
    internal static void Character(int x, int y, string word1, string word2, string word3, string word4)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(word1);
        Console.SetCursorPosition(x + 15, y);
        Console.Write(word2);
        Console.SetCursorPosition(x + 30, y);
        Console.Write(word3);
        Console.SetCursorPosition(x + 45, y);
        Console.Write(word4);
    }
    internal static void Line(int x, int y, string word1, string word2, string word3, string word4, string word5, string word6, string word7)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(word1);
        Console.SetCursorPosition(x, y);
        Console.Write(word2);
        Console.SetCursorPosition(x + 15, y);
        Console.Write(word3);
        Console.SetCursorPosition(x + 30, y);
        Console.Write(word4);
        Console.SetCursorPosition(x + 45, y);
        Console.Write(word5);
        Console.SetCursorPosition(x + 60, y);
        Console.Write(word6);
        Console.SetCursorPosition(x + 75, y);
        Console.Write(word7);
    }
    internal static void KeyPress()
    {
        Write.Line("Press any key to continue");
        Console.ReadKey(true);
    }
    internal static bool Confirm(int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.WriteLine(Colour.RESET + "\n[1]Yes\n[2]No");
        string confirm = Console.ReadKey(true).KeyChar.ToString().ToLower();
        return (confirm == "1") ? true : false;
    }
}