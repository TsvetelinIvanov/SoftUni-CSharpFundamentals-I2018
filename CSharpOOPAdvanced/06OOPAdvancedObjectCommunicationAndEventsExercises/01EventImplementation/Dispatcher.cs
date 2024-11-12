public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs eventArgs);

public class Dispatcher
{
    public event NameChangeEventHandler NameChangeHandler;

    private string name;
    
    public string Name
    {
        get => this.name;
        set
        {
            this.name = value;
            OnNameChange(new NameChangeEventArgs(value));
        }
    }

    public void OnNameChange(NameChangeEventArgs nameChangeEventArgs)
    {
        NameChangeHandler?.Invoke(this, nameChangeEventArgs);
    }
}
