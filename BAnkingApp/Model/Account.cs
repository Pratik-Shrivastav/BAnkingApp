using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAnkingApp
{
    public class Account
    {

        public int accountId;
        public string accountName;
        public string accountBankName;
        public double accountBalance;
        public const int MINBALANCE = 500;

        public Account() { }
        

        public Account(int accId, string accName, string accBankName, double accBalance)
        {
            accountId = accId;
            accountName = accName;
            accountBalance = CheckMinBalance(accBalance);
            accountBankName = accBankName;
        }
        public Account(int accId, string accName, string accBankName) : this(accId, accName, accBankName, MINBALANCE)
        {
        }

        public static double CheckMinBalance(double balance) {
            if (balance < MINBALANCE) { return MINBALANCE; }
            else { return balance; }
        }

        public static void PrintDetailsOut(Account account, out int accountId, out string accountName, out string accountBankName, out double accountBalance)
        {
            accountId = account.accountId;
            accountName = account.accountName;
            accountBankName = account.accountBankName;
            accountBalance = account.accountBalance;
        }
        public static double Withdraw(Account account, double withdrawnAmount)
        {
            if ((account.accountBalance - withdrawnAmount) < MINBALANCE)
            {
                return -1;
            }
            account.accountBalance = account.accountBalance - withdrawnAmount;
            return account.accountBalance;

        }
        public static double Deposite(Account account, double depositedAmount)
        {

            account.accountBalance += depositedAmount;
            return account.accountBalance;

        }

        public static double Balance(Account account)
        {
            return account.accountBalance;
        }
    }
}
