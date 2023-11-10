namespace TMS_API_Test1.MyException
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name)
            : base($"Entity \"{name}\" not found.") { }
    }
}
