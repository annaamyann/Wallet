namespace Practise;

public class Wallet //just for 1 currency
{
    private const float DefaultSize = 1000000f;
    private readonly float _size;
    private readonly Currency _currency;
    
    public float Balance { get; private set; }

    public Wallet(float size = DefaultSize, Currency currency = Currency.AMD)
    {
        _currency = currency;
        if (size < 0)
        {
            _size = DefaultSize;
            return;
        }
        _size = size;
    }

    public void AddMoney(float money, Currency currency)
    {
        if (money <= 0)
        {
            throw new InvalidAmountException();
        }
        if (Balance + money.Exchange(currency, _currency) > _size)
        {
            throw new BalanceOutOfSizeException("The size is not enough");
        }

        money = money.Exchange(currency, _currency);
        Balance += money;
    }

    public void DecreaseBalance(float money)
    {
        if (money <= 0)
        {
            throw new InvalidAmountException();
        }
        if (Balance - money < 0)
        {
            throw new NotEnoughMoneyException("Not enough money");
        }
        Balance -= money;
    }

    public static Wallet operator +(Wallet left, Wallet right)
    {
        float maxSize = left._size > right._size ? left._size : right._size;
        Wallet newWallet = new Wallet(maxSize);
        newWallet.AddMoney(left.Balance + right.Balance, Currency.AMD);
        return newWallet;
    }
}