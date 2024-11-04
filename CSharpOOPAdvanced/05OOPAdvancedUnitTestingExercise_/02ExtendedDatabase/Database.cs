using System;
using System.Collections.Generic;
using System.Linq;

namespace _02ExtendedDatabase
{
    public class Database
    {
        private HashSet<IPerson> people;

        public Database()
        {
            this.people = new HashSet<IPerson>();
        }

        public Database(IEnumerable<IPerson> people) : this()
        {
            if (people != null)
            {
                foreach (IPerson person in people)
                {
                    this.Add(person);
                }
            }
        }

        public int Count => this.people.Count;

        public void Add(IPerson person)
        {
            if (this.people.Any(p => p.Id == person.Id || p.Username == person.Username))
            {
                throw new InvalidOperationException("This person already exists in the database!");
            }

            this.people.Add(person);
        }

        public void Remove(IPerson person)
        {
            this.people.RemoveWhere(p => p.Id == person.Id && p.Username == person.Username);
        }

        public IPerson FindByUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException();
            }

            IPerson person = people.FirstOrDefault(p => p.Username == username);
            if (person == null)
            {
                throw new InvalidOperationException($"There is no user with this username: {username}!");
            }

            return person;
        }

        public IPerson FindById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Id can not be negative!");
            }

            IPerson person = people.FirstOrDefault(p => p.Id == id);
            if (person == null)
            {
                throw new InvalidOperationException($"There is no user with this id: {id}!");
            }

            return person;
        }
    }
}
