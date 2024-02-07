namespace Practise;

public class BalanceOutOfSizeException : Exception
{
    private string _message;

    public BalanceOutOfSizeException()
    {
        _message = "BalanceOutOfSizeException";
    }
    
    public BalanceOutOfSizeException(string message)
    {
        _message = message;
    }
}

public class NotEnoughMoneyException : Exception
{
    private string _message;

    public NotEnoughMoneyException()
    {
        _message = "BalanceOutOfSizeException";
    }
    
    public NotEnoughMoneyException(string message)
    {
        _message = message;
    }
}

public class InvalidAmountException : Exception
{
    private string _message;

    public InvalidAmountException()
    {
        _message = "InvalidAmountException";
    }
    
    public InvalidAmountException(string message)
    {
        _message = message;
    }
}