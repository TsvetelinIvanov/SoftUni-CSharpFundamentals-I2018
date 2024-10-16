namespace MyTunesShop
{    
    public class Singer : Performer
    {
        public Singer(string name) : base(name)
        {
        
        }

        public override PerformerType Type => PerformerType.Singer;        
    }
}
