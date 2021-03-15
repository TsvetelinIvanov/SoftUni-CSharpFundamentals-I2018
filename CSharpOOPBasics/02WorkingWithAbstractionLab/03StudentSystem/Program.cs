using System;

class Program
{
    static void Main(string[] args)
    {
        StudentSystem studentSystem = new StudentSystem();
        string command;
        while ((command = Console.ReadLine()) != "Exit")
        {
            studentSystem.ParseCommand(command);
        }
    }
}