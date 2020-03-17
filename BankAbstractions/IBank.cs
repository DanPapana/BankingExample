namespace Bank
{
    interface IBank : ITransaction, ITransactionUI
    {
        void ExecuteTransaction(IBank bankName);

    }
}
