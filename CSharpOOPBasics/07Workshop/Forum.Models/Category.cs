namespace Forum.Models
{
    using System.Collections.Generic;

    public class Category
    {
        private int id;
        private string name;
        private ICollection<int> postIds;

        public Category(int id, string name, IEnumerable<int> postIds)
        {
            this.Id = id;
            this.Name = name;
            this.PostIds = new List<int>(postIds);
        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public ICollection<int> PostIds
        {
            get { return this.postIds; }
            set { this.postIds = value; }
        }
    }
}
