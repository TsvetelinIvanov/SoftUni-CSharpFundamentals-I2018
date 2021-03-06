using System.Collections.Generic;

namespace _05IntegrationTest
{
    public class User : IUser
    {
        private string name;
        private HashSet<ICategory> categories;

        public User(string name)
        {
            this.name = name;
            this.categories = new HashSet<ICategory>();
        }

        public string Name
        {
            get { return this.name; }
        }

        public IEnumerable<ICategory> Categories
        {
            get { return this.categories as IReadOnlyCollection<ICategory>; }
        }

        public void AddCategory(ICategory category) => this.categories.Add(category);

        public void RemoveCategory(ICategory category)
        {
            //this.categories.RemoveWhere(c => c.Name == category.Name);
            this.categories.Remove(category);
            if (category.Parent != null)
            {
                this.categories.Add(category.Parent);
            }
        }
    }
}