namespace Practise;

public class MultiCurrencyWallet //has 4 different currency balances
{
    private readonly float _size;
    private const float DefaultSize = 1000000f; //amount of money in AMD
    private float _balance;
    public float BalanceAMD { get; private set; }
    public float BalanceRUR { get; private set; }
    public float BalanceUSD { get; private set; }
    public float BalanceEUR { get; private set; }

    public MultiCurrencyWallet(float size = DefaultSize)
    {
        if (size <= 0)
        {
            _size = DefaultSize;
            return;
        }

        _size = size;
    }

    public void AddMoney(float money, Currency currency = Currency.AMD)
    {
        if (money <= 0)
        {
            throw new InvalidAmountException();
        }
        if (_balance + currency.ExchangeToAMD(money) > _size)
        {
            throw new BalanceOutOfSizeException("Size is not enough to add such amount");
        }
        switch (currency)
        { 
            case Currency.AMD:
                BalanceAMD += money;
                _balance += money;
                break;
            case Currency.RUR:
                BalanceRUR += money;
                _balance += Currency.RUR.ExchangeToAMD(money);
                break;
            case Currency.USD:
                BalanceUSD += money;
                _balance += Currency.USD.ExchangeToAMD(money);
                break;
            case Currency.EUR:
                BalanceEUR += money;
                _balance += Currency.EUR.ExchangeToAMD(money);
                break;
        }
    }
    
    public void DecreaseBalance(float money, Currency currency = Currency.AMD)
    {
        if (money <= 0)
        {
            throw new InvalidAmountException();
        }
        if (_balance + currency.ExchangeToAMD(money) > _size)
        {
            throw new NotEnoughMoneyException("Not enough money");
        }
        switch (currency)
        { 
            case Currency.AMD:
                BalanceAMD -= money;
                _balance -= money;
                break;
            case Currency.RUR:
                BalanceRUR -= money;
                _balance -= Currency.RUR.ExchangeToAMD(money);
                break;
            case Currency.USD:
                BalanceUSD -= money;
                _balance -= Currency.USD.ExchangeToAMD(money);
                break;
            case Currency.EUR:
                BalanceRUR -= money;
                _balance -= Currency.EUR.ExchangeToAMD(money);
                break;
        }
    }
}