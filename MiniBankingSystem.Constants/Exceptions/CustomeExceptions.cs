namespace MiniBankingSystem.Constants.Exceptions
{
    public class CustomeExceptions
    {
    }

    public class NotFoundException : Exception
    {
        public NotFoundException() : base() { }
        public NotFoundException(string message) : base(message) { }
        public NotFoundException(string message, NotFoundException innerException) : base(message, innerException) { }
    }

    public class DBModifyException : Exception
    {
        public DBModifyException() : base() { }
        public DBModifyException(string message) : base(message) { }
        public DBModifyException(string message, DBModifyException innerException) : base(message, innerException) { }
    }

    public class InvalidAccountException : Exception
    {
        public InvalidAccountException() : base() { }
        public InvalidAccountException(string message) : base(message) { }
        public InvalidAccountException(string message, InvalidAccountException innerException) : base(message, innerException) { }
    }

    public class InvalidBankActionAmountException : Exception
    {
        public InvalidBankActionAmountException() : base() { }
        public InvalidBankActionAmountException(string message) : base(message) { }
        public InvalidBankActionAmountException(string message, InvalidBankActionAmountException innerException) : base(message, innerException) { }
    }

}
