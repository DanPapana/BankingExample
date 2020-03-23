namespace Bank
{
    interface IBank : ITransaction<BankInfo>
    {
        //BankInfo MatchIBAN(string IBAN);
    }
}
