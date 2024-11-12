public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs eventArgs);

public class Dispatcher
{
    private string name;
    public event NameChangeEventHandler NameChangeHandler;

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
