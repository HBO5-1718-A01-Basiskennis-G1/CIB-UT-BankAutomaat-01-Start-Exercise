using System;
using Bank.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankAutomaat.Tests
{
    [TestClass]
    public class BankRekeningTest
    {


        [TestMethod]
        public void TakeMoneyFromBankAccount_WithValueMoney_UpdatesBalance()
        {
            //Wanneer er geld afgehaald wordt moet de balans aangepast worden
            //Gooi een exception als het gevraagde bedrag hoger is dan het geld op rekening
            //gevraagde bedrag is negatief, ook exception gooien

            // Arrange
            decimal beginningBalance = 500.95M;
            decimal moneyToTakeFromBankAccount = 100.10M;
            decimal expected = 400.85M;
            BankRekening bankRekening = new BankRekening(beginningBalance);

            // Act
            bankRekening.TakeMoneyFromBankAccount(moneyToTakeFromBankAccount);

            // Assert
            decimal actual = bankRekening.Balance;
            Assert.AreEqual(expected, actual, "Balance is incorrect");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TakeMoneyFromBankAccount_WhenMoneyIsLessThanZero_ShuldThrowArgumentOutOfRange()
        {
            // Arrange
            decimal beginningBalance = 12.0M;
            decimal moneyToTakeFromBankAccount = -20.10M;
            BankRekening bankRekening = new BankRekening(beginningBalance);

            // Act
            bankRekening.TakeMoneyFromBankAccount(moneyToTakeFromBankAccount);

            // Assert
            // is handled by ExpectedException attribute
        }

        [TestMethod]
        public void TakeMoneyFromBankAccount_WhenMoneyIsMoreThanBalance_ShuldThrowArgumentOutOfRange()
        {
            // Arrange
            decimal beginningBalance = 12.0M;
            decimal moneyToTakeFromBankAccount = 20.10M;
            BankRekening bankRekening = new BankRekening(beginningBalance);

            try
            {
                // Act
                bankRekening.TakeMoneyFromBankAccount(moneyToTakeFromBankAccount);

            }
            catch (ArgumentOutOfRangeException ex)
            {
                //Assert
                return;
            }

            Assert.Fail("No exception was thrown");
        }
    }
}
