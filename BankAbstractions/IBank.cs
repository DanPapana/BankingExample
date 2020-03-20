namespace Bank
{
    interface IBank : ITransaction<BankInfo>
    {
        bool checkIBAN(string IBAN);
    }
}
