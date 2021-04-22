using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace _05IntegrationTest
{
    public class Category : ICategory
    {
        private string name;
        private ICategory parent;
        private IList<IUser> users;
        private IList<ICategory> childCategories;

        public Category(string name)
        {
            this.Name = name;
            this.Users = new List<IUser>();
            this.childCategories = new List<ICategory>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value == string.Empty)
                {
                    throw new ArgumentException("Cannot create category without a name!");
                }

                this.name = value;
            }
        }

        public ICategory Parent
        {
            get { return this.parent; }
            private set { this.parent = value; }
        }

        public IList<IUser> Users
        {
            get { return new ReadOnlyCollection<IUser>(this.users); }
            private set { this.users = value; }
        }

        public IList<ICategory> ChildCategories
        {
            get { return new ReadOnlyCollection<ICategory>(this.childCategories); }
        }

        public void MoveUsersToParent()
        {
            if (this.Parent == null)
            {
                return;
            }

            foreach (var user in this.Users)
            {
                this.parent.AddUser(user);
            }
        }

        public void AddChild(ICategory child)
        {
            this.childCategories.Add(child);
            child.SetParent(this);
        }

        public void AddUser(IUser user)
        {
            this.users.Add(user);
            user.AddCategory(this);
        }

        public void RemoveChild(string name)
        {
            ICategory categoryChildToRemove = this.childCategories.FirstOrDefault(c => c.Name == name);
            this.childCategories?.Remove(categoryChildToRemove);
        }

        public void SetParent(ICategory category)
        {
            this.Parent = category;
        }
    }
}