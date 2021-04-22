using System.Collections.Generic;
using System.Linq;

namespace _05IntegrationTest
{
    public class CategoryController
    {
        private HashSet<ICategory> categories;

        public CategoryController()
        {
            this.categories = new HashSet<ICategory>();
        }

        public CategoryController(IEnumerable<string> names) : this()
        {
            foreach (string name in names)
            {
                this.AddCategory(name);
            }
        }

        public void AddCategory(string name)
        {
            if (this.categories.Any(c => c.Name == name || c.ChildCategories.Any(cc => cc.Name == name)))
            {
                return;
            }

            this.categories.Add(new Category(name));
        }

        public void AddCategory(IEnumerable<string> names)
        {
            foreach (string name in names)
            {
                this.AddCategory(name);
            }
        }

        public void RemoveCategory(string name)
        {
            ICategory categoryToRemove = this.categories.FirstOrDefault(c => c.Name == name);
            if (categoryToRemove == null)
            {
                foreach (ICategory category in this.categories)
                {
                    if ((categoryToRemove = category.ChildCategories.FirstOrDefault(c => c.Name == name)) != null)
                    {
                        break;
                    }
                }
            }

            if (categoryToRemove == null)
            {
                return;
            }

            categoryToRemove.MoveUsersToParent();
            this.RemoveCategoryFromUsersList(categoryToRemove);
            this.MoveChildrenCategoriesToParent(categoryToRemove);

            if (categoryToRemove.Parent == null)
            {
                this.categories.Remove(categoryToRemove);
            }
            else
            {
                categoryToRemove.Parent.RemoveChild(categoryToRemove.Name);
            }
        }

        private void RemoveCategoryFromUsersList(ICategory categoryToRemove)
        {
            foreach (IUser user in categoryToRemove.Users)
            {
                user.RemoveCategory(categoryToRemove);
            }
        }

        private void MoveChildrenCategoriesToParent(ICategory categoryToRemove)
        {
            if (categoryToRemove.Parent == null)
            {
                foreach (ICategory category in categoryToRemove.ChildCategories)
                {
                    this.categories.Add(category);
                }

                return;
            }

            foreach (ICategory child in categoryToRemove.ChildCategories)
            {
                categoryToRemove.Parent.AddChild(child);
            }
        }

        public void RemoveCategory(IEnumerable<string> categoryNames)
        {
            foreach (string categoryName in categoryNames)
            {
                this.RemoveCategory(categoryName);
            }
        }

        public void AddChild(ICategory parent, string childName)
        {
            parent.AddChild(new Category(childName));
        }

        public void AddUser(ICategory category, IUser user) => category.AddUser(user);
    }
}