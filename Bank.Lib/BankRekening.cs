using System;

namespace Bank.Lib
{
    public class BankRekening
    {
        public decimal Balance { get; private set; }

        public BankRekening()
        {
            Balance = 500;
        }

        public BankRekening(decimal beginningBalance)
        {
            Balance = beginningBalance;
        }

        public decimal AddMoneyToBankAccount(decimal money)
        {
            Balance += money;
            return Balance;
        }

        public decimal TakeMoneyFromBankAccount(decimal money)
        {
            //int getal;
            //string letter = "a";
            //getal = int.Parse(letter);

            if (money < 0)
            {
                throw new ArgumentOutOfRangeException("Het bedrag kan niet kleiner zijn dan 0");
            }

            if (money > Balance)
            {
                throw new ArgumentOutOfRangeException("Het bedrag kan niet groeter zijn dan de balans");
            }

            Balance -= money;
            return Balance;
        }
    }
}
