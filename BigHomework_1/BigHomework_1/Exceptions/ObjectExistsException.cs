namespace BigHomework_1.Exceptions
{
    internal class ObjectExistsException : Exception
    {
        public ObjectExistsException(string? objectName) : base($"{objectName} already exists")
        {
        }
    }
}
