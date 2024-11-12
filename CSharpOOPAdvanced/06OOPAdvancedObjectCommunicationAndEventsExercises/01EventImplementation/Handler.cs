using System;

public class Handler
{
    public void OnDispatcherNameChange(object sender, NameChangeEventArgs eventArgs)
    {
        Console.WriteLine($"Dispatcher's name changed to {args.Name}.");
    }
}
