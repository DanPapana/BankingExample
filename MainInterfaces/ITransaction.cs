namespace Bank
{
    interface ITransaction<T> where T : class, new () 
    {
        T ExecuteTransaction(T transactionData, decimal sendAmount);
        T MatchIBAN(string IBAN);
        decimal GetBalance();
    }
}
