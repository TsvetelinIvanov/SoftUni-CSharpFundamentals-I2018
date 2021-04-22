using _05IntegrationTest;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace _05IntegrationTestTests
{
    [TestFixture]
    public class CategoryCntrollerTests
    {
        private CategoryController categoryController;
        private HashSet<ICategory> categories;

        [SetUp]
        public void TestInitialization()
        {
            this.categoryController = new CategoryController();
            this.categories = (HashSet<ICategory>)this.categoryController.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(f => f.Name == "categories")
                .GetValue(this.categoryController);
        }

        [Test]
        public void AddCategorySaveCategory()
        {
            string categoryName = "Category Name";

            this.categoryController.AddCategory(categoryName);

            Assert.That(this.categories.Count, Is.EqualTo(1));
            //Assert.AreEqual(1, this.categories.Count);
        }

        [Test]
        [TestCase(8)]
        [TestCase(18)]
        [TestCase(38)]
        public void AddCategorySaveCategories(int categoriesCount)
        {
            string categoryName = "Category Name No ";

            for (int i = 0; i < categoriesCount; i++)
            {
                this.categoryController.AddCategory($"{categoryName} {i}");
            }

            Assert.That(this.categories.Count, Is.EqualTo(categoriesCount));
            //Assert.AreEqual(categoriesCount, this.categories.Count);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("      ")]
        [TestCase("   \r\n")]
        [TestCase("\t")]
        [TestCase("\r")]
        [TestCase("\n")]
        [TestCase("\r\n")]
        [TestCase("\n\r")]
        [TestCase(" \n \r \t \n\r \r\n")]
        public void AddCategoryThrowsExceptionWitoutName(string name)
        {
            Assert.That(() => this.categoryController.AddCategory(name), Throws.ArgumentException.With.Message.EqualTo("Cannot create category without a name!"));
            //Assert.Throws<ArgumentException>(() => this.categoryControler.AddCategory(name));
        }

        [Test]
        public void AddChildAssignsAChildcategoryToTheParent()
        {
            string parentName = "Parent";
            this.categoryController.AddCategory(parentName);
            ICategory parentCategory = this.categories.First(c => c.Name == parentName);

            this.categoryController.AddChild(parentCategory, "Child");

            Assert.That(parentCategory.ChildCategories.Count, Is.EqualTo(1));
            //Assert.AreEqual(1, parentCategory.ChildCategories.Count);
        }

        [Test]
        public void AddUserAssignsUserToASpecificCategory()
        {
            string categoryName = "Category Name";
            this.categoryController.AddCategory(categoryName);
            ICategory addedcategory = this.categories.First(c => c.Name == categoryName);

            this.categoryController.AddUser(addedcategory, new User("User"));

            Assert.That(addedcategory.Users.Count, Is.EqualTo(1));
            //Assert.AreEqual(1, addedcategory.Users.Count);
        }

        [Test]
        public void AddUserAssignsTheCategoryToItsUserListOfCategories()
        {
            string categoryName = "Category";
            this.categoryController.AddCategory(categoryName);
            string userName = "User";
            User user = new User(userName);

            this.categoryController.AddUser(this.categories.First(), user);

            Assert.That(user.Categories.First().Name, Is.EqualTo(categoryName));
            //Assert.AreEqual(categoryName, user.Categories.First().Name);
        }

        [Test]
        public void RemoveCategoryByNameWorks()
        {
            for (int i = 0; i < 10; i++)
            {
                this.categoryController.AddCategory($"Category - {i}");
            }

            categoryController.RemoveCategory("Category - 0");

            Assert.That(this.categories.Count, Is.EqualTo(9));
            //Assert.AreEqual(9, this.categories.Count);
        }

        [Test]
        [TestCase(7)]
        [TestCase(16)]
        [TestCase(21)]
        public void RemoveCategoryWithCollectionWorks(int numberOfDeletions)
        {
            for (int i = 0; i < numberOfDeletions + 5; i++)
            {
                this.categoryController.AddCategory($"Category - {i}");
            }

            string[] deletionNames = new string[numberOfDeletions];
            for (int i = 0; i < deletionNames.Length; i++)
            {
                deletionNames[i] = $"Category - {i}";
            }

            categoryController.RemoveCategory(deletionNames);

            Assert.That(this.categories.Count, Is.EqualTo(5));
            //Assert.AreEqual(5, this.categories.Count);
        }

        [Test]
        public void RemoveCategoryRemovesItEvenWhenIsAChildToAnotherOne()
        {
            string parentName = "Parent";
            string childName = "Child";
            this.categoryController.AddCategory(parentName);
            ICategory parent = this.categories.First(c => c.Name == parentName);
            this.categoryController.AddChild(parent, childName);

            this.categoryController.RemoveCategory(childName);

            Assert.That(this.categories.First().ChildCategories.Count, Is.EqualTo(0));
            //Assert.AreEqual(0, this.categories.First().ChildCategories.Count);
        }

        [Test]
        public void RemoveCategoryMovesChildCategoriesToItsParentOne()
        {
            string firstCategoryName = "First";
            string secondCategoryName = "First's child";
            string thirdCategoryName = "Second's child and First's sub-child";
            this.categoryController.AddCategory(firstCategoryName);
            ICategory grandParent = this.categories.First();
            this.categoryController.AddChild(grandParent, secondCategoryName);
            this.categoryController.AddChild(grandParent.ChildCategories.First(), thirdCategoryName);

            this.categoryController.RemoveCategory(secondCategoryName);

            Assert.That(this.categories.First().ChildCategories.Count, Is.EqualTo(1));
            Assert.That(this.categories.First().ChildCategories.First().Name, Is.EqualTo(thirdCategoryName));
            //Assert.AreEqual(1, this.categories.First().ChildCategories.Count);
            //Assert.AreEqual(thirdCategoryName, this.categories.First().ChildCategories.First().Name);
        }

        [Test]
        public void RemoveCategoryAssignsAllOfItsUsersToItsParent()
        {
            string parentCategoryName = "Parent Category";
            string childCategoryName = "Child Category";
            this.categoryController.AddCategory(parentCategoryName);
            this.categoryController.AddChild(this.categories.First(), childCategoryName);
            string userName = "User's name";
            ICategory childCategory = this.categories.First().ChildCategories.First();
            this.categoryController.AddUser(childCategory, new User(userName));

            this.categoryController.RemoveCategory(childCategoryName);

            Assert.That(this.categories.First().ChildCategories.Count, Is.EqualTo(0));
            //Assert.AreEqual(0, this.categories.First().ChildCategories.Count);
        }

        [Test]
        public void RemoveCategoryChangesItsUsersCorespondingRelationWithTheParentCategory()
        {
            string parentCategoryName = "Parent Category";
            string childCategoryName = "Child Category";
            this.categoryController.AddCategory(parentCategoryName);
            this.categoryController.AddChild(this.categories.First(), childCategoryName);
            string userName = "User's name";
            ICategory childCategory = this.categories.First().ChildCategories.First();
            this.categoryController.AddUser(childCategory, new User(userName));

            this.categoryController.RemoveCategory(childCategoryName);

            Assert.That(this.categories.First().Users.First().Categories.First().Name, Is.EqualTo(this.categories.First().Name));
            //Assert.AreEqual(this.categories.First().Name, this.categories.First().Users.First().Categories.First().Name);
        }

        [Test]
        public void RemoveCategoryRemovesItselfFromItsUsersLists()
        {
            string categoryName = "Category";
            this.categoryController.AddCategory(categoryName);
            ICategory category = this.categories.First();
            User user = new User("User");
            this.categoryController.AddUser(category, user);

            this.categoryController.RemoveCategory(categoryName);

            Assert.That(user.Categories.Count(), Is.EqualTo(0));
            //Assert.AreEqual(0, user.Categories.Count());
        }
    }
}