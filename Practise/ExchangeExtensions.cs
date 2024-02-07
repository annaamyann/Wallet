namespace Practise;

public static class ExchangeExtensions
{
    private static Dictionary<Currency, float> _currency = new Dictionary<Currency, float>()
    {
        {Currency.AMD, 1}, {Currency.USD, 406.07f}, {Currency.RUR, 4.46f}, {Currency.EUR, 437.35f}
    };
    
    public static float ExchangeToAMD(this Currency currency, float money)
    {
        return money *= _currency[currency];
    }

    public static float Exchange(this float money, Currency from, Currency to)
    {
        return (money * _currency[from]) / _currency[to];
    }
}