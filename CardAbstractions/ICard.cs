namespace Bank
{
    interface ICard : ITransaction<CardInfo>
    {
        bool CheckPin(int pin);
    }
}