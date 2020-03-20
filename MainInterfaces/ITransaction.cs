namespace Bank
{
    interface ITransaction<T> where T : class, new () 
    {
        int ExecuteTransaction(T transactionData);
    }
}
