namespace StarSharksTool.Exceptions
{
    internal class BusinessException : ApplicationException
    {

        public BusinessException() { }

        public BusinessException(string message) : base(message)
        {

        }
    }
}
