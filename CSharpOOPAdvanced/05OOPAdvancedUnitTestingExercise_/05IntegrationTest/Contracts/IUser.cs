using System.Collections.Generic;

namespace _05IntegrationTest
{
    public interface IUser
    {
        string Name { get; }

        IEnumerable<ICategory> Categories { get; }

        void AddCategory(ICategory category);

        void RemoveCategory(ICategory category);
    }
}