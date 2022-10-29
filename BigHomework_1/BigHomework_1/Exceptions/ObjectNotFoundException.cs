namespace BigHomework_1.Exceptions
{
    public sealed class ObjectNotFoundException : Exception
    {
        public ObjectNotFoundException(string objectName) 
            : base($"{objectName} wasn't founded") 
        {

        }
    }
}
