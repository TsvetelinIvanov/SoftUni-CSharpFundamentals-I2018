﻿namespace _05BarracksFactory.Contracts
{
    public interface IRepository
    {
        string Statistics { get; }
        
        void AddUnit(IUnit unit);
        
        void RemoveUnit(string unitType);
    }
}
