using System;

namespace BashSoft.Exceptions
{
    public class DuplicateEntryInStructureException : Exception
    {
        private const string DuplicateEntryExcepionMessage = "The {0} already exists in {1}!";        

        public DuplicateEntryInStructureException(string entry, string structure) : base(string.Format(DuplicateEntryExcepionMessage, entry, structure))
        {

        }

        public DuplicateEntryInStructureException(string message) : base(message)
        {

        }
    }
}
