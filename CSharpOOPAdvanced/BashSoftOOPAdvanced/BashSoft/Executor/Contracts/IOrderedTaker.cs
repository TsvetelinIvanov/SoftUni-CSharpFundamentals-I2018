namespace BashSoft.Executor.Contracts
{
    public interface IOrderedTaker
    {
        void OrderAndTake(string courseName, string comparision, int? studentsToTake = null);
    }
}