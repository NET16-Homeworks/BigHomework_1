namespace BigHomework_1.Exceptions
{
    internal class ObjectNotFoundException : Exception
    {
        public ObjectNotFoundException(string? objectName) : base($"{objectName} wasn’t found")
        {
        }
    }
}
