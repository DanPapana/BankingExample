namespace Bank
{
    interface ICard : ITransaction, ITransactionUI
    {
        void CheckPin();
    }
}