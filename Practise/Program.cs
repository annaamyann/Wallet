namespace Practise;

class Program
{
    static void Main()
    {
        float size = 2000000f;
        Wallet wallet1 = new Wallet(size, Currency.AMD);
        try
        {
            wallet1.AddMoney(3000000f, Currency.AMD);
            Console.WriteLine("added to wallet1");
        }
        catch (BalanceOutOfSizeException)
        {
            Console.WriteLine("not added");
        }

        try
        {
            wallet1.AddMoney(5f, Currency.USD);
            Console.WriteLine("added to wallet1");
        }
        catch (BalanceOutOfSizeException)
        {
            Console.WriteLine("not added");
        }
        
        Console.WriteLine("wallet1 balance is " + wallet1.Balance);
        Wallet wallet2 = new Wallet();
        wallet2.AddMoney(1000000f, Currency.AMD);
        Wallet sum = new Wallet();
        try
        {
            sum = wallet1 + wallet2;
            Console.WriteLine("added to sum");
        }
        catch (BalanceOutOfSizeException)
        {
            Console.WriteLine("not added");
        }
        
        wallet2.DecreaseBalance(7000f);
        try
        {
            sum = wallet1 + wallet2;
            Console.WriteLine("decreased from wallet2");
        }
        catch (BalanceOutOfSizeException)
        {
            Console.WriteLine("not added");

        }
        Console.WriteLine("Sum Wallet Balance is " + sum.Balance);

        MultiCurrencyWallet multiWallet = new MultiCurrencyWallet();
        multiWallet.AddMoney(5000);
        multiWallet.AddMoney(60, Currency.USD);
        multiWallet.AddMoney(7000, Currency.RUR);
        multiWallet.AddMoney(500,Currency.EUR);
        
        Console.WriteLine(multiWallet.BalanceAMD + " AMD");
        Console.WriteLine(multiWallet.BalanceUSD + " USD");
        Console.WriteLine(multiWallet.BalanceRUR + " RUR");
        Console.WriteLine(multiWallet.BalanceEUR + " EUR");
        
        Console.WriteLine(100f.Exchange(Currency.RUR, Currency.USD));

        Wallet walletUSD = new Wallet(100000f, Currency.USD);
        try
        {
            walletUSD.AddMoney(3000000f, Currency.AMD);
            Console.WriteLine("AMD added to wallet");
        }
        catch (BalanceOutOfSizeException)
        {
            Console.WriteLine("AMD not added to wallet");
        }
        Console.WriteLine("walletUSD balance " + walletUSD.Balance);
    }
}