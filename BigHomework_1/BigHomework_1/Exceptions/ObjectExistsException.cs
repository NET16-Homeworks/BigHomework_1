namespace BigHomework_1.Exceptions
{
    public sealed class ObjectExistsException : Exception
    {
        public ObjectExistsException(string objectName) 
            : base($"{objectName} already exists")
        {

        }
    }
}
