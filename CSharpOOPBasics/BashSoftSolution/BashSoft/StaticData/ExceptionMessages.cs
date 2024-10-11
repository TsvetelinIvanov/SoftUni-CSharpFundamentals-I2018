namespace BashSoft
{
    public static class ExceptionMessages
    {
        public const string ExampleExceptionMessage = "Example message!";

        public const string DataAlreadyInitializedExceptionMessage = "Data is already initialized!";

        public const string DataNotInitializedExceptionMessage = "The data structure must be initialized first in order to make any operation with it.";

        public const string InexistantCourseInDataBase = "The course you are trying to get does not exist in the data base!";

        public const string InexistantStudentInDatabase = "The user name for the student you are trying to get does not exist!";

        public const string InvalidPath = "The folder/file you are trying to access at the current address, does not exist.";

        public const string UnauthorizedAccessExceptionMessage = "The folder/file you are trying to get access needs a higher level of rights than you currently have.";

        public const string ComparisonOfFilesWithDifferentSizes = "Files not of equal size, certain mismatch.";

        public const string ForbiddenSymbolsContainedInName = "The given name contains symbols that are not allowed to be used in names of files and folders.";

        public const string UnableToGoHigherInPartitionHierarchy = "The program is unable to go higher in partition hierarchy!";

        public const string UnableToParseNumberExceptionMessage = "The sequence ypu've written is not a valid number.";

        public const string InvalidStudentFilterExceptionMessage = "The given filter is not one of the following: excellent/average/poor!";

        public const string InvalidComparisonQueryExceptionMessage = "The comparison query you want, does not exist in the context of the current program!";

        public const string InvalidTakeQantityParameterExceptionMessage = "The take command expected does not match the format wanted!";
    }
}
