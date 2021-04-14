using System.Collections.Generic;

namespace MyTunesShop
{
    public class Band : Performer, IBand
    {
        public Band(string name) : base(name)
        {
            this.Members = new List<string>();
        }

        public IList<string> Members { get; private set; }

        public override PerformerType Type => PerformerType.Band;

        public void AddMember(string memberName)
        {
            this.Members.Add(memberName);
        }
    }
}