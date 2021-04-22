namespace BashSoft.Executor.Contracts
{
    public interface IDatabase : IRequester, IFilteredTaker, IOrderedTaker
    {
        void UnloadData();

        void LoadData(string fileName);        
    }
}