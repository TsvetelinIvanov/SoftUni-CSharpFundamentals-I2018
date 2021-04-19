using System;
using _04BarracksFactory.Contracts;

namespace _04BarracksFactory.Core.Commands
{
    public class RetireCommand : Command
    {
        public RetireCommand(string[] data, IRepository repository, IUnitFactory unitFactory) : base(data, repository, unitFactory)
        {

        }

        public override string Execute()
        {
            string unitType = this.Data[1];
            try
            {
                this.Repository.RemoveUnit(unitType);

                return $"{unitType} retired!";
            }
            catch (Exception e)
            {
                throw new ArgumentException("No such units in repository.", e);
            }
        }
    }
}